using ToDo.Application.IService;
using ToDo.Application.Service;
using ToDo.Domain.IEntity;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Application.Dependency
{
    public static class ServiceResolutionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUserService>();
            services.AddScoped<ITODOService, TODOService>();
            return services;
        }
    }
}
