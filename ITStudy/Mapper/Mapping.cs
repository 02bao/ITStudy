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
            CreateMap<Instructors , InstructorsDTO>();
            CreateMap<InstructorsDTO , Instructors>();
            CreateMap<Instructors_Create , Instructors_CreateDTO>();
            CreateMap<Instructors_CreateDTO , Instructors_Create>();
            CreateMap<  Users_LoginDTO,Users > ().ReverseMap();
        }
    }
}
