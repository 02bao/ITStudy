namespace ITStudy.Models;

public class Posts
{
    public long Id { get; set; }
    public Instructors Instructor { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Avatar { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime PostTime { get; set; } = DateTime.UtcNow;
    public int Likes { get; set; } = 0;
    public int Dislikes { get; set; } = 0;
}
public class Posts_Create
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime PostTime { get; set; } = DateTime.UtcNow;
  
}
