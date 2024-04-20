using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IStudentRepository
    {
        bool CreateNew(long UserId, Student_Create Create);
        ICollection<Student> GetAll();
        Student GetById(long Id);
        List<Student> GetByUserId(long UserId);
        bool Update(Student Students);
        bool Delete(long Id);
    }
}
