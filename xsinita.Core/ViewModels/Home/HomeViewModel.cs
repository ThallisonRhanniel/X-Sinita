using System.Net.Http;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.WebBrowser;
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.Home
{
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
            get { return new MvxCommand(() => _webBrowser.ShowWebPage("https://www.instagram.com/sinitaftc")); }
        }
        public ICommand ShowLinkedinThallisonCommand
        {
            get { return new MvxCommand(() => _webBrowser.ShowWebPage("https://www.linkedin.com/in/thallisonrhanniel")); }
        }
        public ICommand ShowLinkedinDiorgelesCommand
        {
            get { return new MvxCommand(() => _webBrowser.ShowWebPage("https://br.linkedin.com/in/diorgeles-dias-9b63a5a9")); }
        }
    }
}
