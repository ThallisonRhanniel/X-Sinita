using System;
using MvvmCross.Binding.Combiners;
using MvvmCross.Core.ViewModels;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Feedback;
using xsinita.Core.ViewModels.Home;
using xsinita.Core.ViewModels.Programacao.ViewPager;

namespace xsinita.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        static readonly Random rnd = new Random();
        static readonly int random = rnd.Next(0, 2);
        private static readonly string[] perfil = { "@drawable/icon_perfil_batman" , "icon_perfil_mario" , "icon_perfil_stormtroopers" };
        private string _iconUrl = perfil[random];
        public string iconUrl
        {
            get { return _iconUrl; }
            set { SetProperty(ref _iconUrl, value); }
        }

        

        private bool _clickButton;
        public bool ClickButton
        {
            get { return _clickButton; }
            set { SetProperty(ref _clickButton, value); }
        }

        public IMvxCommand PickImageCommand
        {
            get { return new MvxCommand(() =>ClickButton = true); }
        }

        public IMvxCommand ShowHomeCommand => new MvxCommand(() => ShowViewModel<HomeViewModel>());
       
        public IMvxCommand ShowEnviarComentarioCommand => new MvxCommand(() => ShowViewModel<EnviarComentarioViewModel>());
        
        public IMvxCommand ShowProgramacaoCommand => new MvxCommand(() => ShowViewModel<ViewPagerViewModel>());
        
        public IMvxCommand ShowMostrarComentariosCommand => new MvxCommand(() => ShowViewModel<MostrarComentariosViewModel>());
               
    }
}
