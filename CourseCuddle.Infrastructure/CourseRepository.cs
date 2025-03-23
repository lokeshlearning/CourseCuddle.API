using CourseCuddle.Application.DTOs;
using CourseCuddle.Application.Interfaces;
using CourseCuddle.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseCuddle.Infrastructure
{
    public class CourseRepository(OnlineCourseDbContext dbContext): ICourseRepository
    {

        public async Task<CourseDTO?> GetCourseDetailsById(int courseId)
        {
            var course = await dbContext.Courses
               .Include(c => c.Category)
               .Include(c => c.Reviews)
               .Include(c => c.SessionDetails)
               .Where(c => c.CourseId == courseId)
               .Select(c => new CourseDetailDTO
               {
                   CourseId = c.CourseId,
                   Title = c.Title,
                   Description = c.Description,
                   Price = c.Price,
                   CourseType = c.CourseType,
                   SeatsAvailable = c.SeatsAvailable,
                   Duration = c.Duration,
                   CategoryId = c.CategoryId,
                   InstructorId = c.InstructorId,
                   InstructorUserId = c.Instructor.UserId,
                   StartDate = c.StartDate,
                   EndDate = c.EndDate,
                   Thumbnail = c.Thumbnail,
                   Category = new CourseCategoryDTO
                   {
                       CategoryId = c.Category.CategoryId,
                       CategoryName = c.Category.CategoryName,
                       Description = c.Category.Description
                   },
                   Reviews = c.Reviews.Select(r => new UserReviewDTO
                   {
                       CourseId = r.CourseId,
                       ReviewId = r.ReviewId,
                       UserId = r.UserId,
                       UserName = r.User.DisplayName,
                       Rating = r.Rating,
                       Comments = r.Comments,
                       ReviewDate = r.ReviewDate
                   }).OrderByDescending(o => o.Rating).Take(10).ToList(),
                   SessionDetails = c.SessionDetails.Select(sd => new SessionDetailDTO
                   {
                       SessionId = sd.SessionId,
                       CourseId = sd.CourseId,
                       Title = sd.Title,
                       Description = sd.Description,
                       VideoUrl = sd.VideoUrl,
                       VideoOrder = sd.VideoOrder
                   }).OrderBy(o => o.VideoOrder).ToList()
                   ,
                   UserRating = new UserRatingDTO
                   {
                       CourseId = c.CourseId,
                       AverageRating = c.Reviews.Any() ? Convert.ToDecimal(c.Reviews.Average(r => r.Rating)) : 0,
                       TotalRating = c.Reviews.Count
                   }
               })
               .FirstOrDefaultAsync();

            return course;
        }
        public async Task<List<CourseDTO>> GetAllCoursesAsync (int? categoryId= null)
        {

            var query = dbContext.Courses.Include(c => c.Category).AsQueryable();
            if(categoryId.HasValue)
            {
                query = query.Where(c => c.CategoryId == categoryId);
            }
            var courses = await query
                .Select(s => new CourseDTO
                {
                    CourseId = s.CourseId,
                    Title = s.Title,
                    Description = s.Description,
                    Price = s.Price,
                    CourseType = s.CourseType,
                    SeatsAvailable = s.SeatsAvailable,
                    Duration = s.Duration,
                    CategoryId = s.CategoryId,
                    InstructorId = s.InstructorId,
                    Thumbnail = s.Thumbnail,
                    InstructorUserId = s.Instructor.UserId,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Category = new CourseCategoryDTO
                    {
                        CategoryId = s.Category.CategoryId,
                        CategoryName = s.Category.CategoryName,
                        Description = s.Category.Description
                    },
                    UserRating = new UserRatingDTO
                    {
                        CourseId = s.CourseId,
                        AverageRating = s.Reviews.Any() ? Convert.ToDecimal(s.Reviews.Average(r => r.Rating)) : 0,
                        TotalRating = s.Reviews.Count
                    }
                })
                .ToListAsync();

            return courses;
        }
    }
}
