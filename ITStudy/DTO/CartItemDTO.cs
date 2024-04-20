using ITStudy.Models;

namespace ITStudy.DTO;

public class CartItemDTO
{
    public long Id { get; set; }
    public long Price { get; set; } = 0;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Status_CartItem Status { get; set; } = Status_CartItem.pending;
}
