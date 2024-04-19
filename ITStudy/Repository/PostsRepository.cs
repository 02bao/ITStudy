using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.EntityFrameworkCore;

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
        teacher.Posts += 1;
        _context.SaveChanges();
        return true;
    }

    public bool Delete(long Id)
    {
        var post = _context.Posts.Include(s => s.Instructor).Where( s => s.Id == Id).SingleOrDefault();
        if (post == null) { return false; }
        _context.Posts.Remove(post);
        post.Instructor.Posts -= 1;
        _context.SaveChanges();
        return true;
    }

    public ICollection<Posts> GetAll()
    {
        return _context.Posts.ToList();
    }

    public Posts GetById(long Id)
    {
        return _context.Posts.SingleOrDefault(s => s.Id == Id);
    }

    public List<Posts> GetByTeacherId(long TeacherId)
    {
        List<Posts> posts = new List<Posts>();
        var teacher = _context.Posts.Where(s => s.Instructor.Id == TeacherId).ToList();
        if(teacher == null) { return posts; }
        foreach(var post in teacher)
        {
            posts.Add(new Posts
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Avatar = post.Avatar,
                PostTime = DateTime.UtcNow,
                CommentCount= post.CommentCount,
                Likes = post.Likes,
                Dislikes = post.Dislikes,
            });
        }
        return posts;
    }

    public bool Update(Posts posts, List<IFormFile> Images)
    {
        var post = _context.Posts.SingleOrDefault(s => s.Id == posts.Id);
        if(post == null) { return false; }
        post.Title = posts.Title;
        post.Content = posts.Content;
        post.CommentCount = posts.CommentCount;
        post.PostTime = DateTime.UtcNow;
        post.Likes = posts.Likes;
        post.Dislikes = posts.Dislikes;
        if(Images != null )
        {
            CloudinaryRepository cloudinary = new CloudinaryRepository();
            string Url = cloudinary.uploadFile(Images[0]);
            if (!string.IsNullOrEmpty(Url)) { post.Avatar = Url; }
        }
        _context.Posts.Update(post);
        _context.SaveChanges();
        return true;
    }
}
