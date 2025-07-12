using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
   }
}
