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

    public void Dispose()
    {
        ItemState.StateChanged -= (s, e) => StateHasChanged();
    }
}
