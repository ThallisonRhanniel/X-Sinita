using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.WebBrowser;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.Utilities;

namespace xsinita.Core.ViewModels.Programacao.Pages
{
    public class RecyclerViewPagesViewModel : BaseViewModel
    {
        private readonly IMvxWebBrowserTask _webBrowser;

        public RecyclerViewPagesViewModel(IMvxWebBrowserTask webBrowser)
        {
            _webBrowser = webBrowser;
        }

        private ObservableCollection<Models.Programacao> _itemsProgramacao = new MvxObservableCollection<Models.Programacao>();
        public ObservableCollection<Models.Programacao> ItemsProgramacao
        {
            get { return _itemsProgramacao; }
            set { SetProperty(ref _itemsProgramacao, value); }
        }

        public IMvxCommand ApresentadorSiteClickCommand
        {
            get
            {
                return new MvxCommand<Models.Programacao>(item =>
                {
                    if (item.apresentadorSite != null)
                        _webBrowser.ShowWebPage(item.apresentadorSite);
                });
            }
        }


        private bool _isRefreshing;
        public virtual bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public ICommand ReloadCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    IsRefreshing = true;
                    IsRefreshing = false;
                });
            }
        }

        public void Init(string index)
        {
            switch (index)
            {
                case "Minicursos":
                    ItemsProgramacao = ListProgramacao.Minicursos;
                    break;
                case "Palestras":
                    ItemsProgramacao = ListProgramacao.Palestras;
                    break;
                case "Workshop":
                    ItemsProgramacao = ListProgramacao.Workshop;
                    break;
            }
        }
    }
}
