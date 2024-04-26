using ITStudy.Models;

namespace ITStudy.DTO
{
    public class FavoriteDTO
    {
        public long Id { get; set; }
        public bool IsReal { get; set; } = false; //true la da thic, false la chua
        public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
        public Status_Favorite Status { get; set; } = Status_Favorite.None;
    }
    public class Favorite_TeacherDTO
    {
        public bool IsReal { get; set; } = false; //true la da thic, false la chua
        public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
        public Status_Favorite Status { get; set; } = Status_Favorite.None;
    }
}
