using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.Utilities;

namespace xsinita.Core.ViewModels.Programacao.Pages
{
    public class RecyclerViewPagesViewModel : BaseViewModel
    {
        private ObservableCollection<Models.Programacao> _itemsProgramacao = new MvxObservableCollection<Models.Programacao>();
        public ObservableCollection<Models.Programacao> ItemsProgramacao
        {
            get { return _itemsProgramacao; }
            set { SetProperty(ref _itemsProgramacao, value); }
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
