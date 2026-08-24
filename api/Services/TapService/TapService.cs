using DataAccess.Data;
using Domain.Models;
using DTOs.Tap;
using Microsoft.EntityFrameworkCore;

namespace Services.TapService;

public class TapService : ITapService
{
    private readonly AppDbContext _appDbContext;

    public TapService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<TapResult> AddRecordAsync(TapRequest request, CancellationToken ct)
    {
        var roomExists = await _appDbContext.Rooms
            .AnyAsync(r => r.Id == request.RoomId, ct);
        if (!roomExists)
            return new TapResult(false, "Кімнати не існує", null);

        var userExists = await _appDbContext.Users
            .AnyAsync(u => u.Id == request.UserId, ct);
        if (!userExists)
            return new TapResult(false, "Користувача не існує", null);

        var newTap = new Tap
        {
            CreatedAt = DateTimeOffset.UtcNow,
            RoomId = request.RoomId,
            UserId = request.UserId
        };

        _appDbContext.Taps.Add(newTap);
        await _appDbContext.SaveChangesAsync(ct);

        return new TapResult(true, null, newTap.Id);
    }

    public async Task<TapListDto> GetByRoomAsync(string roomCode, CancellationToken ct)
    {
        var room = await _appDbContext.Rooms
            .FirstOrDefaultAsync(r => r.Code == roomCode, ct);

        if (room is null)
            return new TapListDto([]);

        var taps = await _appDbContext.Taps
            .Where(t => t.RoomId == room.Id)
            .OrderByDescending(t => t.CreatedAt)
            .Select(t => new TapDto(t.Id, t.RoomId, t.UserId))
            .ToListAsync(ct);

        return new TapListDto(taps);
    }
}