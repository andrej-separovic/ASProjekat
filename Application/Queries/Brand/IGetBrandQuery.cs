using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Brand
{
    public interface IGetBrandQuery : IQuery<int, BrandNoIdDto>
    {
    }
}
