using ITStudy.Models;

namespace ITStudy.DTO
{
    public class LecturesDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public string? Video { get; set; }
        public int Durations { get; set; } = 0;
    }

    public class Lectures_CreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public int Durations { get; set; } = 0;
    }
}
