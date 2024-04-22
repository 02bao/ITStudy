using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface IVouchersRepository
    {
        bool CreateNewVoucher(long TeacherId, long CourseId, DateTime ExpireTime, Vouchers_Add Vouchers);
        ICollection<Vouchers> GetAll();
        Vouchers GetById(long VoucherId);
        List<Vouchers> GetByTeacherId(long TeacherId);
        bool Update(Vouchers Vouchers);
        bool Delete(long VoucherId);    
    }
}
