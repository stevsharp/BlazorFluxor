

namespace Application.Features.Item.DTOs;

public record ItemDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
