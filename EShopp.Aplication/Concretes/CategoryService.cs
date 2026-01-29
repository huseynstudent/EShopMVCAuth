using EShopp.Aplication.Abstacts;
using EShopp.DAL.UnitOfWork;
using EShopp.Domain.Entities;
using System.Threading.Tasks;

namespace EShopp.Aplication.Concretes;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddCategory(Category category)
    {
        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _unitOfWork.Categories.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _unitOfWork.Categories.GetByIdAsync(id);
    }

    public async Task RemoveCategory(int id)
    {
        _unitOfWork.Categories.Delete(id);
        await _unitOfWork.SaveChangesAsync();

    }

    public async Task UpdateCategory(Category category)
    {
        _unitOfWork.Categories.Update(category);
        await _unitOfWork.SaveChangesAsync();

    }
}
