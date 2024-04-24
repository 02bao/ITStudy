using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ITStudy.Repository
{
    public class ReviewsRepository(DataContext _context) : IReviewsRepository
    {
        public bool CreateNewReview(long StudentId, long CartItemIds, Reviews_Create Create)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == StudentId);
            if(student == null) { return false; }
            var cartitem = _context.CartItems.Include(s => s.BuyCourse)
                                             .Where(s => s.Id == CartItemIds &&
                                             s.BuyCourse.Status == Status_Buy.completed &&
                                             s.BuyCourse.Student.Id == StudentId)
                                             .Include(s => s.Courses)
                                             .SingleOrDefault();
            if(cartitem == null) { return false; }
            var review = _context.Reviews.Where(s => s.Student == student && 
                                         s.CartItem == cartitem)
                                         .SingleOrDefault();
            if(review != null) { return false; }
            Reviews NewReview = new Reviews()
            {
                Student = student,
                CartItem = cartitem,
                Course = cartitem.Courses,
                Comment = Create.Comment,
                Rating = Create.Rating,
                Likes = 0,
                Dislikes = 0,
                Share = 0,
                PostedAt = DateTime.UtcNow,
            };
            _context.Reviews.Add(NewReview);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long Id)
        {
            var review = _context.Reviews.SingleOrDefault(s => s.Id == Id);
            if(review == null) { return false; }
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Reviews> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public List<Reviews> GetByStudentId(long StudentId)
        {
            List<Reviews> reviews = new List<Reviews>();
            var student = _context.Reviews.Where(s => s.Student.Id  == StudentId).ToList();
            if(student == null) { return reviews; }
            foreach(var review in  student)
            {
                reviews.Add(new Reviews()
                {
                    Id = review.Id,
                    Comment = review.Comment,
                    Rating = review.Rating,
                    Likes = review.Likes,
                    Dislikes = review.Dislikes,
                    Share = review.Share,
                    PostedAt = review.PostedAt,
                });
            }
            return reviews;
        }

        public List<Reviews> GetByTeacherId(long TeacherId)
        {
            List<Reviews> reviews = new List<Reviews>();
            var teacher = _context.Reviews.Where(s => s.Course.Teacher.Id == TeacherId).ToList();
            if (teacher == null) { return reviews; }
            foreach (var review in teacher)
            {
                reviews.Add(new Reviews()
                {
                    Id = review.Id,
                    Comment = review.Comment,
                    Rating = review.Rating,
                    Likes = review.Likes,
                    Dislikes = review.Dislikes,
                    Share = review.Share,
                    PostedAt = review.PostedAt,
                });
            }
            return reviews;
        }

        public bool Update(Reviews Reviews)
        {
            _context.Reviews.Update(Reviews);
            _context.SaveChanges();
            return true;
        }
    }
}
