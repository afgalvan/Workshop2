using System.Threading;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public interface IMutableRepository<in TId, TEntity> : IImmutableRepository<TId, TEntity>
    {
        public Task RemoveById(TId id, CancellationToken cancellation);
        public Task UpdateById(TId id, TEntity newData, CancellationToken cancellation);
    }
}
