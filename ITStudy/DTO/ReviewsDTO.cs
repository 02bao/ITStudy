using ITStudy.Models;

namespace ITStudy.DTO;

public class ReviewsDTO
{
        public long Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public float Rating { get; set; } = 0;
        public DateTime? PostedAt { get; set; } = DateTime.UtcNow;
}
