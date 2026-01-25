using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstacts;
using Microsoft.EntityFrameworkCore;

namespace EShopp.DAL.Respositories.Concretes;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly EShoppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(EShoppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Delete(int id)
    {
        _dbSet.Remove(_dbSet.Find(id)!);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
