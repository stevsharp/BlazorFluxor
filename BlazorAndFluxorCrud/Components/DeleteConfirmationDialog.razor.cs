using Microsoft.AspNetCore.Components;

using MudBlazor;

namespace BlazorAndFluxorCrud.Components;
public partial class DeleteConfirmationDialog
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    [EditorRequired]
    [Parameter]
    public string? ContentText { get; set; }

    [EditorRequired]
    [Parameter]
    public object Command { get; set; } = default!;
    private async Task Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));

        await Task.CompletedTask;
    }
    private void Cancel()
    {
        MudDialog.Cancel();
    }
}
