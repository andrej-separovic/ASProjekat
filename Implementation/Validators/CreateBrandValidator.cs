using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateBrandValidator : AbstractValidator<BrandCreateDto>
    {
        public CreateBrandValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Brand name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !context.Brands.Any(b => b.Name.ToLower() == name.ToLower())).WithMessage("Brand with that name is already in database.");
            });
        }
    }
}
