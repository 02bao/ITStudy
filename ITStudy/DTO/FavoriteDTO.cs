using ITStudy.Models;

namespace ITStudy.DTO
{
    public class FavoriteDTO
    {
        public long Id { get; set; }
        public bool IsReal { get; set; } = false; //true la da thic, false la chua
        public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
    }
}
