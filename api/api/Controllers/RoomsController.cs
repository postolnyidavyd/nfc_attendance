using Microsoft.AspNetCore.Mvc;
using Services.TapService;

namespace api.Controllers;

[ApiController]
[Route("rooms")]
public class RoomsController : ControllerBase
{
    private readonly ITapService _tapService;

    public RoomsController(ITapService tapService)
    {
        _tapService = tapService;
    }

    [HttpGet("{code}/taps")]
    public async Task<IActionResult> GetTaps(string code, CancellationToken ct)
    {
        var taps = await _tapService.GetByRoomAsync(code, ct);

        if (taps is null)
            return NotFound();

        return Ok(taps);
    }
}
