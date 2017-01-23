
using MvvmCross.Core.ViewModels;
using xsinita.Core.ViewModels.AndroidSpecific;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Home;
using xsinita.Core.ViewModels.Pages;

namespace xsinita.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        #region Cross Platform Commands & Handlers


        public IMvxCommand ShowHomeCommand
        {
            get { return new MvxCommand(ShowHomeExecuted); }
        }

        private void ShowHomeExecuted()
        {
            ShowViewModel<HomeViewModel>();

        }

        public IMvxCommand ShowComentarCommand
        {
            get { return new MvxCommand(ShowComentarExecuted); }
        }

        private void ShowComentarExecuted()
        {
            ShowViewModel<ComentarViewModel>();

        }



        #endregion

        #region Android Specific Demos

        public IMvxCommand ShowMinicursoCommand
        {
            get { return new MvxCommand(ShowMinicursoExecuted); }
        }

        private void ShowMinicursoExecuted()
        {
            ShowViewModel<RecyclerViewMinicursoViewModel>();

        }

        public IMvxCommand ShowWorkshopCommand
        {
            get { return new MvxCommand(ShowWorkshopExecuted); }
        }

        private void ShowWorkshopExecuted()
        {
            ShowViewModel<RecyclerViewWorkshopViewModel>();

        }


        public IMvxCommand ShowPalestrasCommand
        {
            get { return new MvxCommand(ShowPalestrasExecuted); }
        }

        private void ShowPalestrasExecuted()
        {
            ShowViewModel<ViewPagerPalestrasViewModel>();

        }

        public IMvxCommand ShowComentariosCommand
        {
            get { return new MvxCommand(ShowComentariosExecuted); }
        }

        private void ShowComentariosExecuted()
        {
            ShowViewModel<RecyclerViewComentariosViewModel>();

        }






        #endregion
    }
}
