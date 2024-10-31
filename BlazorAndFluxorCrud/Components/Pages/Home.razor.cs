using BlazorAndFluxorCrud.State;

using MudBlazor;

using static MudBlazor.CategoryTypes;

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
    private async Task Delete(int id)
    {
         await _dialogUIService.ShowDeleteConfirmationDialog(new object(), "Delete Item", $"Delete Item with Id : {id}",
         async () =>
         {
             await OnDelete(id);
         },
         async () =>
         {
             _snackBar.Add("Deletion canceled by the user.", Severity.Info);

         }); 
    }

    private Task OnDelete(int id)
    {
        _Dispatcher.Dispatch(new DeleteItemAction(id));

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        ItemState.StateChanged -= (s, e) => StateHasChanged();
    }
}
