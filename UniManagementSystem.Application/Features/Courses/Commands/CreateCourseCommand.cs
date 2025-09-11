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
    public class CreateCourseCommand : IRequest<BaseResponse<Course>>
    {
        public CourseInputModel courseToCreate { get; set; }
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, BaseResponse<Course>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;
        public CreateCourseCommandHandler(ICourseRepositoryAsync _courseRepositoryAsync)
        {
            this._courseRepositoryAsync = _courseRepositoryAsync;
        }
        public async Task<BaseResponse<Course>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var CouseToAdd = new Course()
            {
                Name = request.courseToCreate.Name,
                CourseCategoryId = request.courseToCreate.CourseCategoryId,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DateInactive = DateTime.UtcNow,
            };

            var createdRole = await _courseRepositoryAsync.CreateCourseAsync(CouseToAdd);

            return new BaseResponse<Course>
            {
                StatusCode = (int)HttpStatusCode.Created,
                Succeeded = true,
                Message = "Record created successfully",
                ResponseData = CouseToAdd
            };
        }
    }
}
