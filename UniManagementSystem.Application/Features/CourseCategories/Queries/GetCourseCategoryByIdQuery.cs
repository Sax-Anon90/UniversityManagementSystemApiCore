using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.CourseCategories;
using UniManagementSystem.Application.RepositoryInterfaces.Courses;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.ViewModels.CourseCategories;
using UniManagementSystem.Data.DomainModels.ViewModels.Courses;

namespace UniManagementSystem.Application.Features.CourseCategories.Queries
{
    public class GetCourseCategoryByIdQuery : IRequest<BaseResponse<CourseCategoryViewModel>>
    {
        public int CourseCategoryId { get; set; }
    }

    public class GetCourseCategoryByIdQueryHandler : IRequestHandler<GetCourseCategoryByIdQuery, BaseResponse<CourseCategoryViewModel>>
    {
        private readonly ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync;
        public GetCourseCategoryByIdQueryHandler(ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync)
        {
            this._courseCategoryRepositoryAsync = _courseCategoryRepositoryAsync;
        }
        public async Task<BaseResponse<CourseCategoryViewModel>> Handle(GetCourseCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var courseCategory = await _courseCategoryRepositoryAsync.GetCourseCategoryById(request.CourseCategoryId);

            if (courseCategory.Id == 0)
            {
                return new BaseResponse<CourseCategoryViewModel>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ResponseData = null
                };
            }

            return new BaseResponse<CourseCategoryViewModel>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Record retrieved successfully",
                ResponseData = courseCategory
            };
        }
    }
}
