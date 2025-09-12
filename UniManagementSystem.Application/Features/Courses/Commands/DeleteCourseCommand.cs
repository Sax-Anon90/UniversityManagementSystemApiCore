using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.CourseEnrollments;
using UniManagementSystem.Application.RepositoryInterfaces.Courses;
using UniManagementSystem.Data.DomainEntities;

namespace UniManagementSystem.Application.Features.Courses.Commands
{
    public class DeleteCourseCommand : IRequest<BaseResponse<Course>>
    {
        public int CourseId { get; set; }
    }

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, BaseResponse<Course>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;
        public DeleteCourseCommandHandler(ICourseRepositoryAsync _courseRepositoryAsync)
        {
            this._courseRepositoryAsync = _courseRepositoryAsync;
        }
        public async Task<BaseResponse<Course>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var courseToRemove = new Course { Id = request.CourseId };

            var response = await _courseRepositoryAsync.DeleteCourseAsync(courseToRemove);

            if (response.Id == 0)
            {
                return new BaseResponse<Course>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ResponseData = response,
                    ProblemErrors = new List<string>() { "Record not found" }

                };
            }

            return new BaseResponse<Course>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = false,
                Message = "Record successfully removed",
                ResponseData = response,
            };
        }
    }
}
