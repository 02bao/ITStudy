namespace ITStudy.Models
{
    public class Reviews
    {
        public long Id { get; set; }
        public Student? Student { get; set; }
        public Courses? Course { get; set; }
        public string Comment { get; set; } = string.Empty;
        public float Rating { get; set; } = 0;
    }
}
