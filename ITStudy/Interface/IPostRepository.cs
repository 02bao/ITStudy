using ITStudy.Models;

namespace ITStudy.Interface;

public interface IPostRepository
{
    bool CreateNewPosts(long TeacherId, Posts_Create Create);
    ICollection<Posts> GetAll();
    Posts GetById(long Id);
    List<Posts> GetByTeacherId(long TeacherId);
    bool Update(Posts posts, List<IFormFile> Avatars);
    bool Delete(long Id);
}
