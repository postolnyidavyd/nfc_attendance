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

        // Покриває дедуплікацію в AddRecordAsync (RoomId + UserId + CreatedAt)
        // і фільтр за кімнатою в GetByRoomAsync (RoomId - провідна колонка).
        builder.HasIndex(t => new { t.RoomId, t.UserId, t.CreatedAt });
    }
}