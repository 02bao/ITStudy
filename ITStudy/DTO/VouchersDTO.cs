namespace ITStudy.DTO;

public class VouchersDTO
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Discount { get; set; } = 0;
    public DateTime? Public_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public DateTime? Expire_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
}

public class Vouchers_AddDTO
{
    public string Title { get; set; } = string.Empty;
    public int Discount { get; set; } = 0;
    public DateTime? Public_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public DateTime? Expire_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
}
