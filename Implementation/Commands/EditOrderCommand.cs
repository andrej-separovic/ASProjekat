using Application.Commands.Order;
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
    public class EditOrderCommand : IEditOrderCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly EditOrderValidator _validator;

        public EditOrderCommand(Context context, IMapper mapper, EditOrderValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Editing Order.";

        public void Execute(OrderEditDto request)
        {
            var order = _context.Orders.Where(x => x.Id == request.Id).FirstOrDefault();

            if (order == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Order));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, order);

            _context.SaveChanges();
        }
    }
}
