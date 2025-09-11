using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniManagementSystem.Persistence.UniDbContext;

namespace UniManagementSystem.Persistence.ServiceRegistrations
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UniManagementSystemDbContext>(options =>
             options.UseSqlite($"Data Source={Path.Combine(AppContext.BaseDirectory, "appdata/UniManagementSystem.db")}"));
            return services;
        }
    }
}
