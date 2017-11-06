using MvvmCross.Core.ViewModels;
using xsinita.Core.Models;
using xsinita.Core.ViewModels.Feedback;
using xsinita.Core.ViewModels.Home;
using xsinita.Core.ViewModels.Menu;

namespace xsinita.Core.ViewModels.Base
{
    [Preserve(AllMembers = true)]
    public class MainViewModel : BaseViewModel
    {
        public void ShowMenu() // Chama duas ViewModels porque inicia 2 fragmentos. O menu e o home;
        {
            ShowViewModel<HomeViewModel>();
            ShowViewModel<MenuViewModel>();
        }

        public IMvxCommand ShowComentarCommand => new MvxCommand(() => ShowViewModel<EnviarComentarioViewModel>());
    }
}
