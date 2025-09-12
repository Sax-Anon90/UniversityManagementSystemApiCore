using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.Courses;
using UniManagementSystem.Data.DomainModels.ViewModels.Courses;

namespace UniManagementSystem.Application.Features.Courses.Queries
{
    public class GetCourseByIdQuery : IRequest<BaseResponse<CourseViewModel>>
    {
        public int courseId { get; set; }
    }

    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, BaseResponse<CourseViewModel>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;
        public GetCourseByIdQueryHandler(ICourseRepositoryAsync _courseRepositoryAsync)
        {
            this._courseRepositoryAsync = _courseRepositoryAsync;
        }
        public async Task<BaseResponse<CourseViewModel>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepositoryAsync.GetCourseByIdAsync(request.courseId);

            if (course.Id == 0)
            {
                return new BaseResponse<CourseViewModel>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ResponseData = null
                };
            }

            return new BaseResponse<CourseViewModel>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Record retrieved successfully",
                ResponseData = course
            };
        }
    }
}
