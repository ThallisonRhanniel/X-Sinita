using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Pages;
using xsinita.Fragments.Base;

namespace xsinita.Fragments.Pages
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("xsinita.fragments.home.ComentarFragment")]
    public class ComentarFragment : BaseFragment<ComentarViewModel>
    {
        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            ShowHamburgerMenu = true; // só alterar para True para mostrar nas telas que eu quiser
            view = base.OnCreateView(inflater, container, savedInstanceState);
            var buttonEviar = view.FindViewById<Button>(Resource.Id.btnEnviar);
            buttonEviar.Click += (sender, args) => snack();
            
            return view;
        }

        public void snack()
        {
            
            var mensagemSucess = ViewModel.EnviarComentario();
            if (mensagemSucess.Result)
            {
                var linearLayout = view.FindViewById<LinearLayout>(Resource.Id.root);
                Snackbar.Make(linearLayout, "Comentário enviado com sucesso", Snackbar.LengthLong)
                            .SetAction("OK", action => { })
                            .SetDuration(10000) // 10 segundos
                            .Show();
            }
            else
            {
                var linearLayout = view.FindViewById<LinearLayout>(Resource.Id.root);
                Snackbar.Make(linearLayout, "Erro ao enviar comentário", Snackbar.LengthLong)
                            .SetAction("OK", action => { })
                            .SetDuration(10000) // 10 segundos
                            .Show();
            }
            
        }
        

        protected override int FragmentId => Resource.Layout.fragment_comentar;
    }
}