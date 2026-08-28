using DataAccess.Data;
using Domain.Models;
using DTOs.Tap;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services.Options;

namespace Services.TapService;

public class TapService : ITapService
{
    private readonly AppDbContext _appDbContext;
    private readonly TapOptions _options;

    public TapService(AppDbContext appDbContext, IOptions<TapOptions> options)
    {
        _appDbContext = appDbContext;
        _options = options.Value;
    }

    public async Task<TapResult> AddRecordAsync(TapRequest request, CancellationToken ct)
    {
        var room = await _appDbContext.Rooms
            .FirstOrDefaultAsync(r => r.Code == request.RoomCode, ct);
        if (room is null)
            return new TapResult(false, "Кімнати не існує", null);

        var userExists = await _appDbContext.Users
            .AnyAsync(u => u.Id == request.UserId, ct);
        if (!userExists)
            return new TapResult(false, "Користувача не існує", null);

        var since = DateTimeOffset.UtcNow.AddMinutes(-_options.DuplicateWindowMinutes);
        var alreadyTapped = await _appDbContext.Taps
            .AnyAsync(t => t.RoomId == room.Id
                        && t.UserId == request.UserId
                        && t.CreatedAt >= since, ct);
        if (alreadyTapped)
            return new TapResult(false, "Ви вже відмітились у цій кімнаті", null);

        var newTap = new Tap
        {
            CreatedAt = DateTimeOffset.UtcNow,
            RoomId = room.Id,
            UserId = request.UserId
        };

        _appDbContext.Taps.Add(newTap);
        await _appDbContext.SaveChangesAsync(ct);

        return new TapResult(true, null, newTap.Id);
    }

    public async Task<TapListDto?> GetByRoomAsync(string roomCode, CancellationToken ct)
    {
        var room = await _appDbContext.Rooms
            .FirstOrDefaultAsync(r => r.Code == roomCode, ct);

        if (room is null)
            return null;

        var taps = await _appDbContext.Taps
            .Where(t => t.RoomId == room.Id)
            .OrderByDescending(t => t.CreatedAt)
            .Select(t => new TapDto(t.Id, t.User.FullName, t.User.GroupName, t.CreatedAt))
            .ToListAsync(ct);

        return new TapListDto(taps);
    }
}