using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using xsinita.Core.Interfaces;
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.Feedback
{
    public class EnviarComentarioViewModel : BaseViewModel
    {
        public readonly IDialogService _dialogService;
        private readonly IPickImageService _pickImageService;

        public EnviarComentarioViewModel(IDialogService dialogService, IPickImageService pickImageService)
        {
            _dialogService = dialogService;
            _pickImageService = pickImageService;
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

        private bool _clickButton = false;
        public bool ClickButton
        {
            get { return _clickButton; }
            set { SetProperty(ref _clickButton, value); }
        }

        static List<string> _itemSpinner = new List<string>() { "Evento", "Minicurso", "Workshop", "Palestra" };
        public List<string> ItemSpinner
        {
            get { return _itemSpinner; }
            set { SetProperty(ref _itemSpinner, value); }
        }

        public IMvxCommand EviarComentarioCommand
        {
            get { return new MvxCommand(() =>
            {
                if (Nome == string.Empty || Comentario == string.Empty)
                {
                    _dialogService.ShowSnackbar("Adicione um Nome e Comentário.");
                }
                else
                {
                    _dialogService.ShowProgessDialog();
                    ClickButton = true;
                }
                
            });}
        }
    }
}
