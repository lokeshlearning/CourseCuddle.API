using CourseCuddle.Application.Interfaces;
using CourseCuddle.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseCuddle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController(ICourseCategoryService courseCategoryService) : ControllerBase
    {


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseCategoryById(int id)
        {
            var courseCategory = await courseCategoryService.GetCourseCategoryById(id);   
            if (courseCategory == null)
            {
                return NotFound("Course category is not available");
            }
            return Ok(courseCategory);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCourseCategories()
        {


            var allCourseCategories = await courseCategoryService.GetAllCourseCategories();
            return Ok(allCourseCategories);
        }

  
    }
}
