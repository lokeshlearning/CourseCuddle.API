using CourseCuddle.Application.DTOs;

namespace CourseCuddle.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDTO?> GetCourseDetailsById(int courseId);
        Task<List<CourseDTO?>> GetAllCoursesAsync(int? categoryId =null);

    }
}
