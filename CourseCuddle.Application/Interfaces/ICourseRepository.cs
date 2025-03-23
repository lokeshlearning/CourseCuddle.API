using CourseCuddle.Application.DTOs;
using CourseCuddle.Core.Entities;

namespace CourseCuddle.Application.Interfaces
{
    public interface ICourseRepository

    {
        public Task<CourseDTO?> GetCourseDetailsById(int courseId);
        public Task<List<CourseDTO?>> GetAllCoursesAsync(int? categoryId = null);
    }
}
