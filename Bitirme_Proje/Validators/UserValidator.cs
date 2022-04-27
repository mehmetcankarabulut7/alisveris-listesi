
using Bitirme_Proje.EntityFramework.Entities;
using FluentValidation;

namespace Bitirme_Proje.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotNull().WithMessage("FirstName can not be null");

            RuleFor(u => u.LastName)
                .NotNull().WithMessage("LastName can not be null");

            RuleFor(u => u.Mail)
                .NotNull().WithMessage("Mail can not be null");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("Password can not be null")
                .MinimumLength(8).WithMessage("Password cannot be less than 8 characters")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number");

            RuleFor(u => u.Password2)
                .NotNull().WithMessage("Password2 can not be null")
                .Equal(u => u.Password).WithMessage("Passwords must be the same");
        }
    }
}
