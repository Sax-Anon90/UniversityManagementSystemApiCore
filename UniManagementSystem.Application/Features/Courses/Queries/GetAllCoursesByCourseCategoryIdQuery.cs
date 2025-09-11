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
    public class GetAllCoursesByCourseCategoryIdQuery : IRequest<BaseResponse<IEnumerable<CourseViewModel>>>
    {
        public int CourseCategoryId { get; set; }
    }

    public class GetAllCoursesByCourseCategoryIdQueryHandler : IRequestHandler<GetAllCoursesByCourseCategoryIdQuery,
        BaseResponse<IEnumerable<CourseViewModel>>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;
        public GetAllCoursesByCourseCategoryIdQueryHandler(ICourseRepositoryAsync _courseRepositoryAsync)
        {
            this._courseRepositoryAsync = _courseRepositoryAsync;
        }
        public async Task<BaseResponse<IEnumerable<CourseViewModel>>> Handle(GetAllCoursesByCourseCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepositoryAsync.GetAllCoursesByCourseCategoryId(request.CourseCategoryId);

            if (courses.Any())
            {
                return new BaseResponse<IEnumerable<CourseViewModel>>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = "Records retrieved successfully",
                    ResponseData = courses
                };
            }

            return new BaseResponse<IEnumerable<CourseViewModel>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "No records found",
                ResponseData = Enumerable.Empty<CourseViewModel>()
            };

        }
    }
}
