using FluentValidation;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Managers.Validators
{
    internal class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(user => user.Id).NotEmpty().WithMessage("User ID is required.");
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must contain at least 2 symbols.")
                .MaximumLength(50).WithMessage("Name can't be more then 50 symbols lenght.");
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is invalid.")
                .MaximumLength(200).WithMessage("Email can't be more then 200 symbols.");
            RuleFor(user => user.PasswordHash)
                .NotEmpty().WithMessage("Password hash is required.");
        }
    }
}
