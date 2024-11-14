using BlazorAndFluxorCrud.State;

using Fluxor;

namespace BlazorAndFluxorCrud.Feature;

public class ItemFeature : Feature<ItemState>
{
    public override string GetName() => "Item";

    protected override ItemState GetInitialState() =>
        new([], IsLoading: false, ErrorMessage: null);
}
