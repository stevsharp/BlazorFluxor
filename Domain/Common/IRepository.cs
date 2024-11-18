
namespace Domain.Common;

public interface IRepository<T> where T : Entity<int>
{
    Task<T?> GetByIdAsync(int id, CancellationToken token);
    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken token = default);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken token);
    Task AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken token);
}
