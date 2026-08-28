namespace DTOs.Tap;

public record TapDto(Guid Id, string FullName, string GroupName, DateTimeOffset CreatedAt);