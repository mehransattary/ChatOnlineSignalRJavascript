using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context;

public class ChatRoomConfigure : IEntityTypeConfiguration<ChatRoom>
{
    public void Configure(EntityTypeBuilder<ChatRoom> builder)
    {
        builder.Property(x => x.UserId).IsRequired();
        builder.HasMany(x => x.ChatMessages).WithOne(x=>x.ChatRoom);
        builder.HasQueryFilter(x => EF.Property<bool>(x, "IsRemoved") == false);

    }
}

