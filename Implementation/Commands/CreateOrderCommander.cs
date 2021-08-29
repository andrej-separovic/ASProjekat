using Application;
using Application.Commands.Order;
using Application.DataTransfer;
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
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateOrderValidator _validator;
        private readonly IApplicationActor _actor;

        public CreateOrderCommand(Context context, IMapper mapper, CreateOrderValidator validator, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 6;

        public string Name => "Creating Order.";

        public void Execute(OrderCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var order = _mapper.Map<Order>(request);

            order.UserId = _actor.Id;

            var orderLines = new List<OrderLine>();

            foreach(var o in request.OrderLines)
            {
                var ol = new OrderLine();

                var p = _context.Products.Find(o.ProductId);

                p.Quantity -= o.Quantity;

                ol.ProductId = o.ProductId;
                ol.Quantity = o.Quantity;
                ol.ProductName = p.Name;
                ol.ProductPrice = p.Price;

                orderLines.Add(ol);
            }

            order.OrderLines = orderLines;

            _context.Orders.Add(order);

            _context.SaveChanges();
        }
    }
}
