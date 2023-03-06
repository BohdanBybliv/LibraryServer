using AutoMapper;
using LibraryServer.DTOs;
using LibraryServer.Extensions;
using LibraryServer.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryServer.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        public BookService(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceMethodContentResult<IEnumerable<BookDTO>>> GetAll(string? order)
        {
            List<Book> books;
            if (order == null)
            {
                books = await _context.Books.Include(b => b.Reviews)
                    .Include(b => b.Ratings).ToListAsync();
            }
            else
            {
                books = await _context.Books.Include(b => b.Reviews).Include(b => b.Ratings)
                .OrderBy(b => order == "title" ? b.Title : b.Author).ToListAsync();
            }

            return new ServiceMethodContentResult<IEnumerable<BookDTO>>(books.Select(b => _mapper.Map<BookDTO>(b)));
        }

        public async Task<ServiceMethodContentResult<IEnumerable<BookDTO>>> GetRecommended(string? genre)
        {
            List<Book> books;
            if (genre == null)
            {
                books = await _context.Books.Include(b => b.Reviews)
                    .Include(b => b.Ratings).ToListAsync();
            }
            else
            {
                books = await _context.Books.Where(b => b.Genre.ToLower() == genre.ToLower())
                    .Include(b => b.Reviews)
                    .Include(b => b.Ratings)
                    .ToListAsync();
            }

            var recommendedBooks = books.Select(b => _mapper.Map<BookDTO>(b))
                .Where(b => b.ReviewsNumber > 10)
                .OrderByDescending(b => b.Rating).Take(10);

            return new ServiceMethodContentResult<IEnumerable<BookDTO>>(recommendedBooks);
        }

        public async Task<ServiceMethodContentResult<BookDetailsDTO>> GetById(int? id)
        {
            if (id == null) return new ServiceMethodContentResult<BookDetailsDTO>(false, StatusCode.BadRequest);

            var book = await _context.Books.Include(b => b.Ratings)
                .Include(b => b.Reviews).FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return new ServiceMethodContentResult<BookDetailsDTO>(false, StatusCode.NotFound);

            return new ServiceMethodContentResult<BookDetailsDTO>(_mapper.Map<BookDetailsDTO>(book));
        }

        public async Task<ServiceContentResult> DeleteById(int? id, string? secretKey)
        {
            if (id == null || secretKey == null) return new ServiceContentResult(false, StatusCode.BadRequest);

            if (secretKey != AppConfig.SecretKey) return new ServiceContentResult(false, StatusCode.Forbidden);

            var book = await _context.Books.FindAsync(id);

            if (book == null) return new ServiceContentResult(false, StatusCode.NotFound);

            _context.Remove(book);

            await _context.SaveChangesAsync();

            return new ServiceContentResult(true, StatusCode.Success);
        }

        public async Task<ServiceMethodContentResult<int>> CreateBook(BookCreationDTO bookDTO)
        {
            var book = await _context.Books.FindAsync(bookDTO.Id);

            if (book == null)
            {
                var newBook = _mapper.Map<Book>(bookDTO);

                await _context.Books.AddAsync(newBook);

                await _context.SaveChangesAsync();

                return new ServiceMethodContentResult<int>(newBook.Id);
            }
            else
            {
                _mapper.Map(bookDTO, book);

                await _context.SaveChangesAsync();

                return new ServiceMethodContentResult<int>(book.Id);
            }
        }

        public async Task<ServiceMethodContentResult<int>> CreateReview(ReviewCreationDTO reviewDTO)
        {
            var review = _mapper.Map<Review>(reviewDTO);

            await _context.Reviews.AddAsync(review);

            await _context.SaveChangesAsync();

            return new ServiceMethodContentResult<int>(review.Id);
        }

        public async Task<ServiceMethodContentResult<int>> CreateRating(RatingCreationDTO ratingDTO)
        {
            var rating = _mapper.Map<Rating>(ratingDTO);

            await _context.Ratings.AddAsync(rating);

            await _context.SaveChangesAsync();

            return new ServiceMethodContentResult<int>(rating.Id);
        }
    }
}
