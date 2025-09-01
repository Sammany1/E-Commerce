using eCommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Contexts;

public class eCommerceDbContext : DbContext
{
    public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<Category> Categories { get; set; }

}
