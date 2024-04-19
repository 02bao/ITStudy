using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;

namespace ITStudy.Repository;

public class PostsRepository(DataContext _context) : IPostRepository
{
    public bool CreateNewPosts(long TeacherId, Posts_Create Create)
    {
        var teacher = _context.Instructors.SingleOrDefault(s => s.Id == TeacherId);
        if (teacher == null) { return false; }
        Posts NewPost = new Posts()
        {
            Title = Create.Title,
            Content = Create.Content,
            PostTime = DateTime.UtcNow,
            Instructor = teacher,
        };
        _context.Posts.Add(NewPost);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(long Id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Posts> GetAll()
    {
        throw new NotImplementedException();
    }

    public Posts GetById(long Id)
    {
        throw new NotImplementedException();
    }

    public List<Posts> GetByTeacherId(long TeacherId)
    {
        throw new NotImplementedException();
    }

    public bool Update(Posts posts, List<IFormFile> Avatars)
    {
        throw new NotImplementedException();
    }
}
