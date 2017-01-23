using System;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using xsinita.Activities;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Menu;

namespace xsinita.Fragments.Menu
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("xsinita.fragments.menu.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.fragment_navigation, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_home).SetChecked(true);

            return view;
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
                    ((MainActivity)Activity).Title = "X Sinita";
                    break;
                case Resource.Id.nav_palestras:
                    ViewModel.ShowPalestrasCommand.Execute();
                    ((MainActivity)Activity).Title = "Palestras";
                    break;
                case Resource.Id.nav_minicurso:
                    ViewModel.ShowMinicursoCommand.Execute();
                    ((MainActivity)Activity).Title = "Minicursos";
                    break;
                case Resource.Id.nav_workshops:
                    ViewModel.ShowWorkshopCommand.Execute();
                    ((MainActivity)Activity).Title = "Workshop";
                    break;
                case Resource.Id.nav_comentar:
                    ViewModel.ShowComentarCommand.Execute();
                    ((MainActivity)Activity).Title = "Comentar sobre o Evento";
                    break;
                case Resource.Id.nav_comentarios:
                    ((MainActivity)Activity).Title = "Comentários sobre o Evento";
                    ViewModel.ShowComentariosCommand.Execute();
                    break;
            }
        }
    }
}