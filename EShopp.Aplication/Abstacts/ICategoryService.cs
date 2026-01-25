using EShopp.Domain.Entities;

namespace EShopp.Aplication.Abstacts;

public interface ICategoryService
{
    void AddCategory(Category category);
    void RemoveCategory(int id);
    void UpdateCategory(Category category);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);

}
