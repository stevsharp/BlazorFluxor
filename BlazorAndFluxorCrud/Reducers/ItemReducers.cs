using BlazorAndFluxorCrud.State;
using Fluxor;
namespace BlazorAndFluxorCrud.Reducers;

public static class ItemReducers
{

    [ReducerMethod]
    public static ItemState ReduceFetchItemsResultAction(ItemState state, FetchItemsResultAction action)
    {
        return state with { Items = [.. action.Items], IsLoading = false };
    }

    [ReducerMethod]
    public static ItemState ReduceAddItemResultAction(ItemState state, AddItemResultAction action) =>
        state with { Items = state.Items.Add(action.AddedItem), IsLoading = false };

    [ReducerMethod]
    public static ItemState ReduceUpdateItemAction(ItemState state, UpdateItemAction action)
    {
        var updatedItems = state.Items
            .Select(item => item.Id == action.UpdatedItem.Id ? action.UpdatedItem : item)
            .ToList();

        return state with { Items = [.. updatedItems], IsLoading = false };
    }

    [ReducerMethod]
    public static ItemState ReduceUpdateItemResultAction(ItemState state, UpdateItemResultAction action)
    {
        return state with { Items = state
            .Items.Replace(state
            .Items.First(i => i.Id == action.UpdatedItem.Id), 
            action.UpdatedItem), 
            IsLoading = false };
    }

    [ReducerMethod]
    public static ItemState ReduceLoadCurrentItemAction(ItemState state, LoadCurrentItemAction action)
    {
        return new ItemState(state.Items, IsLoading: false, "", CurrentItem: action.CurrentItem);
    }

    [ReducerMethod]
    public static ItemState ReduceDeleteItemResultAction(ItemState state, DeleteItemResultAction action) =>
        state with { 
            Items = state.
            Items.Remove(state.Items.First(i => i.Id == action.ItemId)), 
            IsLoading = false };
}
