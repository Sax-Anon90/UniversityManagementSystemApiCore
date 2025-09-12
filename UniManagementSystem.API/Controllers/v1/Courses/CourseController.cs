using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniManagementSystem.API.Controllers.v1.BaseApiController;
using UniManagementSystem.Application.Features.Courses.Commands;
using UniManagementSystem.Application.Features.Courses.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UniManagementSystem.API.Controllers.v1.Courses
{
    public class CourseController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await Mediator.Send(new GetAllCoursesQuery()));
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var result = await Mediator.Send(new GetCourseByIdQuery() { courseId = courseId });

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet("courseCategory/{courseCategoryId}")]
        public async Task<IActionResult> GetAllCoursesByCourseCategoryId(int courseCategoryId)
        {
            return Ok(await Mediator.Send(new GetAllCoursesByCourseCategoryIdQuery() { CourseCategoryId = courseCategoryId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var result = await Mediator.Send(command);

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
