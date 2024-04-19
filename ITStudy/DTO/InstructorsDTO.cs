using ITStudy.Models;

namespace ITStudy.DTO
{
    public class InstructorsDTO
    {
        public long Id { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public string? Avatars { get; set; }
        public long CoursesTaught { get; set; } = 0;
        public long Posts { get; set; } = 0;
    }
    public class Instructors_CreateDTO
    {
        public string TeacherName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
    }
}
