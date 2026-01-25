using EShopp.DAL.Respositories.Abstacts;

namespace EShopp.DAL.UnitOfWork;

public interface IUnitOfWork
{
    ICategoryRepository Categories {get;}
    Task<int> SaveChangesAsync();
}
