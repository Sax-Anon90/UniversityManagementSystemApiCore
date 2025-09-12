using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniManagementSystem.API.Controllers.v1.BaseApiController;
using UniManagementSystem.Application.Features.CourseCategories.Commands;
using UniManagementSystem.Application.Features.CourseCategories.Queries;
using UniManagementSystem.Application.Features.Courses.Commands;
using UniManagementSystem.Application.Features.Courses.Queries;
using UniManagementSystem.Data.DomainEntities;

namespace UniManagementSystem.API.Controllers.v1.CourseCategories
{

    public class CourseCategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCourseCategories()
        {
            return Ok(await Mediator.Send(new GetAllCourseCategoriesQuery()));
        }

        [HttpGet("{courseCategoryId}")]
        public async Task<IActionResult> GetAllCourseCategoryById(int courseCategoryId)
        {
            return Ok(await Mediator.Send(new GetCourseCategoryByIdQuery() { CourseCategoryId = courseCategoryId }));
        }


        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory([FromBody] CreateCourseCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourseCategory([FromBody] UpdateCourseCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{courseCategoryId}")]
        public async Task<IActionResult> DeleteCourse(int courseCategoryId)
        {
            var result = await Mediator.Send(new DeleteCourseCategoryCommand() { CourseCategoryId = courseCategoryId });

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
