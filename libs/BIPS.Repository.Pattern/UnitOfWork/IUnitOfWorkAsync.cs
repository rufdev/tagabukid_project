using System.Threading;
using System.Threading.Tasks;
using BIPS.Repository.Pattern.Infrastructure;
using BIPS.Repository.Pattern.Repositories;

namespace BIPS.Repository.Pattern.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}