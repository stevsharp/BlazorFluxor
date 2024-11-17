using Application.Features.Item.DTOs;

using BlazorAndFluxorCrud.Model;

using System.Collections.Immutable;

namespace BlazorAndFluxorCrud.State;

public record FetchCurrentItemAction(int ItemId);
public record LoadCurrentItemAction(ItemDto? CurrentItem);
public record FetchItemsAction;
public record FetchItemsResultAction(IEnumerable<ItemDto> Items);
public record AddItemAction(ItemDto NewItem);
public record AddItemResultAction(ItemDto AddedItem);
public record UpdateItemAction(ItemDto UpdatedItem);
public record UpdateItemResultAction(ItemDto UpdatedItem);
public record DeleteItemAction(int ItemId);
public record DeleteItemResultAction(int ItemId);

public record ItemState(ImmutableList<ItemDto> Items, bool IsLoading, string ErrorMessage, ItemDto CurrentItem = null)
{
    public static ItemState InitialState
    {
        get => new([], IsLoading: false, ErrorMessage: null);
    }
}

