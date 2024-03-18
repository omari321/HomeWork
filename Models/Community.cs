using Microsoft.EntityFrameworkCore;

namespace Reddit.Models;


[Owned]
public class Community
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public virtual ICollection<Post> Posts { get; set; }
}