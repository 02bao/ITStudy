using ITStudy.Models;

namespace ITStudy.DTO
{
    public class PostsDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? CommentCount { get; set; } = 0;
        public string? Avatar { get; set; }
        public DateTime? PostTime { get; set; } = DateTime.UtcNow;
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
    }
    public class Posts_CreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PostTime { get; set; } = DateTime.UtcNow;

    }
}
