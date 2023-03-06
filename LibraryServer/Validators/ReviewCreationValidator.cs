using FluentValidation;
using LibraryServer.DTOs;

namespace LibraryServer.Validators
{
    public class ReviewCreationValidator : AbstractValidator<ReviewCreationDTO>
    {
        public ReviewCreationValidator()
        {
            RuleFor(r => r.Message).MinimumLength(5);

            RuleFor(r => r.Reviewer).MinimumLength(5);

            RuleFor(r => r.BookId).GreaterThan(0).NotNull();
        }
    }
}
