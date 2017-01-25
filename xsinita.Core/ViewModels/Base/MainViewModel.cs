using MvvmCross.Core.ViewModels;
using xsinita.Core.ViewModels.Home;
using xsinita.Core.ViewModels.Menu;
using xsinita.Core.ViewModels.Pages;

namespace xsinita.Core.ViewModels.Base
{
    public class MainViewModel : BaseViewModel
    {
        public void ShowMenu() // ele Chama dois ViewModel porquê ele inicia 2 fragmentos o menu e o home;
        {
            ShowViewModel<HomeViewModel>();
            ShowViewModel<MenuViewModel>();

        }
        
        public IMvxCommand ShowComentarCommand
        {
            get { return new MvxCommand(ShowComentarExecuted); }
        }

        private void ShowComentarExecuted()
        {
            ShowViewModel<ComentarViewModel>();

        }

        public void Init(object hint)
        {
            // Can perform Vm data retrival here based on any
            // data passed in the hint object

            // ShowViewModel<SomeViewModel>(new { derp: "herp", durr: "derrrrrr" });
            // public class SomeViewModel : MvxViewModel
            // {
            //     public void Init(string derp, string durr)
            //     {
            //     }
            // }
        }

        
    }
}
