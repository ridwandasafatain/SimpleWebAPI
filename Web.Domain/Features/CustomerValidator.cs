using FluentValidation;

namespace Web.Domain
{
    public class InsertCustomerValidator : AbstractValidator<InsertCustomerRequest>
    {
        public InsertCustomerValidator()
        {
            RuleFor(c => c.CustomerName).NotNull().NotEmpty();
            RuleFor(c => c.CustomerCode).NotNull().NotEmpty();
            RuleFor(c => c.CustomerAddress).NotNull().NotEmpty();
            RuleFor(c => c.CreatedBy).NotNull();
        }
    }

    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(c => c.CustomerId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(c => c.CustomerName).NotNull().NotEmpty();
            RuleFor(c => c.CustomerCode).NotNull().NotEmpty();
            RuleFor(c => c.CustomerAddress).NotNull().NotEmpty();
            RuleFor(c => c.ModifiedBy).NotNull();
        }
    }
}
