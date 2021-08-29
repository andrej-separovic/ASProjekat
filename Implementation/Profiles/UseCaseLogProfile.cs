﻿using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class UseCaseLogProfile : Profile
    {
        public UseCaseLogProfile()
        {
            CreateMap<UseCaseLog, UseCaseLogDto>();
            CreateMap<UseCaseLogDto, UseCaseLog>();
        }
    }
}
