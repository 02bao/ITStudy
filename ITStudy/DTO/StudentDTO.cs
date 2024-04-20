using ITStudy.Models;

namespace ITStudy.DTO;
public class StudentDTO
{
    public long Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;

}

public class Student_CreateDTO
{
    public string StudentName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
}