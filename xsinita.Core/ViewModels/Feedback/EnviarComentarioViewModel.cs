using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using xsinita.Core.Interfaces;
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.Feedback
{
    public class EnviarComentarioViewModel : BaseViewModel
    {
        private readonly IDialogService _iDialogService;
        private readonly IPostService _iPostService;

        public EnviarComentarioViewModel(IDialogService iDialogService, IPostService iPostService)
        {
            _iDialogService = iDialogService;
            _iPostService = iPostService;
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
        public string SelecItemSpinner
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

        public IMvxCommand EviarComentarioCommand
        {
            get { return new MvxCommand(async () =>
            {
                if (Nome == string.Empty || Comentario == string.Empty)
                {
                    _iDialogService.ShowSnackbar("Adicione um Nome e Comentário.");
                }
                else
                {
                    _iDialogService.ShowProgessDialog();
                    var mensagem = await _iPostService.EnviarDadosAsync(Nome, SelecItemSpinner, Comentario);
                    _iDialogService.DismissProgessDialog();
                    _iDialogService.ShowSnackbar(mensagem);
                }
            });}
        }
    }
}
