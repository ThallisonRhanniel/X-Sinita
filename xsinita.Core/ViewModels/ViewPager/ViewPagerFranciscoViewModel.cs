
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.ViewPager
{
    public class ViewPagerFranciscoViewModel : BaseViewModel
    {
        private string _iconURL = "";
        public string IconURL
        {
            get { return _iconURL; }
            set { SetProperty(ref _iconURL, value); }
        }

        private string _iconDescription = "";
        public string IconDescription
        {
            get { return _iconDescription; }
            set { SetProperty(ref _iconDescription, value); }
        }

        private string _CPDescription = "";
        public string CPDescription
        {
            get { return _CPDescription; }
            set { SetProperty(ref _CPDescription, value); }
        }

        private string _horario = "";
        public string Horario
        {
            get { return _horario; }
            set { SetProperty(ref _horario, value); }
        }

        private string _nome = "";
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }
        public ViewPagerFranciscoViewModel()
        {
            IconURL = "@drawable/icon_palestra_francisco";
            CPDescription = Description.DescriptionFrancisco;
            Horario = "Dia: 28/10 \n" +
                      "Horario: 20:30 as 21:30";
            Nome = "Francisco Fontes";

        }

    }
}
