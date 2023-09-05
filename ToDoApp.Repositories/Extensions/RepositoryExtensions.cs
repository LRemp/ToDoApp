using Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Repositories.Repositories;

namespace Repositories.Extensions;

public static class RepositoryExtensions
{
    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("mysql");

        services.AddTransient(_ => new MySqlConnection(connectionString));
        services.AddTransient<ITaskRepository, TaskRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}