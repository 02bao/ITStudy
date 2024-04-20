﻿using AutoMapper;
using ITStudy.DTO;
using ITStudy.Models;

namespace ITStudy.Mapper
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<Users , UsersDTO>().ReverseMap();
            CreateMap<Users_Register , Users_RegisterDTO>().ReverseMap();
            CreateMap<Instructors , InstructorsDTO>().ReverseMap();
            CreateMap<Instructors_Create , Instructors_CreateDTO>().ReverseMap();
            CreateMap<Users_LoginDTO,Users > ().ReverseMap();
            CreateMap<Posts,PostsDTO > ().ReverseMap();
            CreateMap<Posts_Create,Posts_CreateDTO > ().ReverseMap();
            CreateMap<Category,CategoryDTO > ().ReverseMap();
            CreateMap<Category_Create,Category_CreateDTO> ().ReverseMap();
            CreateMap<Courses,CoursesDTO> ().ReverseMap();
            CreateMap<Courses_Create,Courses_CreateDTO> ().ReverseMap();
            CreateMap<Lectures,LecturesDTO> ().ReverseMap();
            CreateMap<Lectures_Create,Lectures_CreateDTO> ().ReverseMap();
            CreateMap<Student,StudentDTO> ().ReverseMap();
            CreateMap<Student_Create,Student_CreateDTO> ().ReverseMap();
            CreateMap<Cart,CartDTO> ().ReverseMap();
            CreateMap<CartItem,CartItemDTO> ().ReverseMap();
            CreateMap<CartItem_Add,CartItem_AddDTO> ().ReverseMap();
        }
    }
}
