using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface ICoursesRepository
    {
        bool CreateNew(long TeacherId, long CategoryId, Courses_Create courses);
        ICollection<Courses> GetAll();
        Courses GetById(long Id);
        List<Courses> GetByTeacherId(long TeacherId);
        List<Courses> GetByCategoryId(long CategoryId);
        bool Update(Courses courses, List<IFormFile> Images);
        bool Delete(long Id);
    }
}
