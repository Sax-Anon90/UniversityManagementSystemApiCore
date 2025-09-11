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
using UniManagementSystem.Data.DomainModels.InputModels.CourseEnrollements;

namespace UniManagementSystem.Application.Features.CourseEnrollments.Commands
{
    public class CreateCourseEnrollmentComand : IRequest<BaseResponse<CourseEnrollment>>
    {
        public CourseEnrollmentInputModel courseEnrollmentToCreate { get; set; }
    }

    public class CreateCourseEnrollmentComandHandler : IRequestHandler<CreateCourseEnrollmentComand, BaseResponse<CourseEnrollment>>
    {
        private readonly ICourseEnrollmentRepositoryAsync _courseEnrollmentRepositoryAsync;
        public CreateCourseEnrollmentComandHandler(ICourseEnrollmentRepositoryAsync _courseEnrollmentRepositoryAsync)
        {
            this._courseEnrollmentRepositoryAsync = _courseEnrollmentRepositoryAsync;
        }
        public async Task<BaseResponse<CourseEnrollment>> Handle(CreateCourseEnrollmentComand request, CancellationToken cancellationToken)
        {
            var courseEnrollmentToCreate = new CourseEnrollment()
            {
                StudentId = request.courseEnrollmentToCreate.StudentId,
                CourseId = request.courseEnrollmentToCreate.CourseId,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DateInactive = DateTime.UtcNow,
            };

            var createdCourseEnrollment = await _courseEnrollmentRepositoryAsync.CreateCourseEnrollment(courseEnrollmentToCreate);

            return new BaseResponse<CourseEnrollment>
            {
                StatusCode = (int)HttpStatusCode.Created,
                Succeeded = true,
                Message = "Record created successfully",
                ResponseData = createdCourseEnrollment
            };
        }
    }
}
