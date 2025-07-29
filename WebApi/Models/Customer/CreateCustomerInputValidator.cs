using FluentValidation;

namespace WebApi.Models.Customer
{
    public class CreateCustomerInputValidator : AbstractValidator<CreateCustomerInput>
    {
        public CreateCustomerInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Name must have at least 2 characters")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Document)
                .NotEmpty().WithMessage("Document is required")
                .Matches(@"^\d{11}$|^\d{14}$").WithMessage("Document must be a valid CPF (11 digits) or CNPJ (14 digits)");
        }
    }
} 