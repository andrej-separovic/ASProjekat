using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(x => x.BrandName, opt => opt.MapFrom(x=>x.Brand.Name));
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductNoIdDto>().ForMember(x => x.BrandName, opt => opt.MapFrom(x => x.Brand.Name));
            CreateMap<ProductNoIdDto, Product>();

            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
