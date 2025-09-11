using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniManagementSystem.API.Controllers.v1.BaseApiController;
using UniManagementSystem.Application.Features.AdminAccounts.Commands;
using UniManagementSystem.Application.Features.AdminAccounts.Queries;
using UniManagementSystem.Application.Features.StudentAccounts.Commands;
using UniManagementSystem.Application.Features.StudentAccounts.Queries;

namespace UniManagementSystem.API.Controllers.v1.AdminAccounts
{
    public class AdminAccountController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAdminAccounts()
        {
            return Ok(await Mediator.Send(new GetAllAdminAccountQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdminAccount([FromBody] CreateAdminAccountCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.BadRequest)
                return BadRequest(result);

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdminAccount([FromBody] UpdateAdminAccountCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }

    }
}
