using FluentValidation;
using LibraryServer.DTOs;

namespace LibraryServer.Validators
{
    public class RatingValidator : AbstractValidator<RatingCreationDTO>
    {
        public RatingValidator() 
        {
            RuleFor(r => r.Score).GreaterThanOrEqualTo(1).LessThanOrEqualTo(5);

            RuleFor(r => r.BookId).GreaterThan(0).NotNull();
        }
    }
}
