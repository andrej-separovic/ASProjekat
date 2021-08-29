using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderCreateDto>();
            CreateMap<OrderCreateDto, Order>();

            CreateMap<Order, OrderSearchDto>();
            CreateMap<OrderSearchDto, Order>();

            CreateMap<Order, OrderEditDto>();
            CreateMap<OrderEditDto, Order>();
        }
    }
}
