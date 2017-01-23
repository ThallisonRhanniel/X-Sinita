
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.ViewPager
{
    public class ViewPagerIsidroViewModel : BaseViewModel
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
        public ViewPagerIsidroViewModel()
        {
            IconURL = "@drawable/icon_palestra_isidro";
            CPDescription = Description.DescriptionIsidro;
            Horario = "Dia: 26/10 \n" +
                      "Horario: 19:00 as 21:30";
            Nome = "Francisco Isidro Massetto";

        }

    }
}
