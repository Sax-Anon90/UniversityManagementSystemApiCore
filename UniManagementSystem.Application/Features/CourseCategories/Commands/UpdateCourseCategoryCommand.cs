using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Application.Common;
using UniManagementSystem.Application.RepositoryInterfaces.CourseCategories;
using UniManagementSystem.Application.RepositoryInterfaces.Roles;
using UniManagementSystem.Data.DomainEntities;
using UniManagementSystem.Data.DomainModels.InputModels.CourseCategories;
using UniManagementSystem.Data.DomainModels.InputModels.Courses;

namespace UniManagementSystem.Application.Features.CourseCategories.Commands
{
    public class UpdateCourseCategoryCommand : IRequest<BaseResponse<CourseCategory>>
    {
        public CourseCategoryUpdateModel CourseCategoryToUpdate { get; set; }
    }

    public class UpdateCourseCategoryCommandHandler : IRequestHandler<UpdateCourseCategoryCommand, BaseResponse<CourseCategory>>
    {
        private readonly ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync;
        public UpdateCourseCategoryCommandHandler(ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync)
        {
            this._courseCategoryRepositoryAsync = _courseCategoryRepositoryAsync;
        }
        public async Task<BaseResponse<CourseCategory>> Handle(UpdateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            var CourseCstegoryToUpdate = new CourseCategory()
            {
                Id = request.CourseCategoryToUpdate.Id,
                Name = request.CourseCategoryToUpdate.Name,
                IsActive = true
            };

            var response = await _courseCategoryRepositoryAsync.UpdateCourseCategoryAsync(CourseCstegoryToUpdate);

            if (response.Id == 0)
            {
                return new BaseResponse<CourseCategory>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ProblemErrors = new List<string>() { "Record not found" },
                    ResponseData = null
                };
            }

            return new BaseResponse<CourseCategory>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = true,
                Message = "Record updated successfully",
                ResponseData = response
            };
        }
    }
}
