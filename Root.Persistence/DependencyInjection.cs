using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Root.Persistence.Context;

namespace Root.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RootDbContext>(op =>
            op.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.Parse("10.4.32")));

        // Outros servicos...

        return services;
    }
}