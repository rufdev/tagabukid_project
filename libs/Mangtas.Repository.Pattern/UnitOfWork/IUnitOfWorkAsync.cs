using System.Threading;
using System.Threading.Tasks;
using Mangtas.Repository.Pattern.Infrastructure;
using Mangtas.Repository.Pattern.Repositories;

namespace Mangtas.Repository.Pattern.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}