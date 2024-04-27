using CloudinaryDotNet;
using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ITStudy.Repository;

public class NotiRepository(DataContext _context) : INotiRepository
{
    public void SendNotiForCourses(Instructors Teachers, Courses Course)
    {
        var followers = _context.Favorites.Include(s => s.Teacher)
                                          .Where(s => s.Teacher.Id == Teachers.Id)
                                          .Select(s => s.Student)
                                          .ToList();
        foreach (var student in followers)
        {
            Notifications NewNoti = new Notifications()
            {
                Student = student,
                Teacher = Teachers,
                Course = Course,
                Content = "Giao vien " + Teachers.TeacherName + " da dang mot course moi " + Course.Title,
                StatusSent = Status_Sent.Sent,
                StatusNoti = Status_NotifyType.NewPost,
                SentAt = DateTime.UtcNow,
            };
            _context.Notifications.Add(NewNoti);
        }
        _context.SaveChanges();
    }

    public void SendNotiForLectures(Courses Courses, Lectures Lecture)
    {
        var followers = _context.Favorites.Include(s => s.Course)
                                           .Where(s => s.Course.Id == Courses.Id)
                                           .Select(s => s.Student)
                                           .ToList();
        foreach (var student in followers)
        {
            Notifications NewNoti = new Notifications()
            {
                Student = student,
                Course = Courses,
                Lecture = Lecture,
                Content = "Khoa hoc " + Courses.Title + " ban yeu thich da co 1 bai dang moi : " + Lecture.Title,
                StatusSent = Status_Sent.Sent,
                StatusNoti = Status_NotifyType.NewPost,
                SentAt = DateTime.UtcNow,
            };
            _context.Notifications.Add(NewNoti);
        }
        _context.SaveChanges();
    }

    public void SendNotiForPosts(Instructors Teachers, Posts Post)
    {
        var followers = _context.Favorites.Include(s => s.Teacher)
                                          .Where(s => s.Teacher.Id == Teachers.Id)
                                          .Select(s => s.Student)
                                          .ToList();
        foreach(var student in followers)
        {
            Notifications NewNoti = new Notifications()
            {
                Student = student,
                Teacher = Teachers,
                Post = Post,
                Content = "Giao vien " + Teachers.TeacherName + " da dang mot post moi " + Post.Title,
                StatusSent = Status_Sent.Sent,
                StatusNoti = Status_NotifyType.NewPost,
                SentAt = DateTime.UtcNow,
            };
            _context.Notifications.Add(NewNoti);
        }
        _context.SaveChanges();
    }
}
