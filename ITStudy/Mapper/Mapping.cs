using AutoMapper;
using ITStudy.DTO;
using ITStudy.Models;

namespace ITStudy.Mapper
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<Users , UsersDTO>();
            CreateMap<UsersDTO , Users>();
            CreateMap<Users_Register , Users_RegisterDTO>();
            CreateMap<Users_RegisterDTO , Users_Register>();
        }
    }
}
