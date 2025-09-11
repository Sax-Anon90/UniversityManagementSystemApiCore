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
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCourseEnrollmentsByStudentId(int studentId)
        {
            return Ok(Mediator.Send(new GetAllStudentCourseEnrollmentsByIdQuery() { studentAccountId = studentId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseEnrollment([FromBody] CreateCourseEnrollmentComand command)
        {
            var result = await Mediator.Send(command);

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourseEnrollment([FromBody] DeleteCourseEnrollmentCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }


    }
}
