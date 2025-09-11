using Microsoft.OpenApi.Models;

namespace UniManagementSystem.API.Extensions
{
    public static class BearerTokenSwaggerExtension
    {
        public static IServiceCollection AddBearerTokenSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Simple University Management System Api Core",
                    Description = "Simple University Management System to deal with Student Course Enrollments",
                   
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });

            });
            return services;
        }
    }
}
