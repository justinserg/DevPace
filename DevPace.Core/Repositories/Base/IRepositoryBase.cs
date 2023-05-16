using DevPace.Core.Entities;
using DevPace.Core.Specifications;

namespace DevPace.Core.Repositories.Base
{
    public interface IRepositoryBase<T, TId> where T : IEntityBase<int>
    {
        IQueryable<T> Table { get; }

        Task<T> GetByIdAsync(TId id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> SaveAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
    }
}
