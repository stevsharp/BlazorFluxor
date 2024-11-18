
using Application.Features.Item.DTOs;
using Application.Features.Item.Specification;

using Domain.Common;

using MediatR;

namespace Application.Features.Item.Queries.GetById;

public record GetItemByIdQuery : IRequest<ItemDto?>
{
    public required int Id { get; set; }
}

public class GettemIdQueryHandler(IRepository<BlazorAndFluxorCrud.Model.Item> repository) : IRequestHandler<GetItemByIdQuery, ItemDto?>
{
    private readonly IRepository<BlazorAndFluxorCrud.Model.Item> _repository = repository;

    public async Task<ItemDto?> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _repository.FirstOrDefaultAsync(new ItemsByIdSpecification<BlazorAndFluxorCrud.Model.Item>(request.Id));

        if (item is null)
            return null;
        
        return new ItemDto
        {
            Id = item.Id,
            Description = item.Description.Value,
            Name = item.Name.Value
        };
    }
}