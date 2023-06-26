using Domain;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context;


public class SetShadowProperties
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
            }
        }
    }
}
