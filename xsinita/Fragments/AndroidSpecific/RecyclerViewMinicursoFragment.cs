using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platform.Core;
using xsinita.Core.ViewModels.AndroidSpecific;
using xsinita.Core.ViewModels.Base;

using xsinita.Fragments.Base;

namespace xsinita.Fragments.AndroidSpecific
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame ,true)]
    [Register("xsinita.fragments.androidspecific.RecyclerViewFragment")]
    public class RecyclerViewFragment : BaseFragment<RecyclerViewMinicursoViewModel>
    {
        private View view;
        private MvxRecyclerView recyclerView;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            view = base.OnCreateView(inflater, container, savedInstanceState);

            recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.my_recycler_view);
            if (recyclerView != null)
            {
                
                recyclerView.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerView.SetLayoutManager(layoutManager);
            }



            
            return view;
        }

        public override void OnDestroyView()
        {
            
        }

        protected override int FragmentId => Resource.Layout.fragment_recyclerview;

    }
}