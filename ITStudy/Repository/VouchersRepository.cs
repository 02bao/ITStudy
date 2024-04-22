﻿using ITStudy.Data;
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
        }
    }

    public bool Delete(long VoucherId)
    {
        throw new NotImplementedException();
    }

    public ICollection<Vouchers> GetAll()
    {
        return _context.Vouchers.ToList();
    }

    public Vouchers GetById(long VoucherId)
    {
        throw new NotImplementedException();
    }

    public List<Vouchers> GetByTeacherId(long TeacherId)
    {
        throw new NotImplementedException();
    }

    public bool Update(Vouchers Vouchers)
    {
        throw new NotImplementedException();
    }
}