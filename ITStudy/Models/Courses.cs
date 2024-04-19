namespace ITStudy.Models;

public class Courses
{
    public long Id { get; set; }
    public Category Category { get; set; }
    public Instructors Teacher { get; set; }
    public List<Lectures> Lectures { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Descriptions { get; set; } = string.Empty;
    public string? Picture { get; set; }
    public long Price { get; set; } = 0;
    public int Durations { get; set; } =0;
    public float Rating { get; set; } = 0;
    public int? LectureCount { get; set; } = 0;
    public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
}

public class Courses_Create
{
    public string Title { get; set; } = string.Empty;
    public string Descriptions { get; set; } = string.Empty;
    public long Price { get; set; } = 0;
    public int Durations { get; set; } = 0;
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
