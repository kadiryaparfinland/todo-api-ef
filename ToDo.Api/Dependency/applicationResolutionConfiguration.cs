using ToDo.Application.IService;
using ToDo.Api.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ToDo.Api.Dependency
{
    public static class ApplicationResolutionConfiguration
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<TokenHelper>();
            return services;
        }
    }
}
