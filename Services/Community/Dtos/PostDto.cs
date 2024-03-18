namespace Reddit.Services.Community.Dtos;

public class PostDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required int? AuthorId { get; set; }
    public required int Upvotes { get; set; }
    public required int Downvotes { get; set; }
    public required DateTime CreateAt { get; set; }
    public required DateTime? UpdatedAt { get; set; }
}