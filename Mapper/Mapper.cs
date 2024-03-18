using Reddit.Dtos;
using Reddit.Models;
using Reddit.Services.Community.Dtos;
using Riok.Mapperly.Abstractions;

namespace Reddit.Mapper
{
    [Mapper]
    public partial class Mapper : IMapper
    {
        public partial Post toPost(CreatePostDto createPostDto);
        public partial Community toCommunity(CommunityModel createPostDto);
        public partial CommunityDto toCommunityDetails(Community createCommunityDto);
    }
}
