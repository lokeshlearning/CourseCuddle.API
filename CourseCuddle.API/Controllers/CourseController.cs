using CourseCuddle.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseCuddle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService courseService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var allCourses = await courseService.GetAllCoursesAsync();
            return Ok(allCourses);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<IActionResult> GetAllCoursesByCategoryIdAsync(int categoryId)
        {
            var allCourseCategories = await courseService.GetAllCoursesAsync(categoryId);
            return Ok(allCourseCategories);
        }

        [HttpGet("Detail/{courseId}")]
        public async Task<IActionResult> GetCourseDetailsById(int courseId)
        {
            var courseDetails = await courseService.GetCourseDetailsById(courseId);
            if(courseDetails== null)
            {
                return NotFound();
            }
            return Ok(courseDetails);
        }

    }
}
