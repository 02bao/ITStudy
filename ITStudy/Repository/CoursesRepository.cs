using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ITStudy.Repository
{
    public class CoursesRepository(DataContext _context) : ICoursesRepository
    {
        public bool CreateNew(long TeacherId, long CategoryId, Courses_Create courses)
        {
            var teacher = _context.Instructors.SingleOrDefault(s => s.Id ==  TeacherId);
            if(teacher == null) { return false; }
            var category = _context.Categories.SingleOrDefault(c => c.Id == CategoryId);
            if(category == null) { return false; }
            Courses NewCourses = new Courses()
            {
                Title = courses.Title,
                Descriptions = courses.Descriptions,
                Price = courses.Price,
                Durations = courses.Durations,
                CreateAt = DateTime.UtcNow,
                Teacher = teacher,
                Category = category,
            };
            _context.Courses.Add(NewCourses);
            teacher.CoursesTaught += 1;
            category.Count += 1;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long Id)
        {
            var course = _context.Courses.Include(s => s.Teacher)
                                         .Include(s => s.Category)
                                         .Where(s => s.Id == Id)
                                         .SingleOrDefault();
            if(course == null) { return false; }
            _context.Courses.Remove(course);
            course.Teacher.CoursesTaught -= 1;
            course.Category.Count -= 1;
            _context.SaveChanges();
            return true;
        }

        public ICollection<Courses> GetAll()
        {
            return _context.Courses.ToList();
        }

        public List<Courses> GetByCategoryId(long CategoryId)
        {
            List<Courses> courses = new List<Courses>();
            var category = _context.Courses.Where(s => s.Category.Id == CategoryId);
            if (category == null) { return courses; }
            foreach (var course in category)
            {
                courses.Add(new Courses
                {
                    Id = course.Id,
                    Title = course.Title,
                    Descriptions = course.Descriptions,
                    Picture = course.Picture,
                    Price = course.Price,
                    Durations = course.Durations,
                    CreateAt = course.CreateAt,
                    Rating = course.Rating,
                });
            }
            return courses;
        }

        public Courses GetById(long Id)
        {
            return _context.Courses.SingleOrDefault(s => s.Id == Id);

        }

        public List<Courses> GetByTeacherId(long TeacherId)
        {
            List<Courses> courses = new List<Courses>();    
            var teacher = _context.Courses.Where( s => s.Teacher.Id == TeacherId);
            if(teacher == null) { return courses; }
            foreach(var course in teacher)
            {
                courses.Add(new Courses
                {
                    Id = course.Id,
                    Title = course.Title,
                    Descriptions = course.Descriptions,
                    Picture = course.Picture,
                    Price = course.Price,
                    Durations = course.Durations,
                    CreateAt = course.CreateAt,
                    Rating = course.Rating,
                });
            }
            return courses;
        }

        public bool Update(Courses courses, List<IFormFile> Images)
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == courses.Id);
            if (course == null) { return false; };
            course.Title = courses.Title;
            course.Descriptions = courses.Descriptions;
            course.Price = courses.Price;
            course.Durations = courses.Durations;
            course.CreateAt = DateTime.UtcNow;
            course.Rating = courses.Rating;
            if(Images != null)
            {
                CloudinaryRepository cloudinary = new CloudinaryRepository();
                string Url = cloudinary.uploadFile(Images[0]);
                if(string.IsNullOrEmpty(Url)) { course.Picture = Url; } 
            }
            _context.Courses.Update(course);
            _context.SaveChanges();
            return true;
        }
    }
}
