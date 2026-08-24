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

        builder.HasData(
            new Room { Id = new Guid("11111111-1111-1111-1111-000000000201"), Code = "201", Name = "Аудиторія 201" },
            new Room { Id = new Guid("11111111-1111-1111-1111-000000000303"), Code = "303", Name = "Аудиторія 303" },
            new Room { Id = new Guid("11111111-1111-1111-1111-000000000105"), Code = "105", Name = "Лабораторія 105" },
            new Room { Id = new Guid("11111111-1111-1111-1111-000000000402"), Code = "402", Name = "Аудиторія 402" });
    }
}