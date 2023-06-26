using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context;

public class AppIdentityDbContext : IdentityDbContext<User>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
         : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.SeedIdentityContext();
        builder.ChangeName();
        ApplyConfiguration.ConfigureIdentityContext(builder);
        builder.HasDefaultSchema("identity");

    }
}
