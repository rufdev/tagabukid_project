using System.Threading;
using System.Threading.Tasks;
using BIPS.Repository.Pattern.Infrastructure;

namespace BIPS.Repository.Pattern.Repositories
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : IObjectState
    {
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
}