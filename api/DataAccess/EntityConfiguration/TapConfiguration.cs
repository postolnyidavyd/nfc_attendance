using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class TapConfiguration : IEntityTypeConfiguration<Tap>
{
    public void Configure(EntityTypeBuilder<Tap> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);
        builder.HasOne(t => t.Room).WithMany().HasForeignKey(t => t.RoomId);
    }
}