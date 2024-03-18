using Microsoft.EntityFrameworkCore;
using Reddit.Mapper;
using Reddit.Persistance;
using Reddit.Services.Community.Dtos;
using Reddit.Shared;

namespace Reddit.Services.Community;

public class CommunityService : ICommunityService
{
    private readonly ApplcationDBContext _context;
    private readonly IMapper _mapper;

    public CommunityService(ApplcationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PagingResult<CommunityDto>> GetCommunityListAsync(Query request)
    {
        var skip = request.PageIndex * request.PageSize;
        var take = request.PageSize;

        var query = _context.Community
            .Skip(skip)
            .Take(take);

        var data = await query
            .Include(x => x.User)
            .Select(x => new CommunityDto
            {
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
                UserId = x.UserId
            })
            .AsNoTracking()
            .ToListAsync();

        return new PagingResult<CommunityDto>(data, await query.CountAsync());
    }

    public async Task<CommunityDetailsDto> GetCommunityDetailsAsync(int id)
    {
        var data = await _context.Community
            .Where(x => x.Id == id)
            .Include(x => x.User)
            .Include(x => x.Posts)
            .Select(x => new CommunityDetailsDto
            {
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
                UserId = x.UserId,
                UserName = x.User.Name,
                Posts = x.Posts.Select(item => new PostDto
                {
                    AuthorId = item.AuthorId,
                    Content = item.Content,
                    CreateAt = item.CreateAt,
                    Downvotes = item.Downvotes,
                    Id = item.Id,
                    Title = item.Title,
                    UpdatedAt = item.UpdatedAt,
                    Upvotes = item.Upvotes
                })
            })
            .AsNoTracking()
            .FirstAsync();
        return data;
    }

    public async Task<CommunityDto> CreateCommunityAsync(CommunityModel model)
    {
        var community = _mapper.toCommunity(model);
        await _context.Community.AddAsync(community);
        await _context.SaveChangesAsync();
        return _mapper.toCommunityDetails(community);

    }

    public async Task<bool> DeleteCommunityAsync(int id)
    {
        var count = await _context.Community.Where(x => x.Id == id).ExecuteDeleteAsync();
        return count != 0;
    }

    public async Task<CommunityDto> UpdateCommunityAsync(int id, CommunityModel model)
    {
        var community = await _context.Community.FirstOrDefaultAsync(x => x.Id == id);
        community.UserId = model.UserId;
        community.Description = model.Description;
        community.Name = model.Name;
        await _context.SaveChangesAsync();
        return _mapper.toCommunityDetails(community);
    }
}