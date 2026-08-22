using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Data;

/// <summary>
/// Використовується ТІЛЬКИ інструментами EF Core на design-time
/// (dotnet ef / Rider), коли startup-проєкт не має власного хоста
/// (напр. коли міграції запускаються зі startup-project = DataAccess).
/// У рантаймі застосунку не використовується — там контекст
/// налаштовується через DI в DependencyInjection.AddDataAccess().
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Design-time connection string. Збігається з docker-compose / appsettings.
        // Можна перекрити змінною середовища NFC_DB_CONNECTION.
        var connectionString =
            Environment.GetEnvironmentVariable("NFC_DB_CONNECTION")
            ?? "Host=localhost;Port=5432;Database=nfc_attendance;Username=postgres;Password=postgres";

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new AppDbContext(options);
    }
}
