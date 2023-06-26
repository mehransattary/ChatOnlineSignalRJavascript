using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Microsoft.AspNetCore.Identity;
using Domain;

namespace Persistence.Context;



public class IdentityUserConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {

    }

}
