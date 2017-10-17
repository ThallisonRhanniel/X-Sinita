using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Home;
using xsinita.Fragments.Base;

namespace xsinita.Fragments.Home
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("xsinita.fragments.home.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState); ;
        }

        protected override int FragmentId => Resource.Layout.fragment_home;
    }
}