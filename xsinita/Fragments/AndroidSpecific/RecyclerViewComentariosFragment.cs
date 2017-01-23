using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using xsinita.Core.ViewModels.AndroidSpecific;
using xsinita.Core.ViewModels.Base;
using xsinita.Fragments.Base;

namespace xsinita.Fragments.AndroidSpecific
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("xsinita.fragments.androidspecific.RecyclerViewComentariosFragment")]
    public class RecyclerViewComentariosFragment : BaseFragment<RecyclerViewComentariosViewModel>
    {

        private View view;
        private RecyclerView recyclerView;
        private LinearLayoutManager layoutManager;
        private MvxSwipeRefreshLayout swipeToRefresh;
        private AppBarLayout appBar;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            //var view = base.OnCreateView(inflater, container, savedInstanceState);
            view = base.OnCreateView(inflater, container, savedInstanceState);


            recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            if (recyclerView != null)
            {
                recyclerView.HasFixedSize = true;
                layoutManager = new LinearLayoutManager(Activity);
                recyclerView.SetLayoutManager(layoutManager);
            }

            //var linearLayout = view.FindViewById<LinearLayout>(Resource.Id.rootfragment);
            //Snackbar.Make(linearLayout, "Atualize deslizando os dedos para baixo", Snackbar.LengthLong)
            //        .SetAction("OK", action => { })
            //        .SetDuration(20000) // 10 segundos
            //        .Show();

            swipeToRefresh = view.FindViewById<MvxSwipeRefreshLayout>(Resource.Id.refresher);
            var appBar = Activity.FindViewById<AppBarLayout>(Resource.Id.appbar);
            if (appBar != null)
            {
                appBar.OffsetChanged += (sender, args) => swipeToRefresh.Enabled = args.VerticalOffset == 0;
            }

            return view;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();


            view.OnFinishTemporaryDetach();




        }

        protected override int FragmentId => Resource.Layout.fragment_recyclerview_comentarios;

    }
}