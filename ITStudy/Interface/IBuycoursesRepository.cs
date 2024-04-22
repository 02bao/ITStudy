using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IBuycoursesRepository
    {
        bool BuyNewcourses(long StudentId, List<long> CartItemIds, long VoucherId);
        List<BuyCourses_Get> GetBySutdentId(long StudentId);
    }
}
