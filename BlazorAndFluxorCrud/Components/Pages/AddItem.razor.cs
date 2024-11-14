using BlazorAndFluxorCrud.Model;
using BlazorAndFluxorCrud.State;

namespace BlazorAndFluxorCrud.Components.Pages;
public partial class AddItem
{
    private Item newItem = new Item();

    private void HandleValidSubmit()
    {
        _Dispatcher.Dispatch(new AddItemAction(newItem));

        Navigation.NavigateTo("/");
    }
}
