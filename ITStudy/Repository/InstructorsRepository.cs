using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;

namespace ITStudy.Repository
{
    public class InstructorsRepository(DataContext _context) : IInstructorsRepository
    {
        public bool CreateNew(long UserId, Instructors_Create Create)
        {
            Users users = _context.Users.SingleOrDefault(s => s.Id == UserId);
            if (users == null) { return false; }
            Instructors NewTeacher = new Instructors()
            {
                TeacherName = Create.TeacherName,
                Bio = Create.Bio,
                Field = Create.Field,
                User = users,
            };
            _context.Instructors.Add(NewTeacher);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long Id)
        {
            var teacher = _context.Instructors.SingleOrDefault(s => s.Id == Id);
            if (teacher == null) { return false; }
            _context.Instructors.Remove(teacher);
            _context.SaveChanges() ;
            return true;
        }

        public ICollection<Instructors> GetAll()
        {
            return _context.Instructors.ToList();
        }

        public Instructors GetById(long Id)
        {
            return _context.Instructors.SingleOrDefault(s => s.Id == Id);
        }

        public List<Instructors> GetByUserId(long UserId)
        {
            List<Instructors> Instruc = new List<Instructors>();
            var users = _context.Instructors.Where(s => s.User.Id == UserId).ToList();
            if(users == null) { return  Instruc; }
            foreach( var user in users) 
            {
                Instruc.Add(new Instructors()
                {
                    Id = user.Id,
                    TeacherName = user.TeacherName,
                    Bio = user.Bio,
                    Field = user.Field,
                    Avatars = user.Avatars,
                    CoursesTaught = user.CoursesTaught,
                    Posts = user.Posts,
                });
            }
            return Instruc;
        }

        public bool Update(Instructors Instructors,List<IFormFile> Images)
        {
            var Teacher = _context.Instructors.SingleOrDefault(s => s.Id == Instructors.Id);
            if(Teacher == null) { return false; }
            Teacher.TeacherName = Instructors.TeacherName;
            Teacher.Bio = Instructors.Bio;
            Teacher.Field = Instructors.Field;
            Teacher.CoursesTaught  = Instructors.CoursesTaught;
            Teacher.Posts = Instructors.Posts;
            if(Images != null)
            {
                CloudinaryRepository cloudinary = new CloudinaryRepository();
                string Url = cloudinary.uploadFile(Images[0]);
                if(!string.IsNullOrEmpty(Url) ) { Teacher.Avatars = Url; }
            }
            _context.Instructors.Update(Teacher);
            _context.SaveChanges();
            return true;
        }
    }
}
