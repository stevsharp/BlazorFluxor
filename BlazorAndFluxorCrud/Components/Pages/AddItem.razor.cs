using Application.Features.Item.Commands.AddEdit;

using BlazorAndFluxorCrud.Model;
using BlazorAndFluxorCrud.State;

namespace BlazorAndFluxorCrud.Components.Pages;
public partial class AddItem
{
    private AddEditItemCommand newItem = new();

    private void HandleValidSubmit()
    {
        //_Dispatcher.Dispatch(new AddItemAction(newItem));

        Navigation.NavigateTo("/");
    }
}
