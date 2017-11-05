using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using xsinita.Core.Interfaces;
using xsinita.Core.Models;
using xsinita.Core.ViewModels.Base;
using System.Net.Http.Headers;

namespace xsinita.Core.ViewModels.Feedback
{
    public class MostrarComentariosViewModel : BaseViewModel
    {
        private readonly IDialogService _iDialogService;
        

        public MostrarComentariosViewModel(IDialogService iDialogService)
        {
            _iDialogService = iDialogService;
        }

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
                var geturi = new Uri("http://192.168.0.108:8000/v1/comments/"); // https://sinita-api.herokuapp.com/v1/comments
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "2c67cd4daedbf1b5a5ff40fe07f669c142f41ecc");
                var downloadTask = await httpClient.GetAsync(geturi);
                var responseGet = await downloadTask.Content.ReadAsStringAsync();
                var listComentario = JsonConvert.DeserializeObject<List<Cometarios>>(responseGet);
                ItemsComentarios.Clear();
                foreach (var comentario in listComentario)
                {
                    ItemsComentarios.Add(new Cometarios()
                    {
                        name = comentario.name,
                        icon_perfil = comentario.icon_perfil,
                        category = comentario.category,
                        comment = comentario.comment,
                        created = comentario.created
                    });
                }
                IsRefreshing = false;
            }
            catch (Exception message)
            {
                var oi = message;
                _iDialogService.ShowSnackbarCoordinatorLayout(
                    "Incapaz de carregar o comentários, verifique sua conexão com a internet.");
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
