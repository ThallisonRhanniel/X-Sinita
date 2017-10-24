using System;
using System.IO;
using System.Net.Http;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using xsinita.Core.ViewModels.Base;
using xsinita.Core.ViewModels.Feedback;
using xsinita.Fragments.Base;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Android.Content;
using Android.Preferences;
using MvvmCross.Platform.WeakSubscription;

namespace xsinita.Fragments.Feedback
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("xsinita.fragments.Feedback.EnviarComentarioFragment")]
    public class EnviarComentarioFragment : BaseFragment<EnviarComentarioViewModel>
    {
        private View _view;
        private static int PICK_IMAGE = 1234;
        private IDisposable _itemSelectedToken;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            _view = base.OnCreateView(inflater, container, savedInstanceState);


            _itemSelectedToken = ViewModel.WeakSubscribe(() => ViewModel.ClickButton,
                    (sender, args) =>
                    {
                        if (ViewModel.ClickButton == true)
                        {
                            Task.Factory.StartNew(EnviarDados);
                            ViewModel.ClickButton = false;
                            //ViewModel._dialogService.DismissProgessDialog();
                        }
                    });
            return _view;


        }
        
        private void EnviarDados() 
        {
            try
            {
                string filePath = "";

                ISharedPreferences pref = PreferenceManager.GetDefaultSharedPreferences(Context);
                var imagePerfil = new Java.IO.File(pref.GetString("imagePath", ""));
                if (imagePerfil.Exists())
                filePath = imagePerfil.AbsolutePath;
               
                var url = "https://sinita-api.herokuapp.com/v1/comments"; //http://192.168.0.108:8000/v1/comments/
                HttpClient httpClient = new HttpClient();
                MultipartFormDataContent form = new MultipartFormDataContent();

                FileStream fs = File.OpenRead(filePath);
                var streamContent = new StreamContent(fs);

                var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                var name = new StringContent(ViewModel.Nome);
                var category = new StringContent(ViewModel.SelectemSpinner);
                var comment = new StringContent(ViewModel.Comentario);
                form.Add(name, "name");
                form.Add(category, "category");
                form.Add(comment, "comment");
                form.Add(imageContent, "icon_perfil", Path.GetFileName(filePath));

                var response = httpClient.PostAsync(url, form).Result;
                
                
                ViewModel._dialogService.DismissProgessDialog();
                ViewModel._dialogService.ShowSnackbar("Comentário enviando com Sucesso");
                ViewModel.Comentario = "";
            }
            
            catch (Exception e)
            {
                ViewModel._dialogService.DismissProgessDialog();
                ViewModel._dialogService.ShowSnackbar("Foto do perfil não encontrada ou não há conexão com a Internet");
            }
            
        }

        protected override int FragmentId => Resource.Layout.fragment_comentar;

    }
}