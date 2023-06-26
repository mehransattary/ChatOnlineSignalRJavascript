using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace Application.Interfaces.Contexts;

public interface IDataBaseContext
{
    DbSet<ChatMessage> ChatMessages { get; set; }
    DbSet<Domain.ChatRoom> ChatRooms { get; set; }

    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    EntityEntry Entry([NotNullAttribute] object entity);
}
