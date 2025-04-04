using FluentValidation;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Managers.Validators
{
    internal class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
        RuleFor(prod => prod.Id).NotEmpty().WithMessage("Product ID is required.");
            RuleFor(prod => prod.Name)
                    .NotEmpty().WithMessage("Product name is required.")
                    .MaximumLength(50).WithMessage("Product name lenght must be less then 50 symbols.");
            RuleFor(prod => prod.Description)
                .NotEmpty().WithMessage("Product description is required.")
                .MaximumLength(300).WithMessage("Decription must be not more then 300 symbols.");
            RuleFor(prod => prod.Price)
                .NotEmpty().WithMessage("Price is required.");
        }
    }
}
