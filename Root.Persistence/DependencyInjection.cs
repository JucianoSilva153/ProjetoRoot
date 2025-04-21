using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Root.Domain.Interfaces;
using Root.Persistence.Context;
using Root.Persistence.Repositories;

namespace Root.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RootDbContext>(op =>
            op.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.Parse("10.4.32")));

        // other services...
        services.AddTransient<IActivityRepository, ActivityRepository>();
        services.AddTransient<IAdministratorRepository, AdministratorRepository>();
        services.AddTransient<ICategoryRepository, ICategoryRepository>();
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IGuideRepository, GuideRepository>();
        services.AddTransient<IPackageRepository, PackageRepository>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();
        services.AddTransient<IPostRepository, PostRepository>();
        services.AddTransient<IReserveRepository, ReserveRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}