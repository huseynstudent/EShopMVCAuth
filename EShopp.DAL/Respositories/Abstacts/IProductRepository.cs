using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopp.DAL.Respositories.Abstacts;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetAllWithCategoryAsync();

}
