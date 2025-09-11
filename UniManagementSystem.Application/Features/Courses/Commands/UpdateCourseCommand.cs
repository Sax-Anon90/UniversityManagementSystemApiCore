using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.Courses;
using UniManagementSystem.Application.RepositoryInterfaces.Roles;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.Courses;

namespace UniManagementSystem.Application.Features.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<BaseResponse<Course>>
    {
        public CourseUpdateModel courseToUpdate { get; set; }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, BaseResponse<Course>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;
        public UpdateCourseCommandHandler(ICourseRepositoryAsync _courseRepositoryAsync)
        {
            this._courseRepositoryAsync = _courseRepositoryAsync;
        }
        public async Task<BaseResponse<Course>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var CourseToUpdate = new Course()
            {
                Id = request.courseToUpdate.Id,
                Name = request.courseToUpdate.Name,
                CourseCategoryId = request.courseToUpdate.CourseCategoryId,
                IsActive = true
            };

            var response = await _courseRepositoryAsync.UpdateCourseAsync(CourseToUpdate);

            if (response.Id == 0)
            {
                return new BaseResponse<Course>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ProblemErrors = new List<string>() { "Record not found" },
                    ResponseData = null
                };
            }

            return new BaseResponse<Course>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Record updated successfully",
                ResponseData = response
            };
        }
    }
}
