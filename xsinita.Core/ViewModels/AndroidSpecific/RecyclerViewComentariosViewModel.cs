using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Models;

namespace xsinita.Core.ViewModels.AndroidSpecific
{
    public class RecyclerViewComentariosViewModel : BaseViewModel
    {
        private ListOpinao _selectedItem;

        private string _opinioes = "";

        public string Opinioes
        {
            get { return _opinioes; }
            set { SetProperty(ref _opinioes, value); }
        }

        public RecyclerViewComentariosViewModel()
        {
            Items = new ObservableCollection<ListOpinao>();
            IsRefreshing = true;
            GET();
        }

        public virtual async Task GET()
        {
            try
            {
                var geturi = new Uri("Your API");
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "Your Token");
                var downloadTask = await httpClient.GetAsync(geturi);
                var responseGet = await downloadTask.Content.ReadAsStringAsync();
                var listIncritos = JsonConvert.DeserializeObject<List<ListOpinao>>(responseGet);
                Items.Clear();
                foreach (var inscritos in listIncritos)
                {
                    int assunto = Convert.ToInt32(inscritos.assunto);
                    string assuntoNew = "";
                    switch (assunto)
                    {
                        case 1:
                            assuntoNew = "Evento";
                            break;
                        case 2:
                            assuntoNew = "Minicurso";
                            break;
                        case 3:
                            assuntoNew = "Workshop";
                            break;
                        case 4:
                            assuntoNew = "Palestra";
                            break;
                    }
                    Items.Add(new ListOpinao
                    {
                        nome = inscritos.nome,
                        assunto = assuntoNew,
                        texto = inscritos.texto,
                        dtHora = inscritos.dtHora
                    });
                    IsRefreshing = false;
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private ObservableCollection<ListOpinao> _items;

        public ObservableCollection<ListOpinao> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); } 
        }

        public ListOpinao SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); } 

        }

        public virtual ICommand ItemSelected
        {
            get
            {
                return new MvxCommand<ListOpinao>(item => {
                    SelectedItem = item;
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
                return new MvxCommand(async () =>
                {
                    IsRefreshing = true; //Isso é para icone de "atualização" ao deslizar a tela desapareça rapidamente
                    await GET();
                    IsRefreshing = false;
                });
            }
        }
        

    }
}
