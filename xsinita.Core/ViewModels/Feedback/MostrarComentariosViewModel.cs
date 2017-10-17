using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using xsinita.Core.Models;
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.Feedback
{
    public class MostrarComentariosViewModel : BaseViewModel
    {
        private ObservableCollection<Cometarios> _itemsComentario = new MvxObservableCollection<Cometarios>();
        public ObservableCollection<Cometarios> ItemsComentarios
        {
            get { return _itemsComentario; }
            set { SetProperty(ref _itemsComentario, value); }
        }

        public virtual async Task GetApiComentariosAsync()
        {
            try
            {
                var geturi = new Uri("http://www.mocky.io/v2/59c1c8451300001b08d29e7c"); // Api provisória
                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "Your Token");
                var downloadTask = await httpClient.GetAsync(geturi);
                var responseGet = await downloadTask.Content.ReadAsStringAsync();
                var listIncritos = JsonConvert.DeserializeObject<ListComentario>(responseGet);
                //dynamic listIncritos = JsonConvert.DeserializeObject<List<dynamic>>(responseGet);
                ItemsComentarios.Clear();

                foreach (var inscritos in listIncritos.ListCometario)
                {
                    ItemsComentarios.Add(new Cometarios()
                    {
                        iconUrl = inscritos.iconUrl,
                        apresentadorProgramacao = inscritos.apresentadorProgramacao,
                        temaProgramacao = inscritos.temaProgramacao,
                        textoProgramacao = inscritos.textoProgramacao
                    });
                }
                IsRefreshing = false;
            }
            catch (Exception)
            {
                //TODO: Adicionar mensagem em caso de falha.
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
                    IsRefreshing = true;
                    await GetApiComentariosAsync();
                    IsRefreshing = false;
                });
            }
        }
    }
}
