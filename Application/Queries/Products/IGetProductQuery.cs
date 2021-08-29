using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Products
{
    public interface IGetProductQuery : IQuery<int, ProductNoIdDto>
    {
    }
}
