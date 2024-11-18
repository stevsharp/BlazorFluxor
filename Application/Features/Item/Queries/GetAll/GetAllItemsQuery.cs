using Application.Features.Item.DTOs;
using Application.Features.Item.Specification;
using Domain.Common;

using MediatR;

using System.Runtime.CompilerServices;

namespace Application.Features.Item.Queries.GetAll;

public record GetAllItemsQuery : IStreamRequest<ItemDto> { }

public class GetAllItemsQueryHandler(IRepository<BlazorAndFluxorCrud.Model.Item> repository) 
    : IStreamRequestHandler<GetAllItemsQuery, ItemDto>
{
    private readonly IRepository<BlazorAndFluxorCrud.Model.Item> _repository = repository;

    public async IAsyncEnumerable<ItemDto> Handle(GetAllItemsQuery request, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var data = await _repository.ListAsync(new NullSpecification<BlazorAndFluxorCrud.Model.Item>(), cancellationToken);

        foreach (var item in data)
        {
            yield return new ItemDto
            {
                Id = item.Id,
                Description = item.Description.Value,
                Name = item.Name.Value,
            };
        }
    }
}
