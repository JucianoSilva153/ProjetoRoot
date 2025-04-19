using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Root.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // Outros servicos...

        return services;
    }
}