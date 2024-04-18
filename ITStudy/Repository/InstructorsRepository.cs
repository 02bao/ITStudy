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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Update(Instructors Instructors, List<IFormFile> Images)
        {
            throw new NotImplementedException();
        }
    }
}
