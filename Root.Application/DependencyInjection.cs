using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Root.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Outros servicos...

        return services;
    }
}