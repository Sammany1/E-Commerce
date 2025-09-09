using eCommerce.Domain.Models;


namespace eCommerce.Infrastructure.Interfaces.Repositories;
public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll(int pageNumber = 1, int pageSize = 10);
    Task<T> GetById(int id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(int id);
}
