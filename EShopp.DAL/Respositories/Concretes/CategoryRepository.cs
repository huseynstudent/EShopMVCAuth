using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstacts;
using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopp.DAL.Respositories.Concretes;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(EShoppDbContext context) : base(context)
    {
    }
}
