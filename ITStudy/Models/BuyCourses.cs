namespace ITStudy.Models;

public class BuyCourses
{
    public long Id { get; set; }
    public List<CartItem> List_CartItems { get; set; }
    public Student Student { get; set; }
    public Instructors Teacher { get; set; }
    public DateTime? PurchasedTime { get; set; } = DateTime.UtcNow;
    public string CourseName { get; set; } = string.Empty;
    public double PriceCourse { get; set; } = 0;
    public double TotalAmount { get; set; } = 0;
    public Status_Buy Status { get; set; } = Status_Buy.pending;

}

public enum Status_Buy
{
    pending,
    completed
}
public class BuyCourses_Get
{
    public long BuyId { get; set; }
    public long StudentBuy_Id { get; set; }
    public string StudentBuy_Name { get; set; } = string.Empty;
    public string TeacherBy_Name { get; set; } = string.Empty;
    public double TotalAmount { get; set; } = 0;
    public List<string>? List_CartItem { get; set; }
}
