using Domain.Common;

namespace BlazorAndFluxorCrud.Model;

public class Item : Entity<int>
{
    public Name Name { get; set; } = default!;
    public Description Description { get; set; } = default!;

    public void UpdateDescription(string value)
    {
        this.Description = this.Description with { Value = value };
    }

    public void UpdateName(string value)
    {
        this.Name = this.Name with { Value = value };
    }
}