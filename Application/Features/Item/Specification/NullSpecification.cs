
using Domain.Common;

using System.Linq.Expressions;

namespace Application.Features.Item.Specification;

public class NullSpecification<Item> : ISpecification<Item>
{
    public Expression<Func<Item, bool>>? Criteria => null;
    public List<Expression<Func<Item, object>>> Includes { get; } = new();
}
