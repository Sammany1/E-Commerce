using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Interfaces.Repositories;
public interface ICategoryRepository : IBaseRepository<Category>
{
        public Task<bool> CategoryExists(int CategoryId);
        public Task<bool> CategoryNameExists(string categoryName);
}
