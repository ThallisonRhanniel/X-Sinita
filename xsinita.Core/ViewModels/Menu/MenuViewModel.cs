using MvvmCross.Core.ViewModels;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Feedback;
using xsinita.Core.ViewModels.Home;
using xsinita.Core.ViewModels.Programacao.ViewPager;

namespace xsinita.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {

        public IMvxCommand ShowHomeCommand => new MvxCommand(() => ShowViewModel<HomeViewModel>());
       
        public IMvxCommand ShowEnviarComentarioCommand => new MvxCommand(() => ShowViewModel<EnviarComentarioViewModel>());
        
        public IMvxCommand ShowProgramacaoCommand => new MvxCommand(() => ShowViewModel<ViewPagerViewModel>());
        
        public IMvxCommand ShowMostrarComentariosCommand => new MvxCommand(() => ShowViewModel<MostrarComentariosViewModel>());
               
    }
}
