using ITStudy.Models;

namespace ITStudy.DTO;

public class CartDTO
{
    public long Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public long? TotalPrice { get; set; } = 0;
    public long? QuantityCourse { get; set; } = 0;
}

