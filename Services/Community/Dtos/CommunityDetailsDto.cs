namespace Reddit.Services.Community.Dtos;


public class CommunityDetailsDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int UserId { get; set; }
    public required string UserName { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required IEnumerable<PostDto> Posts { get; set; }
}