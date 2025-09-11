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

namespace UniManagementSystem.Application.Features.CourseCategories.Commands
{
    public class CreateCourseCategoryCommand : IRequest<BaseResponse<CourseCategory>>
    {
        public CourseCategoryInputModel courseCategoryToCreate { get; set; }
    }

    public class CreateCourseCategoryCommandHandler : IRequestHandler<CreateCourseCategoryCommand, BaseResponse<CourseCategory>>
    {
        private readonly ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync;
        public CreateCourseCategoryCommandHandler(ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync)
        {
            this._courseCategoryRepositoryAsync = _courseCategoryRepositoryAsync;
        }
        public async Task<BaseResponse<CourseCategory>> Handle(CreateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            var CourseCategoryToAdd = new CourseCategory()
            {
                Name = request.courseCategoryToCreate.Name,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DateInactive = DateTime.UtcNow,
            };

            var createdRole = await _courseCategoryRepositoryAsync.CreateCourseCategoryAsync(CourseCategoryToAdd);

            return new BaseResponse<CourseCategory>
            {
                StatusCode = (int)HttpStatusCode.Created,
                Succeeded = true,
                Message = "Record created successfully",
                ResponseData = createdRole
            };
        }
    }
}
