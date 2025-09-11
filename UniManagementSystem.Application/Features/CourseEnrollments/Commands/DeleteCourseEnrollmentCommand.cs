using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.CourseEnrollments;
using UniManagementSystem.Data.DomainEntities;

namespace UniManagementSystem.Application.Features.CourseEnrollments.Commands
{
    public class DeleteCourseEnrollmentCommand : IRequest<BaseResponse<CourseEnrollment>>
    {
        public int courseEnrollmentId { get; set; }
    }

    public class DeleteCourseEnrollmentCommandHandler : IRequestHandler<DeleteCourseEnrollmentCommand, BaseResponse<CourseEnrollment>>
    {
        private readonly ICourseEnrollmentRepositoryAsync _courseEnrollmentRepositoryAsync;
        public DeleteCourseEnrollmentCommandHandler(ICourseEnrollmentRepositoryAsync _courseEnrollmentRepositoryAsync)
        {
            this._courseEnrollmentRepositoryAsync = _courseEnrollmentRepositoryAsync;
        }
        public async Task<BaseResponse<CourseEnrollment>> Handle(DeleteCourseEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var courseEnrollmentToRemove = new CourseEnrollment { Id = request.courseEnrollmentId };

            var response = await _courseEnrollmentRepositoryAsync.DeleteCourseEnrollment(courseEnrollmentToRemove);

            if (response.Id == 0)
            {
                return new BaseResponse<CourseEnrollment>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ResponseData = response,
                    ProblemErrors = new List<string>() { "Record not found" }

                };
            }

            return new BaseResponse<CourseEnrollment>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = false,
                Message = "Record successfully removed",
                ResponseData = response,
            };
        }
    }
}
