using BlazorAndFluxorCrud.State;

namespace BlazorAndFluxorCrud.Components.Pages;
public partial class Home
{
    protected override void OnInitialized()
    {
        ItemState.StateChanged += (s, e) => StateHasChanged();
    }
    private Task LoadItemsDirect()
    {
        _Dispatcher.Dispatch(new FetchItemsAction());

        return Task.CompletedTask;
    }

    private Task NavigateToEditPage(int id = 0)
    {
        Navigation.NavigateTo($"/edit-item/{id}");

        return Task.CompletedTask;
    }
    private Task Delete(int id)
    {
        _Dispatcher.Dispatch(new DeleteItemAction(id));

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        ItemState.StateChanged -= (s, e) => StateHasChanged();
    }
}
