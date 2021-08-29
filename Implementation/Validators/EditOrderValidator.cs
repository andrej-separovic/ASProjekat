using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators
{
    public class EditOrderValidator : AbstractValidator<OrderEditDto>
    {
        public EditOrderValidator()
        {
            RuleFor(x => x.ShippingAddress).NotEmpty().WithMessage("Shipping Address is required.");
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("Order Date is required.").GreaterThan(DateTime.UtcNow).WithMessage("Order Date must be in the future.");
        }
    }
}
