using Application;
using Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IGreetingRepository, InMemoryGreetingRepository>();
        services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        
        return services;
    }
}
