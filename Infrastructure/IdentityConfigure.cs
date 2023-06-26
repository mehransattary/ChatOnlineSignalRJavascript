
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;


namespace Infrastructure.IdentityConfigs;

public static class IdentityConfigure
{
    public static IServiceCollection AddIdentitySerivce(this IServiceCollection services, IConfiguration configuration)
    {

        string connection = configuration.GetConnectionString("connection");

        services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connection));


        services.AddIdentity<User, IdentityRole>()
      .AddEntityFrameworkStores<AppDbContext>();

        //services.AddIdentity<User, IdentityRole>()
        //.AddEntityFrameworkStores<AppDbContext>()
        //.AddDefaultTokenProviders()
        //.AddRoles<IdentityRole>()
        //.AddErrorDescriber<CustomIdentityError>();


        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 4;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;

            options.User.RequireUniqueEmail = false;

            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(365);
        });

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/RegisterDisposable"; // تنظیم مسیر URL برای صفحه ورود
        });


        return services;
    }
}
