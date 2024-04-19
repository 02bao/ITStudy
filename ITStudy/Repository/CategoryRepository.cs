using ITStudy.Data;
using ITStudy.Interface;
using ITStudy.Models;

namespace ITStudy.Repository;

public class CategoryRepository(DataContext _context) : ICategoryRepository
{
    public bool CreateNew(Category_Create category)
    {
        Category NewCategories = new Category()
        {
            Name = category.Name,
            Descriptions = category.Descriptions,
        };
        _context.Categories.Add(NewCategories);
        _context.SaveChanges();
        return true;
    }
    public Category GetById(long Id)
    {
        return _context.Categories.SingleOrDefault(s => s.Id == Id);
    }

    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

   
}
