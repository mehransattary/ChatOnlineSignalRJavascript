using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context;

public class ChatMessageConfigure : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.Property(x => x.MessageChat).IsRequired().HasMaxLength(1000);
        builder.Property(x => x.ChatRoomId).IsRequired();


        //builder.HasOne(a => a.FromUser).WithMany(b => b.ChatMessages).HasForeignKey(c => c.FromId);
        //builder.HasOne(a => a.ToUser).WithMany(b => b.ChatMessages).HasForeignKey(c => c.ToId);
        builder.HasOne(a => a.ChatRoom).WithMany(b => b.ChatMessages);

        builder.HasQueryFilter(x => EF.Property<bool>(x, "IsRemoved") == false);

    }
}

