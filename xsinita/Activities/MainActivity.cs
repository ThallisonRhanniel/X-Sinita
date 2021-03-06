using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.InputMethods;
using MvvmCross.Droid.Support.V7.AppCompat;
using xsinita.Core.Models;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Programacao.ViewPager;


namespace xsinita.Activities
{
    [Activity(
        Label = "XI Sinita",
        Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop,
        Name = "xsinita.activities.MainActivity"
    )]
    [Preserve(AllMembers = true)]
    public class MainActivity : MvxCachingFragmentCompatActivity<MainViewModel> 
    {

        protected override void ShowFragment(
            string tag,
            int contentId,
            Bundle bundle,
            bool forceAddToBackStack = false,
            bool forceReplaceFragment = false)
        {
            if (tag.Equals(typeof(ViewPagerViewModel).FullName))
                forceReplaceFragment = true;

            base.ShowFragment(tag, contentId, bundle, forceAddToBackStack, forceReplaceFragment);
        }


        public DrawerLayout DrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null)
                ViewModel.ShowMenu();

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                Alert();
            //base.OnBackPressed();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null) return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }

        public void Alert()
        {
            var adb = new AlertDialog.Builder(this);
            adb.SetTitle("Confirma��o");
            adb.SetMessage("Ol�! Antes de sair deixe um coment�rio sobre o Evento");
            adb.SetPositiveButton("Sair", (sender, args) => { Exit(); });
            adb.SetNegativeButton("Cancelar ", (sender, args) => { });
            adb.SetNeutralButton("Comentar", (sender, args) => { ViewModel.ShowComentarCommand.Execute(); });
            adb.SetCancelable(false);
            adb.Create().Show();
        }

        public void Exit()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        
    }
}