using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context;

public static class AppDbContextSeed
{
    public static void SeedContext(this ModelBuilder modelBuilder)
    {
    
    }

    public static void SeedIdentityContext(this ModelBuilder modelBuilder)
    {

        #region User
        User user = new User()
        {
            Email = "admin@gmail.com",
            UserName = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            NormalizedUserName = "ADMIN@GMAIL.COM"
        };

        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, "m1234M@mehran");
        modelBuilder.Entity<User>().HasData(user);
        IdentityRole role1 = new IdentityRole()
        {
            Name = "admin",
            NormalizedName = "ADMIN"
        };
        IdentityRole role2 = new IdentityRole()
        {
            Name = "user",
            NormalizedName = "USER"
        };
        modelBuilder.Entity<IdentityRole>().HasData(role1);
        modelBuilder.Entity<IdentityRole>().HasData(role2);

        IdentityUserRole<string> userRole = new IdentityUserRole<string>()
        {
            RoleId = role1.Id,
            UserId = user.Id
        };

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
        #endregion
    }
}
