using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IFavoriteRepository
    {
        bool FollowTeacher (long StudentId,long TeacherId, Favorite_Create Teachers);
        bool FavoriteCourse(long StudentId, long CourseId, Favorite_Create Courses);
        ICollection<Favorite> GetAll();
        Favorite GetById(long Id);
        List<Favorite> GetByStudentId(long StudentId);
        bool Delete(long Id);
    }
}
