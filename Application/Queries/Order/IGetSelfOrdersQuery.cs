using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Order
{
    public interface IGetSelfOrdersQuery : IQuery<int, ICollection<OrderCreateDto>>
    {
    }
}
