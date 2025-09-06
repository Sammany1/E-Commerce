using eCommerce.Domain.Models;

namespace eCommerce.Application.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
        public Task<bool> CategoryExists(int CategoryId);
        public Task<bool> CategoryNameExists(string categoryName);
}
