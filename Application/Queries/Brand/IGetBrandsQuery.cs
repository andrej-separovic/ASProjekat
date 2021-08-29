﻿using Application.DataTransfer;
using Application.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Brand
{
    public interface IGetBrandsQuery : IQuery<BrandSearch, PagedResponse<BrandDto>>
    {
    }
}
