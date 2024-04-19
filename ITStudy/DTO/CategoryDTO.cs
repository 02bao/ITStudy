namespace ITStudy.DTO
{
    public class CategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
    }

    public class Category_CreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
    }
}
