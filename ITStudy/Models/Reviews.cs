namespace ITStudy.Models
{
    public class Reviews
    {
        public long Id { get; set; }
        public Student? Student { get; set; }
        public Courses? Course { get; set; }
        public CartItem? CartItem { get; set; }
        public string Comment { get; set; } = string.Empty;
        public float Rating { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public int Share { get; set; } = 0;
        public DateTime? PostedAt { get; set; } = DateTime.UtcNow;
    }

    public class Reviews_Create
    {
        public string Comment { get; set; } = string.Empty;
        public float Rating { get; set; } = 0;
        public DateTime? PostedAt { get; set; } = DateTime.UtcNow;
    }
}
