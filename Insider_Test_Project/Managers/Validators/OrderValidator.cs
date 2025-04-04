

using FluentValidation;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Managers.Validators
{
    internal class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() {

            RuleFor(order => order.Id).NotEmpty().WithMessage("Order ID is required.");
            RuleFor(order => order.CreatedDate).NotEmpty().WithMessage("Date of creating is required.");
            RuleFor(order => order.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
        }
    }
}
