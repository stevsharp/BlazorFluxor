using Domain.Common;

namespace BlazorAndFluxorCrud.Model;

public class Item : Entity<int>
{
    public Name Name { get; set; } = default!;
    public Description Description { get; set; } = default!;
}
