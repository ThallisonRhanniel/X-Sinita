using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Models;

namespace xsinita.Core.ViewModels.AndroidSpecific
{
    public class RecyclerViewWorkshopViewModel : BaseViewModel
    {
        private ListItem _selectedItem;
        
        public RecyclerViewWorkshopViewModel()
        {
            Items = new ObservableCollection<ListItem> {
                new ListItem
                {
                    title = "Clebson Costa",
                    descrição = "Uso seguro da internet",
                    data = "Dia 24/10 as 19:00",
                    iconUrl = "@drawable/icon_workshop_clebson"

                },
                new ListItem
                {
                    title = "Robert Lima",
                    descrição = "Impressão 3D",
                    data = "Dia 24/10 as 19:00",
                    iconUrl = "@drawable/icon_workshop_robert"
                },
                new ListItem
                {
                    title = "Pedro Borges",
                    descrição = "Patente de Software",
                    data = "Dia 25/10 as 19:00",
                    iconUrl = "@drawable/icon_workshop_pedro"
                },
                new ListItem
                {
                    title = "Sebrae",
                    descrição = "Desafio Universitário Sebrae",
                    data = "Dia 24/10 as 18:00",
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

        private bool _isRefreshing;

        public virtual bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); } //_isRefreshing = value; RaisePropertyChanged(() => IsRefreshing);

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

       

    }
}
