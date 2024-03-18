namespace Reddit.Services.Community.Dtos;

public class CommunityModel
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int UserId { get; set; }
}