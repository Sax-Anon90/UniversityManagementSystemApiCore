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

namespace UniManagementSystem.Application.Features.CourseCategories.Commands
{
    public class DeleteCourseCategoryCommand : IRequest<BaseResponse<CourseCategory>>
    {
        public int CourseCategoryId { get; set; }
    }

    public class DeleteCourseCategoryCommandHandler : IRequestHandler<DeleteCourseCategoryCommand, BaseResponse<CourseCategory>>
    {
        private readonly ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync;
        public DeleteCourseCategoryCommandHandler(ICourseCategoryRepositoryAsync _courseCategoryRepositoryAsync)
        {
            this._courseCategoryRepositoryAsync = _courseCategoryRepositoryAsync;
        }
        public async Task<BaseResponse<CourseCategory>> Handle(DeleteCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            var courseCategoryToRemove = new CourseCategory { Id = request.CourseCategoryId };

            var response = await _courseCategoryRepositoryAsync.DeleteCourseCategoryAsync(courseCategoryToRemove);

            if (response.Id == 0)
            {
                return new BaseResponse<CourseCategory>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Record not found",
                    ResponseData = response,
                    ProblemErrors = new List<string>() { "Record not found" }

                };
            }

            return new BaseResponse<CourseCategory>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Succeeded = false,
                Message = "Record successfully removed",
                ResponseData = response,
            };
        }
    }
}
