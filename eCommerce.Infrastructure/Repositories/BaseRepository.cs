using eCommerce.Application.Repositories;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class BaseRepository<T>(eCommerceDbContext context) : IBaseRepository<T> where T : BaseEntity
{
    private readonly eCommerceDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly DbSet<T> _table = context.Set<T>();

    public async Task<IEnumerable<T>> GetAll(int pageNumber = 1, int pageSize = 100)
    {
        return await _table
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _table.FindAsync(id);
    }
    public async Task Create(T entity)
    {
        await _table.AddAsync(entity);
    }
    public async Task Update(T entity)
    {
        _table.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var entity = await _table.FindAsync(id);
        _table.Remove(entity);
        await _context.SaveChangesAsync();
    }


}
