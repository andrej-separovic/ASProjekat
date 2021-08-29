using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Order;
using AutoMapper;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetOrderQuery : IGetOrderQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetOrderQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Get Order by Id.";

        public OrderCreateDto Execute(int search)
        {
            var query = _context.Orders.Include(x=>x.OrderLines).Where(x => x.Id == search).FirstOrDefault();

            if (query == null)
            {
                throw new EntityNotFoundException(search, typeof(Order));
            }

            return _mapper.Map<OrderCreateDto>(query);
        }
    }
}
