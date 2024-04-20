using ITStudy.Models;

namespace ITStudy.DTO;

public class CartItemDTO
{
    public long Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Status_CartItem Status { get; set; } = Status_CartItem.pending;
}
public class CartItem_AddDTO
{
    public long CourseId { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Status_CartItem Status { get; set; } = Status_CartItem.active;
}
