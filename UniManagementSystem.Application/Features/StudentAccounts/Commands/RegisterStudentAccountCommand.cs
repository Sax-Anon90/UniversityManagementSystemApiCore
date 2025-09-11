using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.StudentAccounts;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.StudentAccounts;

namespace UniManagementSystem.Application.Features.StudentAccounts.Commands
{
    public class RegisterStudentAccountCommand : IRequest<BaseResponse<StudentAccount>>
    {
        public StudentAccountInputModel studentAccountToCreate { get; set; }
    }

    public class RegisterStudentAccountCommandHandler : IRequestHandler<RegisterStudentAccountCommand, BaseResponse<StudentAccount>>
    {
        private readonly IStudentAccountRepositoryAsync _studentAccountRepositoryAsync;
        public RegisterStudentAccountCommandHandler()
        {
            
        }
        public Task<BaseResponse<StudentAccount>> Handle(RegisterStudentAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
