namespace Reddit.Entities
{
    public class Community  // SubReddit
    {
        public int CommunityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<Post> Posts { get; set; }
    }

}
