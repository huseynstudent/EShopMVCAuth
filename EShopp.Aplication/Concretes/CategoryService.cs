using EShopp.Aplication.Abstacts;
using EShopp.DAL.UnitOfWork;
using EShopp.Domain.Entities;

namespace EShopp.Aplication.Concretes;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddCategory(Category category)
    {
        _unitOfWork.Categories.AddAsync(category);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _unitOfWork.Categories.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _unitOfWork.Categories.GetByIdAsync(id);
    }

    public void RemoveCategory(int id)
    {
        _unitOfWork.Categories.Delete(id);
        _unitOfWork.SaveChangesAsync();

    }

    public void UpdateCategory(Category category)
    {
        _unitOfWork.Categories.Update(category);
        _unitOfWork.SaveChangesAsync();

    }
}
