using ITStudy.Models;

namespace ITStudy.DTO;

public class VouchersDTO
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Discount { get; set; } = 0;
    public long? CourseId { get; set; } = null;
    public DateTime? Public_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public DateTime? Expire_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public Status_Vouchers Status { get; set; } = Status_Vouchers.active;
}

public class Vouchers_AddDTO
{
    public string Title { get; set; } = string.Empty;
    public double Discount { get; set; } = 0;
    public DateTime? Public_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public DateTime? Expire_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public Status_Vouchers Status { get; set; } = Status_Vouchers.active;
}

public class Vouchers_GetDTO
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Discount { get; set; } = 0;
    public int? CourseId { get; set; } = null;
    public DateTime? Public_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public DateTime? Expire_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public Status_Vouchers Status { get; set; } = Status_Vouchers.active;
}

