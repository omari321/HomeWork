using Reddit.Services.Community.Dtos;
using Reddit.Shared;

namespace Reddit.Services.Community;

public interface ICommunityService
{
    Task<PagingResult<CommunityDto>> GetCommunityListAsync(Query request);
    Task<CommunityDetailsDto> GetCommunityDetailsAsync(int id);
    Task<CommunityDto> CreateCommunityAsync(CommunityModel model);
    Task<bool> DeleteCommunityAsync(int id);
    Task<CommunityDto> UpdateCommunityAsync(int id, CommunityModel model);
}