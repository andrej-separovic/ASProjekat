using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class EditProductValidator : AbstractValidator<ProductDto>
    {
        public EditProductValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto, name) => !context.Products.Any(p => p.Name == name && p.Id != dto.Id)).WithMessage(p => $"Product with name {p.Name} already exists.");
            });
            RuleFor(x => x.OS).NotEmpty().WithMessage("OS is required.");
            RuleFor(x => x.CPU).NotEmpty().WithMessage("CPU is required.");
            RuleFor(x => x.GPU).NotEmpty().WithMessage("GPU is required.");
            RuleFor(x => x.RAM).NotEmpty().WithMessage("RAM is required.");
            RuleFor(x => x.Storage).NotEmpty().WithMessage("Storage is required.");
            RuleFor(x => x.PSU).NotEmpty().WithMessage("PSU is required.");
            RuleFor(x => x.FormFactor).NotEmpty().WithMessage("FormFactor is required.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl is required.");
            RuleFor(x => x.Warranty).NotEmpty().WithMessage("Warranty is required.").DependentRules(() =>
            {
                RuleFor(x => x.Warranty).GreaterThan(11).WithMessage("Warranty must be at least 12 months.");
            });
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.").DependentRules(() =>
            {
                RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be above 0.");
            });
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is required.").DependentRules(() =>
            {
                RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be above 0.");
            });
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("BrandId is required.").DependentRules(() =>
            {
                RuleFor(x => x.BrandId).Must(id => context.Brands.Any(b => b.Id == id)).WithMessage("Brand with that id doesn't exist in database.");
            });
        }
    }
}
