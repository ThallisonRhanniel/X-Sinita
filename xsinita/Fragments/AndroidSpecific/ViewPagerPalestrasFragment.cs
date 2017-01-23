

using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using xsinita.Core.ViewModels.AndroidSpecific;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.ViewPager;
using xsinita.Fragments.Base;
using xsinita.Fragments.ViewPager;


namespace xsinita.Fragments.AndroidSpecific
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("xsinita.fragments.androidspecific.ViewPagerPalestrasFragment")]
    public class ViewPagerPalestrasFragment : BaseFragment<ViewPagerPalestrasViewModel>
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var viewPager = view.FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
            if (viewPager != null)
            {
                var fragments = new List<MvxCachingFragmentStatePagerAdapter.FragmentInfo>
                {
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("O Profissional Semideus", typeof(ViewPagerIsidroFragment), typeof(ViewPagerIsidroViewModel)),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("A mobilidade do ambiente .NET", typeof(ViewPagerAchillesFragment), typeof(ViewPagerAchillesViewModel)),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Técnicas de Invasão a Sistemas e Servidores", typeof(ViewPagerFelipeFragment), typeof(ViewPagerFelipeViewModel)),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Game Development: Press Start Button!", typeof(ViewPagerFranciscoFragment), typeof(ViewPagerFranciscoViewModel)),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Parque Tecnológico da Bahia: suas realizações e oportunidades", typeof(ViewPagerPericlesFragment),typeof(ViewPagerPericlesViewModel))
                };
                viewPager.Adapter = new MvxCachingFragmentStatePagerAdapter(Activity, ChildFragmentManager, fragments);
            }

            var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);

            return view;
        }

        protected override int FragmentId => Resource.Layout.ViewPager;
    }
}