

using BlazorAndFluxorCrud.Model;

using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;


public class Repository<T>(AppDbContext context) : IRepository<T> where T : Entity<int>
{
    private readonly AppDbContext _context = context;

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken token) =>
        await _context.Set<T>().FindAsync(id, token);


    public virtual async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken token = default)
    {
        return specification is null
            ? throw new ArgumentNullException(nameof(specification))
            : await ApplySpecification(specification).FirstOrDefaultAsync(token).ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken token)
    {
        var query = ApplySpecification(specification);

        return await query.ToListAsync(token);
    }

    public virtual async Task AddAsync(T entity, CancellationToken token)
    {
        await _context.Set<T>().AddAsync(entity, token);

        await _context.SaveChangesAsync(token);
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken token)
    {
        _context.Set<T>().Update(entity);

        await _context.SaveChangesAsync(token);
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken token)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync(token);
    }

    public async Task<int> CountAsync(ISpecification<T> specification, CancellationToken token)
    {
        var query = ApplySpecification(specification);
        return await query.CountAsync(token);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification) =>
        SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
}
