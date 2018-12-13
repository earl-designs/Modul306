using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WAF.API.Dtos;
using WAF.API.Models;

namespace WAF.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>();
                
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}