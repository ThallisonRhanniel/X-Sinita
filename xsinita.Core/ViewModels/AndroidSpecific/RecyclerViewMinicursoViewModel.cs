using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Models;

namespace xsinita.Core.ViewModels.AndroidSpecific
{
    public class RecyclerViewMinicursoViewModel : BaseViewModel
    {
        private ListItem _selectedItem;

        
        public RecyclerViewMinicursoViewModel()
        {
            Items = new ObservableCollection<ListItem> {
                new ListItem
                {
                    title = "Diorgeles Dias Lima",
                    descrição = "Python/Django",
                    data = "Dia: 24/10 e 25/10 as 19:00",
                    iconUrl = "@drawable/icon_minicurso_diorgeles"

                },
                new ListItem
                {
                    title = "Danilo Sousa",
                    descrição = "Marketing em Mídias Sociais",
                    data = "Dia: 24/10 e 25/10 as 19:00",
                    iconUrl = "@drawable/icon_minicurso_danilo"
                },
                new ListItem
                {
                    title = "Celso Netto",
                    descrição = "C#",
                    data = "Dia: 24/10 e 25/10 as 19:00",
                    iconUrl = "@drawable/icon_minicurso_celso"
                },
                new ListItem
                {
                    title = "Carolina Vieira",
                    descrição = "Criptografia de base de dados no SQL Server",
                    data = "Dia: 24/10 as 19:00",
                    iconUrl = "@drawable/icon_minicurso_carolina"

                },
                new ListItem
                {
                    title = "Waldeir Oliveira",
                    descrição = "Fibra óptica",
                    data = "Dia: 25/10 as 19:00",
                    iconUrl = "@drawable/icon_minicurso_walder"
                },
                 new ListItem
                {
                    title = "Sebrae",
                    descrição = "Oficina Plano de Negócio",
                    data = "Dia: 25/10 as 19:00",
                    iconUrl = "@drawable/icon_minicursoeworkshop_sebrae"
                },

            };
        }

        private ObservableCollection<ListItem> _items;

        public ObservableCollection<ListItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); } //_items = value;//RaisePropertyChanged(() => Items);
        }

        public ListItem SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); } //_selectedItem = value; RaisePropertyChanged(() => SelectedItem);

        }

        public virtual ICommand ItemSelected
        {
            get
            {
                return new MvxCommand<ListItem>(item => {
                    SelectedItem = item;
                });
            }
        }

        private bool _isRefreshing = false;

        public virtual bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); } //_isRefreshing = value; RaisePropertyChanged(() => IsRefreshing);

        }

        public ICommand ReloadCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    IsRefreshing = true;

                    //await ReloadData();

                    IsRefreshing = false;
                });
            }
        }

        public virtual async Task ReloadData()
        {
            // By default return a completed Task
            //await Task.Delay(5000);

            //var rand = new Random();
            //Func<char> randChar = () => (char)rand.Next(65, 90);
            //Func<int, string> randStr = null;
            //randStr = x => (x > 0) ? randStr(--x) + randChar() : "";

            //var newItemCount = rand.Next(3);

            //for (var i = 0; i < newItemCount; i++)
            //    Items.Add(new ListItem { Title = "title " + randStr(4) });
        }

    }
}
