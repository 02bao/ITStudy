﻿using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ITStudy.Repository
{
    public class BuyCoursesRepository(DataContext _context) : IBuycoursesRepository
    {
        public bool BuyNewcourses(long StudentId, List<long> CartItemIds, long VoucherId)
        {
            Student? student = _context.Students.SingleOrDefault(s => s.Id == StudentId);
            if (student == null) { return false; }
            double Voucher_Discount = 0;
            List<CartItem>? cartitems = _context.CartItems.Include(s => s.Courses)
                                                   .ThenInclude(s => s.Teacher)
                                                   .Include(s => s.Cart)
                                                   .Where(s => CartItemIds.Contains(s.Id) &&
                                                    s.Cart.Student.Id == StudentId &&
                                                    s.Status == Status_CartItem.active)
                                                   .ToList();
            if(cartitems == null || cartitems.Count == 0) { return false; }
            if(VoucherId != 0)
            {
                var VoucherApplied = _context.Vouchers.Include(s => s.Student)
                                                      .Where(s => s.Id == VoucherId &&
                                                      s.Student.Id == StudentId &&
                                                      s.Expire_Date > DateTime.UtcNow &&
                                                      s.Status == Status_Vouchers.active)
                                                      .SingleOrDefault();
                if( VoucherApplied != null )
                {
                    Voucher_Discount = 1- (VoucherApplied.Discount/100);
                    VoucherApplied.Status = Status_Vouchers.uses;
                }
            }
            var teacherid = _context.CartItems.First().Courses.Teacher.Id;
            Instructors?teacher = _context.Instructors.SingleOrDefault(s  => s.Id == teacherid);
            if( teacher == null ) { return false; }
            foreach(var cartitem in cartitems)
            {
                BuyCourses Buy = new BuyCourses()
                {
                    Student = student,
                    Teacher = teacher,
                    PurchasedTime = DateTime.UtcNow,
                    CourseName = cartitem.Courses.Title,
                    PriceCourse = cartitem.Courses.Price,
                    TotalAmount = cartitem.Courses.Price*Voucher_Discount,
                    Status = Status_Buy.completed,
                    List_CartItems = cartitems,
                };
                cartitem.Status = Status_CartItem.buy;
                _context.BuyCourses.Add( Buy );
            }
            _context.SaveChanges();
            return true;
        }

        public List<BuyCourses_Get> GetBySutdentId(long StudentId)
        {
            List<BuyCourses_Get> buycourses = new List<BuyCourses_Get> ();
            var student = _context.Students.SingleOrDefault(s => s.Id == StudentId);
            if( student == null ) { return buycourses; }
            var buycourse = _context.BuyCourses.Include(s => s.List_CartItems)
                                               .ThenInclude(s => s.Courses)
                                               .Where(s => s.Student.Id == StudentId)
                                               .Select(s => new BuyCourses_Get()
                                               {
                                                   BuyId = s.Id,
                                                   StudentBuy_Id = student.Id,
                                                   StudentBuy_Name = student.StudentName,
                                                   TeacherBy_Name = s.Teacher.TeacherName,
                                                   TotalAmount = s.TotalAmount,
                                                   List_CartItem = s.List_CartItems.Select(
                                                   s => $"CourseId:{s.Courses.Id}  - CourseName:{s.Courses.Title} - LectureCount:{s.Courses.LectureCount} ")
                                                   .ToList(),
                                               }).ToList();
            return buycourse;
        }

        public List<BuyCourses_Get> GetByTeacherId(long TeacherId)
        {

            List<BuyCourses_Get> buycourses = new List<BuyCourses_Get>();
            var teacher = _context.Instructors.SingleOrDefault(s => s.Id == TeacherId);
            if (teacher == null) { return buycourses; }
            var buycourse = _context.BuyCourses.Include(s => s.Student)
                                               .Include(s => s.List_CartItems)
                                               .ThenInclude(s => s.Courses)
                                               .Where(s => s.Teacher.Id == TeacherId)
                                               .Select(s => new BuyCourses_Get()
                                               {
                                                   BuyId = s.Id,
                                                   StudentBuy_Id = s.Student.Id,
                                                   StudentBuy_Name = s.Student.StudentName,
                                                   TeacherBy_Name = teacher.TeacherName,
                                                   TotalAmount = s.TotalAmount,
                                                   List_CartItem = s.List_CartItems.Select(
                                                   s => $"CourseId:{s.Courses.Id}  - CourseName:{s.Courses.Title} - LectureCount:{s.Courses.LectureCount} ")
                                                   .ToList(),
                                               }).ToList();
            return buycourse;
        }
    }
}
