﻿using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Programacao.Pages;
using xsinita.Core.ViewModels.Programacao.ViewPager;
using xsinita.Fragments.Base;
using xsinita.Fragments.Programacao.Pages;

namespace xsinita.Fragments.Programacao.ViewPager
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("xsinita.fragments.programacao.ViewPager")]
    public class ViewPagerProgramacao : BaseFragment<ViewPagerViewModel>
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
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Minicursos", typeof(RecyclerViewPagesFragment), typeof(RecyclerViewPagesViewModel), new { index = "Minicursos"} ),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Palestras", typeof(RecyclerViewPagesFragment), typeof(RecyclerViewPagesViewModel), new { index = "Palestras"}),
                    new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Workshop", typeof(RecyclerViewPagesFragment), typeof(RecyclerViewPagesViewModel), new { index = "Workshop"})
                };
                viewPager.Adapter = new MvxCachingFragmentStatePagerAdapter(Activity, ChildFragmentManager, fragments);
            }

            var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);

            return view;
        }

        protected override int FragmentId => Resource.Layout.fragment_viewpager;
    }
}