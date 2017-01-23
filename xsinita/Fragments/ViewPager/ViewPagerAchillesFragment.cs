using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.ViewPager;
using xsinita.Fragments.Base;

namespace xsinita.Fragments.ViewPager
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("xsinita.fragments.viewpager.ViewPagerAchillesFragment")]
    public class ViewPagerAchillesFragment : BaseFragment<ViewPagerAchillesViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            ShowHamburgerMenu = true;
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            return ignore;
        }



        protected override int FragmentId => Resource.Layout.ViewPager_Pages;
    }
}