using DTOs.Tap;
using Microsoft.AspNetCore.Mvc;
using Services.TapService;

namespace api.Controllers;

[ApiController]
[Route("taps")]
public class TapsController : ControllerBase
{
    private readonly ITapService _tapService;

    public TapsController(ITapService tapService)
    {
        _tapService = tapService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TapRequest request, CancellationToken ct)
    {
        var result = await _tapService.AddRecordAsync(request, ct);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
