using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Obloo.Domain.Interfaces;
using Obloo.Infrastructure.Persistence.Data;
using Obloo.Domain.Primitives;

namespace Obloo.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly SqlDbContext _dbContext;
    private bool _disposed = false;

    public UnitOfWork(SqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditEntities();
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void UpdateAuditEntities()
    {
        IEnumerable<EntityEntry<IAuditableEntity>> entities = _dbContext.ChangeTracker.Entries<IAuditableEntity>();

        foreach (EntityEntry<IAuditableEntity> entry in entities)
        {
            DateTime now = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entry.Property(a => a.CreatedOnUtc).CurrentValue = now;
            }
            entry.Property(a => a.ModifiedOnUtc).CurrentValue = now;
        }
    }
}