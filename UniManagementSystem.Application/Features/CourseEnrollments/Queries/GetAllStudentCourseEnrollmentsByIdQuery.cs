using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.CourseEnrollments;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseEnrollments;

namespace UniManagementSystem.Application.Features.CourseEnrollments.Queries
{
    public class GetAllStudentCourseEnrollmentsByIdQuery : IRequest<BaseResponse<IEnumerable<CourseEnrollmentViewModel>>>
    {
        public int studentAccountId { get; set; }
    }

    public class GetAllStudentCourseEnrollmentsByIdQueryHandler : IRequestHandler<GetAllStudentCourseEnrollmentsByIdQuery,
        BaseResponse<IEnumerable<CourseEnrollmentViewModel>>>
    {
        private readonly ICourseEnrollmentRepositoryAsync _courseEnrollmentRepositoryAsync;
        public GetAllStudentCourseEnrollmentsByIdQueryHandler(ICourseEnrollmentRepositoryAsync _courseEnrollmentRepositoryAsync)
        {
            this._courseEnrollmentRepositoryAsync = _courseEnrollmentRepositoryAsync;
        }
        public async Task<BaseResponse<IEnumerable<CourseEnrollmentViewModel>>> Handle(GetAllStudentCourseEnrollmentsByIdQuery request, CancellationToken cancellationToken)
        {
            var courseEnrollments = await _courseEnrollmentRepositoryAsync.GetAllStudentCourseEnrollmentsByStudentIdAsync(request.studentAccountId);

            if (courseEnrollments.Any())
            {
                return new BaseResponse<IEnumerable<CourseEnrollmentViewModel>>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = $"Records retrieved successfully",
                    ResponseData = courseEnrollments
                };
            }

            return new BaseResponse<IEnumerable<CourseEnrollmentViewModel>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = $"Student is not enrolled in any course",
                ResponseData = Enumerable.Empty<CourseEnrollmentViewModel>()
            };
        }
    }
}
