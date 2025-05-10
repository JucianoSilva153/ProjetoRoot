using Microsoft.Extensions.DependencyInjection;
using Root.Infrastructure.Service;

namespace Root.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        
        //outros servicos
        services.AddScoped<JwtTokenService>();
        
        return services;
    }
}