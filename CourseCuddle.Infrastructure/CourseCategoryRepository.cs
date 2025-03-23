using CourseCuddle.Application.Interfaces;
using CourseCuddle.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseCuddle.Infrastructure
{
    public class CourseCategoryRepository(OnlineCourseDbContext dbContext) : ICourseCategoryRepository
    {
        public async Task<CourseCategory?> GetCourseCategoryById(int id)
        {
            return await dbContext.CourseCategories.FindAsync(id);
        }

        public async Task<List<CourseCategory?>> GetAllCourseCategories()
        {
            return await dbContext.CourseCategories.ToListAsync();
        }

    }
}
