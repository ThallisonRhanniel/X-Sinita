using Android.App;
using Android.Support.Design.Widget;
using Android.Widget;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using xsinita.Core.Interfaces;

namespace xsinita.Services
{
    public class DialogService : IDialogService
    {
        static readonly IMvxAndroidCurrentTopActivity Top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
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

        public void ShowProgessDialog()
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