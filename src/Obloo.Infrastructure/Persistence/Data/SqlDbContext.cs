using Microsoft.EntityFrameworkCore;
using Obloo.Domain.Entities;

namespace Obloo.Infrastructure.Persistence.Data;

public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .ToTable("Users");
    }
}