using AutoMapper;
using CourseCuddle.Application.DTOs;
using CourseCuddle.Application.Interfaces;

namespace CourseCuddle.Application.Services
{
    public class CourseService(ICourseRepository courseRepository) : ICourseService
    {
        public Task<List<CourseDTO?>> GetAllCoursesAsync(int? categoryId = null)
        {
            return courseRepository.GetAllCoursesAsync(categoryId);
        }
        public Task<CourseDTO?> GetCourseDetailsById(int courseId)
        {
            return courseRepository.GetCourseDetailsById(courseId);

        }
    }
}
