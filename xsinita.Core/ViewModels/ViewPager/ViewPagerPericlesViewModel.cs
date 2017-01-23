
using xsinita.Core.ViewModels.Base;

namespace xsinita.Core.ViewModels.ViewPager
{
    public class ViewPagerPericlesViewModel : BaseViewModel
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
        public ViewPagerPericlesViewModel()
        {
            IconURL = "@drawable/icon_palestra_pericles";
            CPDescription = Description.DescriptionPericles;
            Horario = "Dia: 27/10 \n" +
                      "Horario: 19:00 as 20:20";
            Nome = "Péricles Nogueira Magalhães Junior";

        }

    }
}
