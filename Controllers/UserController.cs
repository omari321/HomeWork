using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reddit.Dtos;
using Reddit.Models;
using Reddit.Persistance;

namespace Reddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplcationDBContext _context;

        public UserController(ApplcationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateUserDto createAuthorDto)
        {
            var author = new User
            {
                Name = createAuthorDto.Name
            };

            await _context.Users.AddAsync(author);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAuthors()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("{userId:int}/community{communityId:int}")]
        public async Task<IActionResult> JoinCommunityAsync([FromRoute] int userId, int communityId)
        {
            var user = await _context.Users.FirstAsync(x => x.Id == userId);
            var community = await _context.Community.FirstAsync(x => x.Id == communityId);
            user.Communities.Add(community);
            return NoContent();
        }

    }
}