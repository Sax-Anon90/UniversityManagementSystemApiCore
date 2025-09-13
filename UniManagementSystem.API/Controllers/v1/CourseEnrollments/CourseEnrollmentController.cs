using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniManagementSystem.API.Controllers.v1.BaseApiController;
using UniManagementSystem.Application.Features.CourseEnrollments.Commands;
using UniManagementSystem.Application.Features.CourseEnrollments.Queries;

namespace UniManagementSystem.API.Controllers.v1.CourseEnrollments
{
    public class CourseEnrollmentController : BaseController
    {
        [HttpGet("{studentAccountId}")]
        public async Task<IActionResult> GetCourseEnrollmentsByStudentId(int studentAccountId)
        {
            return Ok(await Mediator.Send(new GetAllStudentCourseEnrollmentsByIdQuery() { studentAccountId = studentAccountId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseEnrollment([FromBody] CreateCourseEnrollmentComand command)
        {
            var result = await Mediator.Send(command);

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpDelete("{courseEnrollmentId}")]
        public async Task<IActionResult> DeleteCourseEnrollment(int courseEnrollmentId)
        {
            var result = await Mediator.Send(new DeleteCourseEnrollmentCommand() { courseEnrollmentId = courseEnrollmentId });

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }


    }
}
