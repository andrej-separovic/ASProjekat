using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.Brand;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetBrandQuery : IGetBrandQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetBrandQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Get Brand by Id.";

        public BrandNoIdDto Execute(int search)
        {
            var query = _context.Brands.Where(x => x.Id == search).FirstOrDefault();

            if (query == null)
            {
                throw new EntityNotFoundException(search, typeof(Brand));
            }

            return _mapper.Map<BrandNoIdDto>(query);
        }
    }
}
