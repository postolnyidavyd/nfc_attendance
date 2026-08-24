namespace DTOs.Tap;

public record TapResult(bool Success, string? RejectReason, Guid? TapId);