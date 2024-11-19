using Application.Features.Item.DTOs;
using BlazorAndFluxorCrud.State;

namespace BlazorAndFluxorCrud.Components.Pages;
public partial class AddItem
{
    private ItemDto newItem = new();

    private void HandleValidSubmit()
    {
        _Dispatcher.Dispatch(new AddItemAction(newItem));

        Navigation.NavigateTo("/");
    }
}
