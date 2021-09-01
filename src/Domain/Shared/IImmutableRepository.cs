using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public interface IImmutableRepository<in TId, TEntity>
    {
        public Task<TEntity> Save(TEntity entity, CancellationToken cancellation);
        public Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellation);
        public Task<TEntity> GetById(TId id, CancellationToken cancellation);
    }
}
