using FluentValidation;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Managers.Validators
{
    internal class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cust => cust.Id).NotEmpty().WithMessage("Customer ID is required.");
            RuleFor(cust => cust.UserId).NotEmpty().WithMessage("User's profile ID is required.");
        }
    }
}
