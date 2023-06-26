using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplyConfiguration
{
    public static void ConfigureContext(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ChatRoomConfigure());
        modelBuilder.ApplyConfiguration(new ChatMessageConfigure());

    }
    public static void ConfigureIdentityContext(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IdentityUserLoginEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new IdentityUserRoleEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new IdentityUserTokenEntityTypeConfiguration());

    }
}
