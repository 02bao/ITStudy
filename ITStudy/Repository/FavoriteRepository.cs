using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ITStudy.Repository;

public class FavoriteRepository(DataContext _context) : IFavoriteRepository
{
    public bool Delete(long Id)
    {
        var follow = _context.Favorites.SingleOrDefault(s => s.Id  == Id);
        if(follow == null) { return  false; }
        _context.Favorites.Remove(follow);
        _context.SaveChanges();
        return true;
    }

    public bool FavoriteCourse(long StudentId, long CourseId, Favorite_Create Courses)
    {
        var student = _context.Students.SingleOrDefault(s => s.Id == StudentId);
        if (student == null) { return false; }
        var course = _context.Courses.Include(s => s.Teacher).SingleOrDefault(s => s.Id == CourseId);
        var NewFollows = new Favorite()
        {
            Student = student,
            Course = course,
            CourseName = course.Title,
            TeacherName = course.Teacher.TeacherName,
            IsReal = Courses.IsReal,
            Status = Status_Favorite.Follow,
            CreateAt = DateTime.UtcNow,
        };
        _context.Favorites.Add(NewFollows);
        _context.SaveChanges();
        return true;
    }

    public bool FollowTeacher(long StudentId,long TeacherId,  Favorite_Create Teachers)
    {
        var student = _context.Students.SingleOrDefault(s => s.Id == StudentId);
        if(student == null) { return false; }
        var teacher = _context.Instructors.Include(s => s.Courses).SingleOrDefault(s => s.Id == TeacherId);
        if(teacher == null) { return false; }
        var NewFollows = new Favorite()
        {
            Student = student,
            Teacher = teacher,
            TeacherName = teacher.TeacherName,
            CourseName = "",
            IsReal = Teachers.IsReal,
            Status = Status_Favorite.Follow,
            CreateAt = DateTime.UtcNow,
        };
        _context.Favorites.Add(NewFollows);
        _context.SaveChanges();
        return true;
    }

    public ICollection<Favorite> GetAll()
    {
        return _context.Favorites.ToList();
    }

    public Favorite GetById(long Id)
    {
        return _context.Favorites.SingleOrDefault(s => s.Id == Id);
    }

    public List<Favorite> GetByStudentId(long StudentId)
    {
        List<Favorite> favorites = new List<Favorite>();
        var student = _context.Favorites.Where(s => s.Student.Id == StudentId).ToList();
        if(student == null) { return  favorites; }
        foreach( var favorite in student)
        {
            favorites.Add(new Favorite()
            {
                Id = favorite.Id,
                TeacherName =favorite.TeacherName,
                CourseName =favorite.CourseName,
                IsReal = favorite.IsReal,
                CreateAt = favorite.CreateAt,
                Status = favorite.Status,
            });
        }
        return favorites;
    }

  
}
