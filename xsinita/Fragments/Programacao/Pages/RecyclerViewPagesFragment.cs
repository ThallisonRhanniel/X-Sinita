using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;

using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Programacao.Pages;
using xsinita.Fragments.Base;

namespace xsinita.Fragments.Programacao.Pages
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("xsinita.fragments.programacao.pages.RecyclerViewPagesFragment")]
    public class RecyclerViewPagesFragment : BaseFragment<RecyclerViewPagesViewModel>
    {

        private View _view;
        private RecyclerView _recyclerView;
        private LinearLayoutManager _layoutManager;
        private MvxSwipeRefreshLayout _swipeToRefresh;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            //var view = base.OnCreateView(inflater, container, savedInstanceState);
            _view = base.OnCreateView(inflater, container, savedInstanceState);


            _recyclerView = _view.FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            if (_recyclerView != null)
            {
                _recyclerView.HasFixedSize = true;
                _layoutManager = new LinearLayoutManager(Activity);
                _recyclerView.SetLayoutManager(_layoutManager);
            }

            _swipeToRefresh = _view.FindViewById<MvxSwipeRefreshLayout>(Resource.Id.refresher);
            _swipeToRefresh.SetColorSchemeColors(Color.Red.ToArgb(), Color.Blue.ToArgb(), Color.Green.ToArgb(), Color.Gold.ToArgb());
            var appBar = Activity.FindViewById<AppBarLayout>(Resource.Id.appbar);
            if (appBar != null)
            {
                appBar.OffsetChanged += (sender, args) => _swipeToRefresh.Enabled = args.VerticalOffset == 0;
            }

            return _view;
        }


        protected override int FragmentId => Resource.Layout.fragment_viewpager_pages;

    }
}