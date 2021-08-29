using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<OrderCreateDto>
    {
        public CreateOrderValidator(Context context)
        {
            RuleFor(x => x.ShippingAddress).NotEmpty().WithMessage("Shipping Address is required.").DependentRules(()=>
            {
                RuleFor(x => x.OrderDate).NotEmpty().WithMessage("Order Date is required.").GreaterThan(DateTime.UtcNow).WithMessage("Order Date must be in the future.");
                RuleForEach(x => x.OrderLines).Must((x, ol) => x.OrderLines.Count(e => e.ProductId == ol.ProductId) == 1).WithMessage("Duplicated Order Line.");
                RuleForEach(x => x.OrderLines).Must(ol => context.Products.Any(x => x.Id == ol.ProductId && x.Quantity >= ol.Quantity)).WithMessage("Not enough products in storage.");
            });
        }
    }
}
