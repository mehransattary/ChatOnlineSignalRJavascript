using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context;

public static class ChangeNameUsers
{
    public static void ChangeName(this ModelBuilder builder)
    {
        builder.Entity<User>().ToTable("Users");
        builder.Entity<IdentityRole<string>>().ToTable("Roles").HasKey(r => r.Id);
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims" );
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
    }
}
