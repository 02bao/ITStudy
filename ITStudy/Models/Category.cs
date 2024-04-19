namespace ITStudy.Models;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Descriptions { get; set; } = string.Empty;
    public int Count { get; set; } = 0;
    public List<Courses>? Courses { get; set; }
}

public class Category_Create
{
    public string Name { get; set; } = string.Empty;
    public string Descriptions { get; set; } = string.Empty;
}
