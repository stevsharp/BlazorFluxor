using BlazorAndFluxorCrud.Model;
using BlazorAndFluxorCrud.State;

using Microsoft.AspNetCore.Components;

using MudBlazor;

namespace BlazorAndFluxorCrud.Components.Pages;
public partial class EditItemForm
{
    [Parameter] 
    public int ItemId { get; set; }

    private Item itemToEdit = new();

    protected override Task OnInitializedAsync()
    {
        try
        {
            Console.WriteLine($"Loaded EditItem with ItemId: {ItemId}");

            ItemState.StateChanged += OnItemStateChanged;

            _Dispatcher.Dispatch(new FetchCurrentItemAction(ItemId));

            if (itemToEdit is null)
            {
                _snackBar.Add("Item not found !!!", Severity.Error);

                Navigation.NavigateTo("/");

            }
        }
        catch (Exception ex)
        {
            _snackBar.Add(ex.Message, Severity.Error);
        }

        return base.OnInitializedAsync();
    }

    private void HandleValidSubmit()
    {
        _Dispatcher.Dispatch(new UpdateItemAction(itemToEdit ?? throw new Exception("Item is null !!")));

        Navigation.NavigateTo("/"); 
    }

    private void OnItemStateChanged(object? sender, EventArgs e)
    {
        itemToEdit = ItemState.Value.CurrentItem;

        StateHasChanged(); 
    }

    public void Dispose()
    {
        ItemState.StateChanged -= OnItemStateChanged;
    }
}
