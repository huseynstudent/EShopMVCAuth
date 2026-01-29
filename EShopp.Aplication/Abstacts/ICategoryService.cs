using EShopp.Domain.Entities;

namespace EShopp.Aplication.Abstacts;

public interface ICategoryService
{
    Task AddCategory(Category category);
    Task RemoveCategory(int id);
    Task UpdateCategory(Category category);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
}
