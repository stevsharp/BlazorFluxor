using BlazorAndFluxorCrud.Model;
using BlazorAndFluxorCrud.State;
using Fluxor;
using System.Collections.Immutable;

namespace BlazorAndFluxorCrud.Feature;

public class ItemFeature : Feature<ItemState>
{
    public override string GetName() => "Item";

    protected override ItemState GetInitialState() =>
        new([], IsLoading: false, ErrorMessage: null);
}
