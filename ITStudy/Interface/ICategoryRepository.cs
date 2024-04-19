using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface ICategoryRepository
    {
        bool CreateNew(Category_Create category);
        ICollection<Category> GetCategories();
        Category GetById(long Id);
    }
}
