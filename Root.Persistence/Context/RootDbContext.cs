using Microsoft.EntityFrameworkCore;
using Root.Domain.Entities;
using Root.Domain.Entities.Blog;
using Root.Domain.Entities.Packages;
using Root.Domain.Enums;

namespace Root.Persistence.Context;

public class RootDbContext : DbContext
{
    public RootDbContext(DbContextOptions<RootDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = new Guid("edd7155e-5723-4bf9-bd43-e935823a7c0f"),
            Type = UserType.Administrator,
            UserName = "Jucs",
            Contact = "923679528",
            Email = "jucs@gmail.com",
            Password = "123456"
        });
        
        modelBuilder.Entity<Administrator>().HasData(
            new Administrator
            {
                Id = new Guid("5d5629f7-cce5-43b3-8a7f-821c9c5fd0a2"),
                UserId = new Guid("edd7155e-5723-4bf9-bd43-e935823a7c0f"),
                Name = "Juciano",
                Surname = "Silva",
                AcessLeves = [AdministratorAcess.All]
            }
        );
    }

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