using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;

namespace ITStudy.Repository;

public class FavoriteRepository(DataContext _context) : IFavoriteRepository
{
    public bool FollowTeacher(long StudentId,long TeacherId,  Favorite_Teacher Teachers)
    {
        var student = _context.Students.SingleOrDefault(s => s.Id == StudentId);
        if(student == null) { return false; }
        var teacher = _context.Instructors.SingleOrDefault(s => s.Id==TeacherId);
        if(teacher == null) { return false; }
        var NewFollows = new Favorite()
        {
            Student = student,
            Teacher = teacher,
            IsReal = Teachers.IsReal,
            Status = Status_Favorite.Follow,
            CreateAt = DateTime.UtcNow,
        };
        _context.Favorites.Add(NewFollows);
        _context.SaveChanges();
        return true;
    }
}
