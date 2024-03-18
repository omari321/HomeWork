using Reddit.Dtos;
using Reddit.Models;
using Reddit.Services.Community.Dtos;

namespace Reddit.Mapper
{
    public interface IMapper
    {
        public Post toPost(CreatePostDto createPostDto);
        public Community toCommunity(CommunityModel createPostDto);
        public CommunityDto toCommunityDetails(Community createCommunityDto);
    }
}
