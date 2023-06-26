using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseConfigure;

public static class DatabaseConfigurator
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(configuration.GetConnectionString("connection")),
    ServiceLifetime.Scoped);

        return services;
    }
}
