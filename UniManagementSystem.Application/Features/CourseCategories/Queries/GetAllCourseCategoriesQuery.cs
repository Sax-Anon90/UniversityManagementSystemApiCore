using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.CourseCategories;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseCategories;
using UniManagementSystem.Data.DomainModels.ViewModels.Roles;

namespace UniManagementSystem.Application.Features.CourseCategories.Queries
{
    public class GetAllCourseCategoriesQuery : IRequest<BaseResponse<IEnumerable<CourseCategoryViewModel>>>
    {
    }

    public class GetAllCourseCategoriesQueryHandler : IRequestHandler<GetAllCourseCategoriesQuery, BaseResponse<IEnumerable<CourseCategoryViewModel>>>
    {
        private readonly ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync;
        public GetAllCourseCategoriesQueryHandler(ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync)
        {
            this._courseCategoryRepositoryAsync = _courseCategoryRepositoryAsync;
        }
        public async Task<BaseResponse<IEnumerable<CourseCategoryViewModel>>> Handle(GetAllCourseCategoriesQuery request, CancellationToken cancellationToken)
        {
            var courseCategories = await _courseCategoryRepositoryAsync.GetAllCourseCategoriesAsync();

            if (courseCategories.Any())
            {
                return new BaseResponse<IEnumerable<CourseCategoryViewModel>>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Message = "Role Records retrieved successfully",
                    ResponseData = courseCategories
                };
            }

            return new BaseResponse<IEnumerable<CourseCategoryViewModel>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "No Role Records found",
                ResponseData = Enumerable.Empty<CourseCategoryViewModel>()
            };
        }
    }
}
