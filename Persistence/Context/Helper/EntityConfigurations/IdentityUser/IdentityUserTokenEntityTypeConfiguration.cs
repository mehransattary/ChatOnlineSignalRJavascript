using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Context;



public class IdentityUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
{

    public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
    {
        builder.HasKey(p => new { p.UserId, p.LoginProvider, p.Name });

    }

}
