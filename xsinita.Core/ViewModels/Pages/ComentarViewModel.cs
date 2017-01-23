using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.Pages
{
    public class ComentarViewModel : BaseViewModel
    {
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

        public async Task<bool> EnviarComentario()
        {
            try
            {
                var requestUri = new Uri("Your Api");//produção
                dynamic dynamicJson = new ExpandoObject();
                dynamicJson.token = "Your Token";
                dynamicJson.user = "thallison";
                if (Nome == "")
                {
                    Nome = "Anônimo";
                }
                dynamicJson.nome = Nome;
                dynamicJson.assunto = SelectemSpinner;
                dynamicJson.texto = Comentario;

                var json = JsonConvert.SerializeObject(dynamicJson);
                var objClint = new HttpClient();

                StringContent Dados = new StringContent(json, Encoding.UTF8, "application/json");
              
                var response = await objClint.PostAsync(requestUri, Dados); 
                IEnumerable<string> values;
                if (response.Headers.TryGetValues("message_erro", out values))
                {
                    var message = values.First();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public MvxCommand EnviarComentarioCommand
        {
            get { return new MvxCommand(changename); }
        }

        public async void changename()
        {
            //await EnviarComentario();
        }

    }
}
