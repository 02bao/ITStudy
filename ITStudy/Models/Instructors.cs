namespace ITStudy.Models
{
    public class Instructors
    {
        public long Id { get; set; }
        public Users User { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public string? Images { get; set; } 
        public long CoursesTaught { get; set; } = 0;
        public long Posts { get; set; } = 0;
    }

    public class Instructors_Create
    {
        public string TeacherName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
    }
}
