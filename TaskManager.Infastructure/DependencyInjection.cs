using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;
using TaskManager.Infastructure.RepositoryClasses;


namespace TaskManager.Infastructure
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this  IServiceCollection services)
        {
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<ITaskEntity, TaskEntityRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            return services;
        }
    }
}
