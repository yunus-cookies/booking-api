using FluentValidation;
using Models;

namespace Validation
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(r => r.BookingName).NotEmpty().WithMessage("Please enter a name");
            RuleFor(r => r.Date).NotEmpty().WithMessage("Please enter a date");
            RuleFor(r => r.Email).NotEmpty().WithMessage("Please enter an email");
        }
    }
}