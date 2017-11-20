using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.WebBrowser;
using xsinita.Core.Models;
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.Home
{
    [Preserve(AllMembers = true)]
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMvxWebBrowserTask _webBrowser;

        public HomeViewModel(IMvxWebBrowserTask webBrowser)
        {
            _webBrowser = webBrowser;
        }

        public ICommand ShowFacebookCommand
        {
            get { return new MvxCommand(() => _webBrowser.ShowWebPage("https://www.facebook.com/sinitaftc/")); }
        }

        public ICommand ShowInstagramCommand
        {
            get { return new MvxCommand(() => _webBrowser.ShowWebPage("https://www.instagram.com/p/BaLL-oTDK84/?taken-by=sinitaftc")); } 
        }

        public ICommand ShowLinkedinThallisonCommand
        {
            get { return new MvxCommand(() => _webBrowser.ShowWebPage("https://www.linkedin.com/in/thallisonrhanniel")); }
        }

        public ICommand ShowSiteCommand
        {
            get { return new MvxCommand(() => _webBrowser.ShowWebPage("http://www.sinitaftc.com.br/")); }
        }
    }
}
