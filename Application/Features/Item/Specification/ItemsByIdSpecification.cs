
using Domain.Common;

using System.Linq.Expressions;

namespace Application.Features.Item.Specification
{
    public class ItemsByIdSpecification<Item> : ISpecification<BlazorAndFluxorCrud.Model.Item>
    {
        public Expression<Func<BlazorAndFluxorCrud.Model.Item, bool>>? Criteria { get; }
        public List<Expression<Func<BlazorAndFluxorCrud.Model.Item, object>>> Includes { get; } = new();

        public ItemsByIdSpecification(int id)
        {
            Criteria = item => item.Id == id;
        }
    }
}