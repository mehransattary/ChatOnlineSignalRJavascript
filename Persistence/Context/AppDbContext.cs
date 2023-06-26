using Application.Interfaces.Contexts;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class AppDbContext : IdentityDbContext<User>, IDataBaseContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        SetShadowProperties.Configure(modelBuilder);
        ApplyConfiguration.ConfigureContext(modelBuilder);
        modelBuilder.SeedIdentityContext();
        modelBuilder.SeedContext();
        modelBuilder.DeleteBehavior_Restrict();
        modelBuilder.HasDefaultSchema("dbo");
        base.OnModelCreating(modelBuilder);


    }


    public override int SaveChanges()
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified ||
            p.State == EntityState.Added ||
            p.State == EntityState.Deleted
            );
        foreach (var item in modifiedEntries)
        {
            var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
            if (entityType != null)
            {
                var inserted = entityType.FindProperty("InsertTime");
                var updated = entityType.FindProperty("UpdateTime");
                var RemoveTime = entityType.FindProperty("RemoveTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");
                if (item.State == EntityState.Added && inserted != null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified && updated != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State = EntityState.Modified;
                }
            }

        }
        return base.SaveChanges();
    }

 
}
