namespace DTOs.Tap;

public record TapResult(bool Success, TapRejectReason? Reason, string? Message, Guid? TapId);