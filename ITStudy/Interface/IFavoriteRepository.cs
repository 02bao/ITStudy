using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IFavoriteRepository
    {
        bool FollowTeacher (long StudentId,long TeacherId, Favorite_Teacher Teachers);
    }
}
