using BlazorAndFluxorCrud.Components;

using MudBlazor;

namespace BlazorAndFluxorCrud.Service;

public class DialogUIService(IDialogService dialogService, ISnackbar snackbar)
{
    private readonly IDialogService _dialogService = dialogService;
    private readonly ISnackbar _snackbar = snackbar;

    public async Task ShowDeleteConfirmationDialog(object dto, string title, string contentText,Func<Task> onConfirm, Func<Task>? onCancel = null)
    {
        var parameters = new DialogParameters
            {
                { nameof(DeleteConfirmationDialog.ContentText), contentText },
                { nameof(DeleteConfirmationDialog.Command), dto }
            };

        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };
        var dialog = _dialogService.Show<DeleteConfirmationDialog>(title, parameters, options);

        var result = await dialog.Result;

        if (result is not null && !result.Canceled)
        {
            await onConfirm();
        }
        else if (onCancel != null)
        {
            await onCancel();
        }
    }

}