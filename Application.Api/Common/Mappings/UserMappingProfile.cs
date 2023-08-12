﻿using Application.Api.Common.Models;
using AutoMapper;
using Domain.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.Common.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserGetDto>().ReverseMap();
        }
    }
}
