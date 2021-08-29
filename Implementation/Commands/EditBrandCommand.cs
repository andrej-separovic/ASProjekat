using Application.Commands.Brand;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EditBrandCommand : IEditBrandCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly EditBrandValidator _validator;

        public EditBrandCommand(Context context, IMapper mapper, EditBrandValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 15;

        public string Name => "Editing Brand.";

        public void Execute(BrandDto request)
        {
            var brand = _context.Brands.Where(x => x.Id == request.Id).FirstOrDefault();

            if (brand == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Brand));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, brand);

            _context.SaveChanges();
        }
    }
}
