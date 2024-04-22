using ITStudy.Models;

namespace ITStudy.DTO
{
    public class BuyCoursesDTO
    {
        public long Id { get; set; }
        public DateTime? PurchasedTime { get; set; } = DateTime.UtcNow;
        public string CourseName { get; set; } = string.Empty;
        public long PriceCourse { get; set; } = 0;
        public long TotalAmount { get; set; } = 0;
        public Status_Buy Status { get; set; } = Status_Buy.pending;
    }
}
