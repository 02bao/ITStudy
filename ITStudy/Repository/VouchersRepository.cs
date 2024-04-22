using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;

namespace ITStudy.Repository;

public class VouchersRepository(DataContext _context) : IVouchersRepository
{
    public bool CreateNewVoucher(long TeacherId, long CourseId, DateTime ExpireTime, Vouchers_Add Vouchers)
    {
        if(string.IsNullOrEmpty(Vouchers.Title)) { return false; }
        var teacher = _context.Instructors.SingleOrDefault(s => s.Id == TeacherId);
        if (teacher == null) { return false; }
        var course = _context.Courses.SingleOrDefault(s => s.Id ==  CourseId);
        if (course == null)
        {
            Vouchers AllCourse = new Vouchers()
            {
                Title = Vouchers.Title,
                Discount = Vouchers.Discount,
                Public_Date = Vouchers.Public_Date,
                Expire_Date = ExpireTime.ToUniversalTime(),
                Teacher = teacher,
                Course = null,
                Student = null,
            };
            _context.Vouchers.Add(AllCourse);
            _context.SaveChanges();
            return true;
        }
        else
        {
            Vouchers OneCourse = new Vouchers()
            {
                Title = Vouchers.Title,
                Discount = Vouchers.Discount,
                Public_Date = Vouchers.Public_Date,
                Expire_Date = ExpireTime.ToUniversalTime(),
                Teacher = teacher,
                Course = course,
                Student = null,
            };
            _context.Vouchers.Add(OneCourse);
            _context.SaveChanges();
            return true;
        }
    }

    public bool Delete(long VoucherId)
    {
        var voucher = _context.Vouchers.SingleOrDefault(s => s.Id == VoucherId);
        if (voucher == null) { return false; }
        _context.Vouchers.Remove(voucher);
        _context.SaveChanges();
        return true;
    }

    public ICollection<Vouchers> GetAll()
    {
        return _context.Vouchers.ToList();
    }

    public Vouchers GetById(long VoucherId)
    {
        return _context.Vouchers.SingleOrDefault(s => s.Id == VoucherId);
    }

    public List<Vouchers> GetByTeacherId(long TeacherId)
    {
        List<Vouchers> vouchers = new List<Vouchers>();
        var teacher = _context.Vouchers.Where(s => s.Teacher.Id == TeacherId).ToList();
        if(teacher == null) { return vouchers; }
        foreach(var voucher in teacher)
        {
            vouchers.Add(new Vouchers()
            {
                Id = voucher.Id,
                Title = voucher.Title,
                Discount = voucher.Discount,
                Public_Date = voucher.Public_Date,
                Expire_Date = voucher.Expire_Date,
            });
        }
        return vouchers;
    }

    
}
