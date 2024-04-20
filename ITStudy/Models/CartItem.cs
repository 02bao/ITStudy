namespace ITStudy.Models;

public class CartItem
{
    public long Id { get; set; }
    public Cart Cart { get; set; }
    public Courses Courses { get; set; }
    public long Price { get; set; } = 0;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Status_CartItem Status { get; set; } = Status_CartItem.pending;
}

public enum Status_CartItem
{
    pending,
    active,
    order
}

public class CartItem_Add
{
    public long Id { get; set; }
    public long Price { get; set; } = 0;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Status_CartItem Status { get; set; } = Status_CartItem.active;
}
}
