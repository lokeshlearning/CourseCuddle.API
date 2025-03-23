using CourseCuddle.Core.Entities;

namespace CourseCuddle.Application.Interfaces
{
    public interface ICourseCategoryRepository
    {
       public Task<CourseCategory?> GetCourseCategoryById(int id);
       public Task<List<CourseCategory?>> GetAllCourseCategories();
    }
}
