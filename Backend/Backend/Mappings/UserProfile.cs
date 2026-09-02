using AutoMapper;
using Backend.Models.Dtos;
using Backend.Models.Entities;
using Backend.Models.Params;

namespace Backend.Mappings
{
    public class UserProfile:Profile
    {
        public  UserProfile()
        {
            ///<來源類別,目標類別>
            CreateMap<CreatuserParam, CreateUserDto>();
            CreateMap<CreateUserDto, Users>();
            CreateMap<SearchuserParam, SearchUserDto>();
            CreateMap<Users, UserDto>();
        }
    }
}
