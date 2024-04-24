using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IReviewsRepository
    {
        bool CreateNewReview(long StudentId,long CartItemIds, Reviews_Create Create);
        ICollection<Reviews> GetAll();
        List<Reviews> GetByStudentId(long StudentId);
        List<Reviews> GetByTeacherId(long TeacherId);
        bool Update(Reviews Reviews);
        bool Delete(long Id);
    }
}
