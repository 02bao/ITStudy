using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IInstructorsRepository
    {
        bool CreateNew(long UserId, Instructors_Create Create);
    }
}
