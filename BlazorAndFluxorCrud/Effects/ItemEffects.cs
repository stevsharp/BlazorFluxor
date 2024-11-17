using Application.Features.Item.DTOs;
using Application.Features.Item.Queries.GetAll;
using BlazorAndFluxorCrud.Model;
using BlazorAndFluxorCrud.Service;
using BlazorAndFluxorCrud.State;
using Fluxor;
using MediatR;
using MudBlazor;

namespace BlazorAndFluxorCrud.Effects;

public class ItemEffects(AppDbContext dbContext,
    ISnackbar snackBar,
    DialogUIService DialogUIService,
    IMediator mediator
    )
{
    private readonly AppDbContext _dbContext = dbContext;

    private readonly IMediator _mediator = mediator;

    [EffectMethod]
    public async Task HandleFetchCurrentItemAction(FetchCurrentItemAction action, IDispatcher dispatcher)
    {
        //var item = await _dbContext.Items.FindAsync(action.ItemId);

        //if (item is not null)
        //{
        //    dispatcher.Dispatch(new LoadCurrentItemAction(item));
        //}
        //else
        //{
        //    dispatcher.Dispatch(new LoadCurrentItemAction(null)); // or handle as appropriate
        //}
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
        //var addedItem = (await _dbContext.Items.AddAsync(action.NewItem)).Entity;

        //await _dbContext.SaveChangesAsync();

        //snackBar.Add($"Item Addedd succesfully {addedItem.Id}", Severity.Success);

        //dispatcher.Dispatch(new AddItemResultAction(addedItem));
    }

    [EffectMethod]
    public async Task HandleUpdateItemAction(UpdateItemAction action, IDispatcher dispatcher)
    {
        //_dbContext.Items.Update(action.UpdatedItem);

        //await _dbContext.SaveChangesAsync();

        //snackBar.Add($"Item Updated succesfully {action.UpdatedItem.Id}", Severity.Success);

        //dispatcher.Dispatch(new UpdateItemResultAction(action.UpdatedItem));
    }

    [EffectMethod]
    public async Task HandleDeleteItemAction(DeleteItemAction action, IDispatcher dispatcher)
    {
        await DialogUIService.ShowDeleteConfirmationDialog(new object(), "Delete Item", $"Delete Item with Id : {action.ItemId}",
        async () =>
        {
            var item = await _dbContext.Items.FindAsync(action.ItemId);

            if (item is not null)
            {
                _dbContext.Items.Remove(item);

                await _dbContext.SaveChangesAsync();

                snackBar.Add($"Item Deleted succesfully {item.Id}", Severity.Success);

                dispatcher.Dispatch(new DeleteItemResultAction(action.ItemId));
            }
        },
        async () =>
        {
            snackBar.Add("Deletion canceled by the user.", Severity.Info);
        });
    }
}
