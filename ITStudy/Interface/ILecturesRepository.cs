using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface ILecturesRepository
    {
        bool CreateNew(long CourseId, Lectures_Create lectures);
        ICollection<Lectures> GetAll();
        Lectures GetById(long Id);
        List<Lectures> GetByCourseId(long CourseId);
        bool Update(Lectures Lectures, List<IFormFile> Images);
        bool Delete(long Id);
    }
}
