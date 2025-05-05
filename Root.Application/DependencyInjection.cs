using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Root.Application.Services;

namespace Root.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Outros servicos...

        services.AddTransient<ActivityService>();
        services.AddTransient<AdministratorService>();
        services.AddTransient<CategoryService>();
        services.AddTransient<ClientService>();
        services.AddTransient<GuideService>();
        services.AddTransient<PackageService>();
        services.AddTransient<PaymentService>();
        services.AddTransient<PostService>();
        services.AddTransient<ReserveService>();
        services.AddTransient<UserService>();
        return services;
    }
}