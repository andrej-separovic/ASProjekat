using Application.Commands.Brand;
using Application.DataTransfer;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class CreateBrandCommand : ICreateBrandCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateBrandValidator _validator;

        public CreateBrandCommand(Context context, IMapper mapper, CreateBrandValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Creating Brand.";

        public void Execute(BrandCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = _mapper.Map<Brand>(request);

            _context.Brands.Add(brand);

            _context.SaveChanges();
        }
    }
}
