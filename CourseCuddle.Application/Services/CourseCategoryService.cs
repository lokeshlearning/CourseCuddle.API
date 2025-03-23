using AutoMapper;
using CourseCuddle.Application.DTOs;
using CourseCuddle.Application.Interfaces;

namespace CourseCuddle.Application.Services
{
    //We do all the business logics in our application project
    public class CourseCategoryService(ICourseCategoryRepository courseCategoryRepository, IMapper mapper) : ICourseCategoryService
    {
      

        public async Task<CourseCategoryDTO?> GetCourseCategoryById(int id)
        {
            var courseCategory= await courseCategoryRepository.GetCourseCategoryById(id);
            var courseCategoryDTO = mapper.Map<CourseCategoryDTO>(courseCategory);
            return courseCategoryDTO;
        }

        public async Task<List<CourseCategoryDTO?>> GetAllCourseCategories()
        {
            var allCourseCategories = await courseCategoryRepository.GetAllCourseCategories();
            var allCourseCategoriesDTO = mapper.Map<List<CourseCategoryDTO?>>(allCourseCategories);
            return allCourseCategoriesDTO;
        }


    }
}
