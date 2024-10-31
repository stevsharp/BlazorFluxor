using BlazorAndFluxorCrud.Model;

using System.Collections.Immutable;

namespace BlazorAndFluxorCrud.State;

public record FetchItemsAction;
public record FetchItemsResultAction(List<Item> Items);
public record AddItemAction(Item NewItem);
public record AddItemResultAction(Item AddedItem);
public record UpdateItemAction(Item UpdatedItem);
public record UpdateItemResultAction(Item UpdatedItem);
public record DeleteItemAction(int ItemId);
public record DeleteItemResultAction(int ItemId);

public record ItemState(ImmutableList<Item> Items, bool IsLoading, string ErrorMessage)
{
    public static ItemState InitialState
    {
        get => new([], IsLoading: false, ErrorMessage: null);
    }
}

