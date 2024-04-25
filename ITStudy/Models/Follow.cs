namespace ITStudy.Models;

public class Follow
{
    public long Id { get; set; }
    public Student? Student { get; set; }
    public Instructors? Teacher { get; set; }
}
