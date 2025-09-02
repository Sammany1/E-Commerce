using eCommerce.Domain.Models;

namespace eCommerce.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize);
    Task<T> GetById(int id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(int id);
}
