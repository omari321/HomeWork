namespace Reddit.Services.Community.Dtos;

public class CommunityDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int UserId { get; set; }
    public required DateTime CreatedDate { get; set; }
}