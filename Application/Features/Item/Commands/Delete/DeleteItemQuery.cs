using Application.Features.Item.Specification;
using Domain.Common;
using MediatR;

namespace Application.Features.Item.Commands.Delete;

public record DeleteItemQuery : IRequest<int>
{
    public required int Id { get; set; }
}

public class DeleteItemQueryHandler(IRepository<BlazorAndFluxorCrud.Model.Item> repository) : IRequestHandler<DeleteItemQuery, int>
{
    private readonly IRepository<BlazorAndFluxorCrud.Model.Item> _repository = repository;

    public async Task<int> Handle(DeleteItemQuery request, CancellationToken cancellationToken)
    {
        var item = await _repository.FirstOrDefaultAsync(new ItemsByIdSpecification<BlazorAndFluxorCrud.Model.Item>(request.Id));

        if (item is null)
            return 0;

        await repository.DeleteAsync(item, cancellationToken);

        return 1;
    }

}
