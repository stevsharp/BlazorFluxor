using Application.Features.Item.Commands.AddEdit;
using Application.Features.Item.Commands.Delete;
using Application.Features.Item.DTOs;
using Application.Features.Item.Queries.GetAll;
using Application.Features.Item.Queries.GetById;
using BlazorAndFluxorCrud.Service;
using BlazorAndFluxorCrud.State;

using Fluxor;

using MediatR;

using MudBlazor;

namespace BlazorAndFluxorCrud.Effects;

public class ItemEffects(
    ISnackbar snackBar,
    DialogUIService DialogUIService,
    IMediator mediator
    )
{

    private readonly IMediator _mediator = mediator;

    [EffectMethod]
    public async Task HandleFetchCurrentItemAction(FetchCurrentItemAction action, IDispatcher dispatcher)
    {

        var item = await _mediator.Send(new GetItemByIdQuery { Id = action.ItemId }).ConfigureAwait(false);

        if (item is not null)
        {
            dispatcher.Dispatch(new LoadCurrentItemAction(item));
        }
        else
        {
            dispatcher.Dispatch(new LoadCurrentItemAction(null)); // or handle as appropriate
        }
    }

    [EffectMethod]
    public async Task HandleFetchItemsAction(FetchItemsAction action, IDispatcher dispatcher)
    {
        var listOfItems = new List<ItemDto>();

        await foreach (var item in _mediator.CreateStream(new GetAllItemsQuery(), CancellationToken.None))
        {
            listOfItems.Add(item);
        }

        dispatcher.Dispatch(new FetchItemsResultAction(listOfItems));
    }

    [EffectMethod]
    public async Task HandleAddItemAction(AddItemAction action, IDispatcher dispatcher)
    {
        var returnId = await _mediator.Send(new AddEditItemCommand { Id = action.NewItem.Id , Description = action.NewItem.Description , 
            Name = action.NewItem.Name })
            .ConfigureAwait(false);

        if (returnId > 0)
        {
            snackBar.Add($"Item Addedd succesfully {returnId}", Severity.Success);

            dispatcher.Dispatch(new AddItemResultAction(new ItemDto
            {
                Name = action.NewItem.Name,
                Description = action.NewItem.Description,
                Id = returnId
            }));
        }

    }

    [EffectMethod]
    public async Task HandleUpdateItemAction(UpdateItemAction action, IDispatcher dispatcher)
    {
        var returnId = await _mediator.Send(new AddEditItemCommand
        {
            Id = action.UpdatedItem.Id,
            Description = action.UpdatedItem.Description,
            Name = action.UpdatedItem.Name
        })
          .ConfigureAwait(false);

        if (returnId > 0)
        {
            snackBar.Add($"Item Updated succesfully {action.UpdatedItem.Id}", Severity.Success);

            dispatcher.Dispatch(new UpdateItemResultAction(action.UpdatedItem));
        }
    }

    [EffectMethod]
    public async Task HandleDeleteItemAction(DeleteItemAction action, IDispatcher dispatcher)
    {
        await DialogUIService.ShowDeleteConfirmationDialog(new object(), "Delete Item", $"Delete Item with Id : {action.ItemId}",
        async () =>
        {
            var itemWasDeleted = await _mediator.Send(new DeleteItemQuery { Id = action.ItemId }).ConfigureAwait(false);

            if (itemWasDeleted > 0)
            {
                snackBar.Add($"Item Deleted succesfully {itemWasDeleted}", Severity.Success);

                dispatcher.Dispatch(new DeleteItemResultAction(action.ItemId));
            }

        },
        async () =>
        {
            snackBar.Add("Deletion canceled by the user.", Severity.Info);
        });
    }
}
