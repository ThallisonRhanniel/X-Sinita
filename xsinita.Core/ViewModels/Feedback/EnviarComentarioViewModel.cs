using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using xsinita.Core.Interfaces;
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.Feedback
{
    public class EnviarComentarioViewModel : BaseViewModel
    {
        private IDialogService _dialogService;

        public EnviarComentarioViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        private string _nome = "";
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }

        private string _comentario = "";
        public string Comentario
        {
            get { return _comentario; }
            set { SetProperty(ref _comentario, value); }
        }

        private string _selecItemSpinner = "";
        public string SelectemSpinner
        {
            get { return _selecItemSpinner; }
            set { SetProperty(ref _selecItemSpinner, value); }
        }

        static List<string> _itemSpinner = new List<string>() { "Evento", "Minicurso", "Workshop", "Palestra" };
        public List<string> ItemSpinner
        {
            get { return _itemSpinner; }
            set { SetProperty(ref _itemSpinner, value); }
        }

        public IMvxAsyncCommand EviarComentarioCommand
        {
            get { return new MvxAsyncCommand(async () => await EnviarComentario()); }
        }



        private async Task<bool> EnviarComentario()
        {
            try
            {
                _dialogService.ShowProgessDialog();
                var requestUri = new Uri("Your Api");
                dynamic dynamicJson = new ExpandoObject();
                dynamicJson.token = "Your Token";
                dynamicJson.user = "thallison";
                if (Nome == string.Empty)
                    Nome = "Anônimo";
                
                dynamicJson.nome = Nome;
                dynamicJson.assunto = SelectemSpinner;
                dynamicJson.texto = Comentario;

                var json = JsonConvert.SerializeObject(dynamicJson);
                var objClint = new HttpClient();

                StringContent dados = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await objClint.PostAsync(requestUri, dados);
                IEnumerable<string> values;
                if (response.Headers.TryGetValues("message_erro", out values))
                {
                    var message = values.First();
                    _dialogService.ShowSnackbar("Erro, verifique a conexção com a internet");
                    _dialogService.DismissProgessDialog();
                    return false;
                }
                else
                {
                    _dialogService.ShowSnackbar("Comentário enviado com sucesso");
                    _dialogService.DismissProgessDialog();
                    return true;
                }
            }
            catch (Exception)
            {
                _dialogService.ShowSnackbar("Erro, verifique a conexção com a internet");
                _dialogService.DismissProgessDialog();
                return false;
            }

        }
    }
}
