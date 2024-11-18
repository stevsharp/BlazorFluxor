
using Domain.Common;

using System.Linq.Expressions;

namespace Application.Features.Item.Specification;

public class NullSpecification<Item> : ISpecification<BlazorAndFluxorCrud.Model.Item>
{
    public Expression<Func<BlazorAndFluxorCrud.Model.Item, bool>>? Criteria => null;
    public List<Expression<Func<BlazorAndFluxorCrud.Model.Item, object>>> Includes { get; } = new();
}
