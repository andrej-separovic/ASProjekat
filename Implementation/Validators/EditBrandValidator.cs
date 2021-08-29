using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class EditBrandValidator : AbstractValidator<BrandDto>
    {
        public EditBrandValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Brand name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto, name) => !context.Brands.Any(b => b.Name == name && b.Id != dto.Id)).WithMessage(b => $"Brand with name {b.Name} already exists.");
            });
        }
    }
}