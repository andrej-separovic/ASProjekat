using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Products;
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
    public class GetProductQuery : IGetProductQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetProductQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Get Product by Id.";

        public ProductNoIdDto Execute(int search)
        {
            var query = _context.Products.Include(x => x.Brand).Where(x => x.Id == search).FirstOrDefault();

            if (query == null)
            {
                throw new EntityNotFoundException(search, typeof(Product));
            }

            return _mapper.Map<ProductNoIdDto>(query);
        }
    }
}
