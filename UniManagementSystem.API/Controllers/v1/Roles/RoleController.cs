using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniManagementSystem.API.Controllers.v1.BaseApiController;
using UniManagementSystem.Application.Features.Roles.Commands;
using UniManagementSystem.Application.Features.Roles.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UniManagementSystem.API.Controllers.v1.Roles
{
    public class RoleController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await Mediator.Send(new GetAllRolesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            var result = await Mediator.Send(command);

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }

    }
}
