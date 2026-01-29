using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstacts;
using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopp.DAL.Respositories.Concretes;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(EShoppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
    {
        return await _context.Products
        .Include(p => p.Category)
        .ToListAsync();
    }
}
