using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;

namespace ITStudy.Repository
{
    public class StudentRepository(DataContext _context) : IStudentRepository
    {
        public bool CreateNew(long UserId, Student_Create Create)
        {
            var user = _context.Users.SingleOrDefault(s => s.Id == UserId);
            if (user == null) { return false; }
            Student NewStudent = new Student()
            {
                StudentName = Create.StudentName,
                Bio = Create.Bio,
                Field = Create.Field,
                User = user,
            };
            _context.Students.Add(NewStudent);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long Id)
        {
            var students = _context.Students.SingleOrDefault(s => s.Id == Id);
            if (students == null) { return false; }
            _context.Students.Remove(students);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(long Id)
        {
            return _context.Students.SingleOrDefault(s => s.Id == Id);
        }

        public List<Student> GetByUserId(long UserId)
        {
            List<Student> students = new List<Student>();
            var user = _context.Students.Where(s => s.User.Id == UserId).ToList();
            if (user == null) { return students; }
            foreach (var student in user)
            {
                students.Add(new Student()
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    Bio = student.Bio,
                    Field = student.Field,
                });
            }
            return students;
        }

        public bool Update(Student Students)
        {
            _context.Students.Update(Students);
            _context.SaveChanges();
            return true;
        }
    }
}
