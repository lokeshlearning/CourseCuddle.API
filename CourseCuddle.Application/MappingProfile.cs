using AutoMapper;
using CourseCuddle.Application.DTOs;
using CourseCuddle.Core.Entities;

namespace CourseCuddle.Application
{
   public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseCategory, CourseCategoryDTO>().ReverseMap();
            CreateMap<CourseDTO, Course>().ReverseMap();

        }
    }
}
