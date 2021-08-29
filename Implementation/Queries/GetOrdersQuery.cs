using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Order;
using Application.Search;
using AutoMapper;
using Domain;
using EFDataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetOrdersQuery : IGetOrdersQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetOrdersQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Search Orders.";

        public PagedResponse<OrderSearchDto> Execute(OrderSearch search)
        {
            var query = _context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(search.ShippingAddress) && !string.IsNullOrWhiteSpace(search.ShippingAddress))
            {
                query = query.Where(x => x.ShippingAddress.ToLower().Contains(search.ShippingAddress.ToLower()));
            }

            return query.Paged<OrderSearchDto, Order>(search, _mapper);
        }
    }
}
