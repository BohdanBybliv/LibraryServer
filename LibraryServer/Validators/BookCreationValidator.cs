using FluentValidation;
using LibraryServer.DTOs;

namespace LibraryServer.Validators
{
    public class BookCreationValidator : AbstractValidator<BookCreationDTO>
    {
        public BookCreationValidator()
        {
            RuleFor(b => b.Author).MinimumLength(5);

            RuleFor(b => b.Title).MinimumLength(5);

            RuleFor(b => b.Content).MinimumLength(10);

            RuleFor(b => b.Genre).MinimumLength(5);

            RuleFor(b => b.Cover).NotEmpty();
        }
    }
}
