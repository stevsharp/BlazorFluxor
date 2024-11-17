using Application.Features.Item.Specification;

using BlazorAndFluxorCrud.Model;
using BlazorAndFluxorCrud.State;

using Domain.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorAndFluxorCrud.Components.Pages;
public partial class Home
{
    [Inject]
    public IRepository<Item> _repository { get; set; }

    protected override void OnInitialized()
    {
        try
        {
            // Test
            // var da = _repository.ListAsync(new NullSpecification<Item>(), CancellationToken.None).Result;
        }
        catch (Exception ex)
        {
            var e = ex;
        }


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
