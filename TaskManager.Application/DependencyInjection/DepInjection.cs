using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Application.Services;


namespace TaskManager.Application.DependencyInjection
{
   public static class DepInjection
   {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ITaskEntityService,TaskEntityService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
   }
}
