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
using UniManagementSystem.Data.DomainModels.ViewModels.Courses;
using UniManagementSystem.Data.DomainModels.ViewModels.Roles;

namespace UniManagementSystem.Application.Features.Courses.Queries
{
    public class GetAllCoursesQuery : IRequest<BaseResponse<IEnumerable<CourseViewModel>>>
    {
    }

    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, BaseResponse<IEnumerable<CourseViewModel>>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;
        public GetAllCoursesQueryHandler(ICourseRepositoryAsync _courseRepositoryAsync)
        {
            this._courseRepositoryAsync = _courseRepositoryAsync;
        }
        public async Task<BaseResponse<IEnumerable<CourseViewModel>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepositoryAsync.GetAllCoursesAsync();

            if (courses.Any())
            {
                return new BaseResponse<IEnumerable<CourseViewModel>>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = "Course Records retrieved successfully",
                    ResponseData = courses
                };
            }

            return new BaseResponse<IEnumerable<CourseViewModel>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "No Course Records found",
                ResponseData = Enumerable.Empty<CourseViewModel>()
            };
        }
    }
}
