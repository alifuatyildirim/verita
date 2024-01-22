using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Verita.Repository.Mssql.GenericRepository
{
    public interface IRepository : IQueryRepository
    {
        Task<IDbContextTransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel = IsolationLevel.Unspecified,
            CancellationToken cancellationToken = default);

        Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken = default);
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters,
            CancellationToken cancellationToken = default);

        void ClearChangeTracker();

        void Add<TEntity>(TEntity entity) where TEntity : class;

        Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class;

        void Add<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class;

        Task AddAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            where TEntity : class;

        void Update<TEntity>(TEntity entity)
            where TEntity : class;

        void Update<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class;

        void Remove<TEntity>(TEntity entity)
            where TEntity : class;

        void Remove<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public interface IRepository<TDbContext> : IRepository
    {
    }
}