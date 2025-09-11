using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniManagementSystem.API.Controllers.v1.BaseApiController;
using UniManagementSystem.Application.Features.AdminAccountRoles.Commands;
using UniManagementSystem.Application.Features.AdminAccountRoles.Queries;
using UniManagementSystem.Application.Features.CourseEnrollments.Commands;
using UniManagementSystem.Application.Features.CourseEnrollments.Queries;

namespace UniManagementSystem.API.Controllers.v1.AdminAccountRoles
{
    public class AdminAccountRoleController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAdminAccountRolesByAdminAccountId(int adminAccountId)
        {
            return Ok(Mediator.Send(new GetAllAdminAccountRolesByIdQuery() { adminAccountId = adminAccountId }));
        }


        [HttpPost]
        public async Task<IActionResult> CreateAdminAccountRole([FromBody] CreateCourseEnrollmentComand command)
        {
            var result = await Mediator.Send(command);

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdminAccountRole([FromBody] DeleteAdminAccountRoleCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }
    }
}
