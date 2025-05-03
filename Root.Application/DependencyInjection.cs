using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Root.Application.Services;

namespace Root.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Outros servicos...

        services.AddTransient<UserService>();
        return services;
    }
}