using Microsoft.EntityFrameworkCore;

namespace Root.Persistence.Context;

public class RootDbContext : DbContext
{
    public RootDbContext(DbContextOptions<RootDbContext> options) : base(options) { }
    //public DbSet<Post> Posts { get; set; }
}