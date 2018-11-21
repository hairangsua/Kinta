using AutoMapper;
using Kinta.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Domain.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
