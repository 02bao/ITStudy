namespace ITStudy.Models;

public class Vouchers
{
    public long Id { get; set; }
    public Instructors? Teacher { get; set; }
    public Student? Student { get; set; }
}
