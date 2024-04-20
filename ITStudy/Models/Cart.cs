namespace ITStudy.Models;

public class Cart
{
    public long Id { get; set; }
    public Student? Student { get; set; }
    public List<CartItem>? CartItems { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public long? TotalPrice { get; set; } = 0;
    public long? QuantityCourse { get; set; } = 0;
}

public class Cart_Get
{
    public long Id { get; set; }
    public long? TotalPrice { get; set; } = 0;
    public long? QuantityCourse { get; set; } = 0;
    public List<CartItem_Get>? List_CartItem { get; set; }
}
