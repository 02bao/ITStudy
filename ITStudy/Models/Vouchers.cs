namespace ITStudy.Models;

public class Vouchers
{
    public long Id { get; set; }
    public Instructors? Teacher { get; set; }
    public Student? Student { get; set; }
    public Courses? Course { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Discount { get; set; } = 0;
    public DateTime? Public_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public DateTime? Expire_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
}
public class Vouchers_Add
{
    public string Title { get; set; } = string.Empty;
    public int Discount { get; set; } = 0;
    public DateTime? Public_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
    public DateTime? Expire_Date { get; set; } = DateTime.UtcNow.ToUniversalTime();
}
