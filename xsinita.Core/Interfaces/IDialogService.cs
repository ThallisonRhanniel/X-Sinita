namespace xsinita.Core.Interfaces
{
    public interface IDialogService
    {
        void ShowSnackbar(string message);

        void ShowSnackbarCoordinatorLayout(string message);

        void ShowProgessDialog();

        void DismissProgessDialog();
    }
}
