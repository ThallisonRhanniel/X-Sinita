using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Feedback;
using xsinita.Fragments.Base;

namespace xsinita.Fragments.Feedback
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("xsinita.fragments.Feedback.EnviarComentarioFragment")]
    public class EnviarComentarioFragment : BaseFragment<EnviarComentarioViewModel>
    {

        private View _view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            _view = base.OnCreateView(inflater, container, savedInstanceState);

            return _view;
        }

        protected override int FragmentId => Resource.Layout.fragment_comentar;

    }
}