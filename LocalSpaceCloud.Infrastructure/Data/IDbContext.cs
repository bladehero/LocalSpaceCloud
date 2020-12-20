using LocalSpaceCloud.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LocalSpaceCloud.Infrastructure.Data
{
    public interface IDbContext
    {
        DbSet<BinEntity> BinEntities { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<SystemEntityTypeValue> SystemEntityTypes { get; set; }

        public event EventHandler<SavingChangesEventArgs> SavingChanges;
        public event EventHandler<SavedChangesEventArgs> SavedChanges;
        public event EventHandler<SaveChangesFailedEventArgs> SaveChangesFailed;

        public EntityEntry Add(object entity);
        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        public ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default);
        public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        public void AddRange(IEnumerable<object> entities);
        public void AddRange(params object[] entities);
        public Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
        public Task AddRangeAsync(params object[] entities);
        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        public EntityEntry Attach(object entity);
        public void AttachRange(params object[] entities);
        public void AttachRange(IEnumerable<object> entities);
        public EntityEntry Entry(object entity);
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        public object Find(Type entityType, params object[] keyValues);
        public ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        public ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);
        public ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        public ValueTask<object> FindAsync(Type entityType, params object[] keyValues);
        public IQueryable<TResult> FromExpression<TResult>(Expression<Func<IQueryable<TResult>>> expression);
        public int GetHashCode();
        public EntityEntry Remove(object entity);
        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        public void RemoveRange(params object[] entities);
        public void RemoveRange(IEnumerable<object> entities);
        public int SaveChanges(bool acceptAllChangesOnSuccess);
        public int SaveChanges();
        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public DbSet<TEntity> Set<TEntity>(string name) where TEntity : class;
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public EntityEntry Update(object entity);
        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        public void UpdateRange(params object[] entities);
        public void UpdateRange(IEnumerable<object> entities);
    }
}
