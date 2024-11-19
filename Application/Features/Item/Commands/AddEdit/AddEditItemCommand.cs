using Application.Features.Item.Specification;

using BlazorAndFluxorCrud.Model;

using Domain.Common;

using MediatR;

namespace Application.Features.Item.Commands.AddEdit;

public class AddEditItemCommand : IRequest<int>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}

public class AddEditItemCommandHandler(IRepository<BlazorAndFluxorCrud.Model.Item> repository) : IRequestHandler<AddEditItemCommand, int>
{

    private readonly IRepository<BlazorAndFluxorCrud.Model.Item> _repository = repository;

    public async Task<int> Handle(AddEditItemCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Id > 0)
        {
            var itemForEdit = await _repository.FirstOrDefaultAsync(new ItemsByIdSpecification<BlazorAndFluxorCrud.Model.Item>(request.Id));

            if (itemForEdit is null)
                return 0;

            itemForEdit.UpdateDescription(request.Description ?? string.Empty);
            itemForEdit.UpdateDescription(request.Description ?? string.Empty);

            await repository.UpdateAsync(itemForEdit, cancellationToken);

            return 1;
         
        }
        else {

            var item = new BlazorAndFluxorCrud.Model.Item()
            {
                Description =  new Description(request.Description ?? string.Empty),
                Name = new Name(request.Name ?? string.Empty),
            };

            await repository.AddAsync(item,cancellationToken);

            return item.Id;
        }

    }
}

