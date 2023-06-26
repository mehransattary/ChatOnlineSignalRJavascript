using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Context;



public class IdentityUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{

    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {

        builder.HasKey(p => new { p.UserId, p.RoleId });

    }

}
