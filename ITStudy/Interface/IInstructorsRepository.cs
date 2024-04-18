using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IInstructorsRepository
    {
        bool CreateNew(long UserId, Instructors_Create Create);
        ICollection<Instructors> GetAll();
        Instructors GetById(long Id);
        List<Instructors> GetByUserId(long UserId);
        bool Update(Instructors Instructors, IFormFile Images);
        bool Delete(long Id);
    }
}
