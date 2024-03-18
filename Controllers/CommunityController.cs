using Microsoft.AspNetCore.Mvc;
using Reddit.Services.Community;
using Reddit.Services.Community.Dtos;
using Reddit.Shared;

namespace Reddit.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CommunityController : ControllerBase
{
    private readonly ICommunityService _communityService;

    public CommunityController(ICommunityService communityService)
    {
        _communityService = communityService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CommunityDetailsDto>> GetCommunityAsync([FromRoute] int id)
    {
        return Ok(await _communityService.GetCommunityDetailsAsync(id));
    }
    [HttpGet]
    public async Task<ActionResult<PagingResult<CommunityDto>>> GetCommunityListAsync([FromQuery] Query query)
    {
        return Ok(await _communityService.GetCommunityListAsync(query));
    }
    [HttpPost]
    public async Task<ActionResult<CommunityDto>> CreateCommunityAsync([FromBody] CommunityModel model)
    {
        return Ok(await _communityService.CreateCommunityAsync(model));
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteCommunityAsync([FromRoute] int id)
    {
        return Ok(await _communityService.DeleteCommunityAsync(id));
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<CommunityDto>> UpdateCommunity([FromRoute] int id, [FromBody] CommunityModel model)
    {
        return Ok(await _communityService.UpdateCommunityAsync(id, model));
    }

}