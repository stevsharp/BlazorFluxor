using BlazorAndFluxorCrud.Model;
using BlazorAndFluxorCrud.State;
using Fluxor;
using Microsoft.EntityFrameworkCore;

namespace BlazorAndFluxorCrud.Effects;

public class ItemEffects(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext;

    [EffectMethod]
    public async Task HandleFetchItemsAction(FetchItemsAction action, IDispatcher dispatcher)
    {
        var items = await _dbContext.Items.ToListAsync();

        dispatcher.Dispatch(new FetchItemsResultAction(items));
    }

    [EffectMethod]
    public async Task HandleAddItemAction(AddItemAction action, IDispatcher dispatcher)
    {
        var addedItem = (await _dbContext.Items.AddAsync(action.NewItem)).Entity;

        await _dbContext.SaveChangesAsync();

        dispatcher.Dispatch(new AddItemResultAction(addedItem));
    }

    [EffectMethod]
    public async Task HandleUpdateItemAction(UpdateItemAction action, IDispatcher dispatcher)
    {
        _dbContext.Items.Update(action.UpdatedItem);
        
        await _dbContext.SaveChangesAsync();

        dispatcher.Dispatch(new UpdateItemResultAction(action.UpdatedItem));
    }

    [EffectMethod]
    public async Task HandleDeleteItemAction(DeleteItemAction action, IDispatcher dispatcher)
    {
        var item = await _dbContext.Items.FindAsync(action.ItemId);

        if (item != null)
        {
            _dbContext.Items.Remove(item);

            await _dbContext.SaveChangesAsync();

            dispatcher.Dispatch(new DeleteItemResultAction(action.ItemId));
        }
    }
}
