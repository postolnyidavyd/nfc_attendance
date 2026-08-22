using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Code).HasMaxLength(16).IsRequired();
        builder.HasIndex(r => r.Code).IsUnique();
    }
}