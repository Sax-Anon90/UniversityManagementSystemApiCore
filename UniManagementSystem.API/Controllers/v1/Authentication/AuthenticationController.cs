using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniManagementSystem.API.Controllers.v1.BaseApiController;
using UniManagementSystem.Application.Features.Authentication.Commands;

namespace UniManagementSystem.API.Controllers.v1.Authentication
{
    public class AuthenticationController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }
    }
}
