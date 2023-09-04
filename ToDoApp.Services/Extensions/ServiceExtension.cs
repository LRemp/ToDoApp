using Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Mappers;
using Services.Services;

namespace Services.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(UserMappingProfile));
        services.AddTransient<IJwtTokenService, JwtTokenService>();
        services.AddTransient<ITaskService, TaskService>();
    }
}