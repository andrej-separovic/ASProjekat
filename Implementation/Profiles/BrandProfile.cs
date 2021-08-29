using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();

            CreateMap<Brand, BrandNoIdDto>();
            CreateMap<BrandNoIdDto, Brand>();

            CreateMap<Brand, BrandCreateDto>();
            CreateMap<BrandCreateDto, Brand>();
        }
    }
}
