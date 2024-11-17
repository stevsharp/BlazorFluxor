using Domain.Common;

namespace BlazorAndFluxorCrud.Model;

public class Item : Entity<int>
{
    public Name Name { get; init; } = default!;
    public Description Description { get; init; } = default!;
}
