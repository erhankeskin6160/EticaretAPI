using EticaretAPI.Domain.Entities.Comman;
using System.Linq.Expressions;

namespace EticaretAPI.Application.Repositories
{
    public interface  IReadRepository<T>:IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(string id);
       

    }
}
