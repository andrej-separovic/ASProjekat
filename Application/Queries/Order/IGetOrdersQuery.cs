using Application.DataTransfer;
using Application.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Order
{
    public interface IGetOrdersQuery : IQuery<OrderSearch, PagedResponse<OrderSearchDto>>
    {
    }
}
