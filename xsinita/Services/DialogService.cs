using Android.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Widget;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using xsinita.Core.Interfaces;

namespace xsinita.Services
{
    [Preserve(AllMembers = true)]
    public class DialogService : IDialogService
    {
        private static readonly IMvxAndroidCurrentTopActivity Top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
        private static readonly Activity _act = Top.Activity;
        readonly ProgressDialog _progress = new ProgressDialog(_act);

        public void ShowSnackbar(string message)
        {
            var linearLayout = _act.FindViewById<LinearLayout>(Resource.Id.root);
            Snackbar snackBar = Snackbar.Make(linearLayout, message, Snackbar.LengthLong);
            snackBar.SetAction("OK", action => { });
            snackBar.SetDuration(3000); // 3 segundos
            snackBar.Show();
        }

        public void ShowSnackbarCoordinatorLayout(string message)
        {
            var linearLayout = _act.FindViewById<CoordinatorLayout>(Resource.Id.root);
            Snackbar snackBar = Snackbar.Make(linearLayout, message, Snackbar.LengthLong);
            snackBar.SetAction("OK", action => { });
            snackBar.SetDuration(3000); // 3 segundos
            snackBar.Show();
        }

        public void ShowProgessDialog() // TODO: Atribuir a messagem na chamada do método.
        {
            _progress.Indeterminate = true;
            _progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            _progress.SetMessage("Enviando comentário ...");
            _progress.SetCancelable(false);
            _progress.Show();
            
        }

        public void DismissProgessDialog()
        {
            _progress.Dismiss();
        }
    }
}