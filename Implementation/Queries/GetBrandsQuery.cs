using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Brand;
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
    public class GetBrandsQuery : IGetBrandsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetBrandsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Brands search.";

        public PagedResponse<BrandDto> Execute(BrandSearch search)
        {
            var query = _context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<BrandDto, Brand>(search, _mapper);
        }
    }
}
