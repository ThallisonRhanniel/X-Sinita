using xsinita.Core.ViewModels.Home;
using xsinita.Core.ViewModels.Menu;

namespace xsinita.Core.ViewModels.Base
{
    public class MainViewModel : BaseViewModel
    {
        public void ShowMenu() // ele Chama dois ViewModel porquê ele inicia 2 fragmentos o menu e o home;
        {
            ShowViewModel<HomeViewModel>();
            ShowViewModel<MenuViewModel>();

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

        public override void Start()
        {
            //base.Start();
        }
    }
}
