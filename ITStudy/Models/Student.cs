namespace ITStudy.Models;

public class Student
{
    public long Id { get; set; }
    public Users User { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
    public List<Courses> Courses { get; set; }

}

public class Student_Create
{
    public string StudentName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
}
