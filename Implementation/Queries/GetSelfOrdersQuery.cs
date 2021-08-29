using Application.DataTransfer;
using Application.Queries.Order;
using AutoMapper;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetSelfOrdersQuery : IGetSelfOrdersQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetSelfOrdersQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Get User Orders.";

        public ICollection<OrderCreateDto> Execute(int search)
        {
            var query = _context.Orders.Include(x => x.OrderLines).Where(x => x.UserId == search).ToList();

            return _mapper.Map<List<OrderCreateDto>>(query);
        }
    }
}
