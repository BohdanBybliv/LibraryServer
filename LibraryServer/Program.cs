using FluentValidation.AspNetCore;
using FluentValidation;
using LibraryServer.DTOs;
using LibraryServer.Middlewares;
using LibraryServer.Models;
using LibraryServer.Services.BookService;
using LibraryServer.Validators;
using LibraryServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IValidator<RatingCreationDTO>, RatingValidator>();

builder.Services.AddScoped<IValidator<ReviewCreationDTO>, ReviewCreationValidator>();

builder.Services.AddScoped<IValidator<BookCreationDTO>, BookCreationValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<IBookService, BookService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
