using DTOs.Tap;

namespace Services.TapService;

public interface ITapService
{
    Task<TapResult> AddRecordAsync(TapRequest request, CancellationToken ct);
    Task<TapListDto> GetByRoomAsync(string roomCode, CancellationToken ct);
}