using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasData(
            new User { Id = new Guid("22222222-2222-2222-2222-000000000001"), FullName = "Іван Петренко", GroupName = "КН-21" },
            new User { Id = new Guid("22222222-2222-2222-2222-000000000002"), FullName = "Марія Коваленко", GroupName = "КН-21" },
            new User { Id = new Guid("22222222-2222-2222-2222-000000000003"), FullName = "Олег Шевчук", GroupName = "ІПЗ-22" },
            new User { Id = new Guid("22222222-2222-2222-2222-000000000004"), FullName = "Софія Бондаренко", GroupName = "ІПЗ-22" },
            new User { Id = new Guid("22222222-2222-2222-2222-000000000005"), FullName = "Андрій Мельник", GroupName = "КБ-23" },
            new User { Id = new Guid("22222222-2222-2222-2222-000000000006"), FullName = "Наталія Ткаченко", GroupName = "КБ-23" });
    }
}