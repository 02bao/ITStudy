using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ITStudy.Repository
{
    public class CartRepository(DataContext _context) : ICartRepository
    {
        public bool AddtoCart(long SutdnetId, CartItem_Add CartItems)
        {
            var student = _context.Students.SingleOrDefault(s =>s.Id == SutdnetId);
            if (student == null) { return false; }
            var course = _context.Courses.SingleOrDefault(s => s.Id == CartItems.CourseId);
            if (course == null) { return false; };
            var studentcart = _context.Carts.Include(s => s.CartItems)
                                            .ThenInclude(s => s.Courses)
                                            .SingleOrDefault(s => s.Student.Id  == SutdnetId);
            if(studentcart == null)
            {
                studentcart = new Cart()
                {
                    Student = student,
                    CreatedAt = DateTime.UtcNow,
                    TotalPrice = 0,
                    QuantityCourse = 0,
                    CartItems = new List<CartItem>(),
                };
                _context.Carts.Add(studentcart);
            }
            var Existcartitem = studentcart.CartItems.Where(s => s.Status == Status_CartItem.active &&
                                                      s.Courses.Id == CartItems.CourseId).SingleOrDefault();
            if(Existcartitem == null)
            {
                var CartItem = new CartItem()
                {
                    Courses = course,
                    CreatedAt = DateTime.UtcNow,
                    Status = Status_CartItem.active,
                };
                studentcart.CartItems.Add(CartItem);
                studentcart.QuantityCourse += 1;
                studentcart.TotalPrice += course.Price;
            }
            else { return false; }
            _context.SaveChanges();
            return true;
        }

        public List<Cart_Get> GetByStudentId(long StudentId)
        {
            List<Cart_Get> carts = new List<Cart_Get>();
            var student = _context.Carts.Include(s => s.CartItems)
                                      .ThenInclude(s => s.Courses)
                                      .ThenInclude(s => s.Teacher)
                                      .Where(s => s.Student.Id == StudentId)
                                      .ToList();
            if(student == null) { return carts; }
            foreach (var cart in student)
            {
                carts.Add(new Cart_Get()
                {
                    Id = cart.Id,
                    QuantityCourse = cart.QuantityCourse,
                    TotalPrice = cart.TotalPrice,
                    List_CartItem = cart.CartItems.Select(s => new CartItem_Get
                    {
                        Id = s.Id,
                        CourseId =s.Courses.Id,
                        TeacherName = s.Courses.Teacher.TeacherName,
                        CourseName = s.Courses.Title,
                        CoursePrice = s.Courses.Price,
                    }).ToList()
                });
            }
            return carts;
        }    

        public bool RemoveCartItem(long CartItemId)
        {
            var cartitem = _context.CartItems.SingleOrDefault(s => s.Id == CartItemId);
            if(cartitem == null) { return false; }
            _context.CartItems.Remove(cartitem);
            _context.SaveChanges();
            return true;
        }
    }
}
