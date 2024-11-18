

using System.Linq.Expressions;

namespace Domain.Common;

public interface ISpecification<T> where T : Entity<int>
{
    Expression<Func<T, bool>>? Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
}