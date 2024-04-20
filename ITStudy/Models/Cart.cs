namespace ITStudy.Models;

public class Cart
{
    public long Id { get; set; }
    public Student? Student { get; set; }
    public Instructors? Teacher { get; set; }
    public List<CartItem>? CartItems { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public long TotalPrice { get; set; } = 0;
    public string QuantityCourse { get; set; } = string.Empty;
}
