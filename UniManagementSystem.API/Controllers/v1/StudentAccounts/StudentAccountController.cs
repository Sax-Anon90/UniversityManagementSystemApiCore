using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniManagementSystem.API.Controllers.v1.BaseApiController;
using UniManagementSystem.Application.Features.StudentAccounts.Commands;
using UniManagementSystem.Application.Features.StudentAccounts.Queries;
using UniManagementSystem.Data.DomainEntities;


namespace UniManagementSystem.API.Controllers.v1.StudentAccounts
{
    public class StudentAccountController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStudentAccounts()
        {
            return Ok(await Mediator.Send(new GetAllStudentAccountsQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentAccountById(int studentAccountId)
        {
            var response = await Mediator.Send(new GetStudentAccountByIdQuery { StudentId = studentAccountId });

            if (response.StatusCode == (int)HttpStatusCode.NotFound)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudentAccount([FromBody] RegisterStudentAccountCommand command)
        {
                var result = await Mediator.Send(command);

                if (result.StatusCode == (int)HttpStatusCode.BadRequest)
                    return BadRequest(result);

                return StatusCode((int)HttpStatusCode.Created, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAccount([FromBody] UpdateStudentAccountCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentAccount([FromBody] DeleteStudentAccountCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }

    }
}
