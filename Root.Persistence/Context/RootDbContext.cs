using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities;
using Root.Domain.Entities.Blog;
using Root.Domain.Entities.Packages;

namespace Root.Persistence.Context;

public class RootDbContext : DbContext
{
    public RootDbContext(DbContextOptions<RootDbContext> options) : base(options) { }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Reserve> Reserves { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Guide> Guides { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Category> PostCategories { get; set; }
}