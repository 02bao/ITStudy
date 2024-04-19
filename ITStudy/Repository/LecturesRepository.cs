using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ITStudy.Repository
{
    public class LecturesRepository(DataContext _context) : ILecturesRepository
    {
        public bool CreateNew(long CourseId, Lectures_Create lectures)
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == CourseId);
            if (course == null) { return false; }
            Lectures NewLectures = new Lectures()
            {
                Title = lectures.Title,
                Descriptions = lectures.Descriptions,
                Durations = lectures.Durations,
                Course = course,
            };
            _context.Lectures.Add(NewLectures);
            course.LectureCount += 1;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long Id)
        {
            var lectures = _context.Lectures.Include(s => s.Course).Where(s => s.Id == Id).SingleOrDefault();
            if(lectures == null) { return false; }  
            _context.Lectures.Remove(lectures);
            lectures.Course.LectureCount -= 1;
            _context.SaveChanges();
            return true;
        }

        public ICollection<Lectures> GetAll()
        {
            return _context.Lectures.ToList();
        }

        public List<Lectures> GetByCourseId(long CourseId)
        {
            List<Lectures> lectures = new List<Lectures>();
            var course = _context.Lectures.Where(s => s.Course.Id == CourseId).ToList();
            if(course == null) { return lectures; }
            foreach(var lecture in course)
            {
                lectures.Add(new Lectures()
                {
                    Id = lecture.Id,
                    Title = lecture.Title,
                    Descriptions = lecture.Descriptions,
                    Content = lecture.Content,
                    Durations = lecture.Durations,
                    Video = lecture.Video, 
                });
            }
            return lectures;
        }

        public Lectures GetById(long Id)
        {
            return _context.Lectures.SingleOrDefault(s => s.Id == Id);
        }

        public bool Update(Lectures Lectures, List<IFormFile> Images)
        {
            var lecture = _context.Lectures.SingleOrDefault(s => s.Id == Lectures.Id);
            if (lecture == null) { return false; }
            lecture.Title = Lectures.Title;
            lecture.Descriptions = Lectures.Descriptions;
            lecture.Content = Lectures.Content;
            lecture.Durations = Lectures.Durations;
            if (Images != null)
            {
                CloudinaryRepository cloudinary = new CloudinaryRepository();
                string Url = cloudinary.uploadFile(Images[0]);
                if (!string.IsNullOrEmpty(Url)) { lecture.Video = Url; }
            }
            _context.Lectures.Update(lecture);
            _context.SaveChanges();
            return true;
        }
    }
}
