using CourseCuddle.Application.DTOs;

namespace CourseCuddle.Application.Interfaces
{
    public interface ICourseCategoryService
    {
       Task<CourseCategoryDTO?> GetCourseCategoryById(int id);
       Task<List<CourseCategoryDTO?>> GetAllCourseCategories();




    }
}
