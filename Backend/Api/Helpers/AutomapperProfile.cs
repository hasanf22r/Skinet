using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;
using AutoMapper;
using Domain;

namespace Api.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateUserDTO, AppUser>().ForMember(a => a.Image, a => a.MapFrom(b =>
                b.Image != null ? Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(b.Image.FileName) : "default.jpg"
            ));
            CreateMap<AppUser, GetUserDTO>();

        }
    }
}