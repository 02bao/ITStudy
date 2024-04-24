namespace ITStudy.Models;

public class CartItem
{
    public long Id { get; set; }
    public Cart Cart { get; set; }
    public Courses Courses { get; set; }
    public BuyCourses? BuyCourse { get; set; }
    public long Price { get; set; } = 0;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Status_CartItem Status { get; set; } = Status_CartItem.pending;
}

public enum Status_CartItem
{
    pending,
    active,
    buy
}

public class CartItem_Add
{
    public long CourseId { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Status_CartItem Status { get; set; } = Status_CartItem.active;
}

public class CartItem_Get
{
    public long Id { get; set; }
    public long CourseId { get; set; }
    public string TeacherName { get; set; }
    public string CourseName { get; set; }
    public long CoursePrice { get; set; }
}
