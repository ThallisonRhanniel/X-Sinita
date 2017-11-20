using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Java.IO;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platform.WeakSubscription;

using xsinita.Activities;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Menu;


namespace xsinita.Fragments.Menu
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("xsinita.fragments.menu.MenuFragment")]
    [Preserve(AllMembers = true)]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;
        private static int PICK_IMAGE = 1234;
        private IDisposable _itemSelectedToken;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.fragment_navigation, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_home).SetChecked(true);

            _itemSelectedToken = ViewModel.WeakSubscribe(() => ViewModel.ClickButton,
                    (sender, args) =>
                    {
                        if (ViewModel.ClickButton == true)
                        {
                            Task.Factory.StartNew(PickImage);
                            ViewModel.ClickButton = false;
                        }
                    });

            //get
            ISharedPreferences pref = PreferenceManager.GetDefaultSharedPreferences(Context);
            var imagePerfil = new File(pref.GetString("imagePath", ""));
            if (imagePerfil.Exists())
                ViewModel.iconUrl = imagePerfil.AbsolutePath;

            return view;
        }

        private void PickImage()
        {
            Intent i = new Intent(Intent.ActionPick, Android.Provider.MediaStore.Images.Media.InternalContentUri);
            StartActivityForResult(Intent.CreateChooser(i, "Selecione uma imagem"), PICK_IMAGE);
        }

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            if (requestCode == PICK_IMAGE && data != null)
            {
                var imagemGaleria = GetPathToImage(data.Data);
                SavePreferenceImage(imagemGaleria);
                ViewModel.iconUrl = imagemGaleria;
            }
                

            base.OnActivityResult(requestCode, resultCode, data);
        }



        private void SavePreferenceImage(string imagePath)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Context);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("imagePath", imagePath);
            editor.Commit();
            editor.Apply();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if (item != _previousMenuItem)
            {
                _previousMenuItem?.SetChecked(false);
            }

            item.SetCheckable(true);
            item.SetChecked(true);

            _previousMenuItem = item;

            Navigate(item.ItemId);

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((MainActivity)Activity).DrawerLayout.CloseDrawers();

            // add a small delay to prevent any UI issues
            await Task.Delay(TimeSpan.FromMilliseconds(250));
           

            switch (itemId)
            {
                case Resource.Id.nav_home:
                    ViewModel.ShowHomeCommand.Execute();
                    ((MainActivity)Activity).Title = "XI Sinita";
                    break;
                case Resource.Id.nav_programacao:
                    ViewModel.ShowProgramacaoCommand.Execute();
                    ((MainActivity)Activity).Title = "Programação";
                    break;
                case Resource.Id.nav_comentar:
                    ViewModel.ShowEnviarComentarioCommand.Execute();
                    ((MainActivity)Activity).Title = "Comentar sobre o Evento";
                    break;
                case Resource.Id.nav_comentarios:
                    ((MainActivity)Activity).Title = "Comentários sobre o Evento";
                    ViewModel.ShowMostrarComentariosCommand.Execute();
                    break;
            }
        }


        #region Get the Path of Selected Image
        private string GetPathToImage(Android.Net.Uri uri)
        {
            string path = null;
            // The projection contains the columns we want to return in our query.
            string[] projection = new[] { Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data };
            using (ICursor cursor = Activity.ManagedQuery(uri, projection, null, null, null))
            {
                if (cursor != null)
                {
                    int columnIndex = cursor.GetColumnIndexOrThrow(Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
                    cursor.MoveToFirst();
                    path = cursor.GetString(columnIndex);
                }
            }
            return path;
        }
        #endregion
    }
}