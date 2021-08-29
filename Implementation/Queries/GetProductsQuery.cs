using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Products;
using Application.Search;
using AutoMapper;
using Domain;
using EFDataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Implementation.Queries
{
    public class GetProductsQuery : IGetProductsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetProductsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Products search.";

        public PagedResponse<ProductDto> Execute(ProductSearch search)
        {
            var query = _context.Products.Include(x=>x.Brand).AsQueryable();

            if (search.Id !=0)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.OS) && !string.IsNullOrWhiteSpace(search.OS))
            {
                query = query.Where(x => x.OS.ToLower().Contains(search.OS.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.CPU) && !string.IsNullOrWhiteSpace(search.CPU))
            {
                query = query.Where(x => x.CPU.ToLower().Contains(search.CPU.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.GPU) && !string.IsNullOrWhiteSpace(search.GPU))
            {
                query = query.Where(x => x.GPU.ToLower().Contains(search.GPU.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.RAM) && !string.IsNullOrWhiteSpace(search.RAM))
            {
                query = query.Where(x => x.RAM.ToLower().Contains(search.RAM.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Storage) && !string.IsNullOrWhiteSpace(search.Storage))
            {
                query = query.Where(x => x.Storage.ToLower().Contains(search.Storage.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.PSU) && !string.IsNullOrWhiteSpace(search.PSU))
            {
                query = query.Where(x => x.PSU.ToLower().Contains(search.PSU.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.FormFactor) && !string.IsNullOrWhiteSpace(search.FormFactor))
            {
                query = query.Where(x => x.FormFactor.ToLower().Contains(search.FormFactor.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.BrandName) && !string.IsNullOrWhiteSpace(search.BrandName))
            {
                query = query.Where(x => x.Brand.Name.ToLower().Contains(search.BrandName.ToLower()));
            }
            if (search.Price > 0)
            {
                query = query.Where(x => x.Price >= search.Price);
            }

            return query.Paged<ProductDto, Product>(search, _mapper);
        }
    }
}
