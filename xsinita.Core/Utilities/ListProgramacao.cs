using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using xsinita.Core.Models;

namespace xsinita.Core.Utilities
{
    public static class ListProgramacao
    {
        #region Minicursos
        public static readonly ObservableCollection<Programacao> Minicursos = new MvxObservableCollection<Programacao>(new List<Programacao>()
        {
            new Programacao()
            {
                iconUrl = "@drawable/icon_minicurso_diorgeles",
                apresentadorProgramacao = "Diorgeles Dias Lima",
                temaProgramacao = "Desenvolvimento Web com Python Django + Git +Heroku",
                textoProgramacao = "Local: FTC - SALA 306 \r\nDia: 09/11 e 10/11 \r\nHorário: 19:00 às 21:45",
                apresentadorSite = "https://www.linkedin.com/in/diorgelesdias/"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_minicurso_gustavo",
                apresentadorProgramacao = "Luiz Gustavo S. Mafra",
                temaProgramacao = "Introdução ao PHP com Yii Framework",
                textoProgramacao = "Local: FTC - SALA 311 \r\nDia: 09/11 e 10/11 \r\nHorário: 19:00 às 21:45",
                apresentadorSite = "https://www.linkedin.com/in/lgmafra/"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_minicurso_rogerio",
                apresentadorProgramacao = "Rogério Martins Góis",
                temaProgramacao = "Redes ópticas na tecnologia FTTx e suas aplicações",
                textoProgramacao = "Local: AFI - SALA 103 \r\nDia: 09/11 \r\nHorário: 19:00 às 21:45"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_minicurso_artur",
                apresentadorProgramacao = "Artur Olsen Silva Côrtes",
                temaProgramacao = "Pentest com Kali Linux",
                textoProgramacao = "Local: FTC - SALA 309 \r\nDia: 10/11 \r\nHorário: 19:00 às 21:45",
                apresentadorSite = "https://www.facebook.com/artur.olsensilvacortes?ref=br_rs"
            }
        });
        #endregion

        #region Palestras
        public static readonly ObservableCollection<Programacao> Palestras = new MvxObservableCollection<Programacao>(new List<Programacao>()
        {
            new Programacao()
            {
                iconUrl = "@drawable/icon_palestra_alvaro",
                apresentadorProgramacao = "Dr. Álvaro Vinícius de Souza Coelho",
                temaProgramacao = "Possibilidades profissionais na área da computação",
                textoProgramacao = "Local: AUDITÓRIO – FTC \r\nDia: 06/11  \r\nHorário: 20:30 às 21:45",
                apresentadorSite = "http://buscatextual.cnpq.br/buscatextual/visualizacv.do?metodo=apresentar&id=K4751050T5"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_palestra_leizer",
                apresentadorProgramacao = "Dr. Leizer Schnitman",
                temaProgramacao = "Inteligência Artificial",
                textoProgramacao = "Local: AUDITÓRIO – FTC \r\nDia: 07/11  \r\nHorário: 19:00 às 20:30",
                apresentadorSite = "http://lattes.cnpq.br/0473342349140026"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_palestra_achilles",
                apresentadorProgramacao = "Achilles Fróes",
                temaProgramacao = "Windows IoT Edition",
                textoProgramacao = "Local: AUDITÓRIO – FTC \r\nDia: 07/11  \r\nHorário: 20:30 às 21:45",
                apresentadorSite = "https://www.linkedin.com/in/achillesfroes/"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_palestra_maciel",
                apresentadorProgramacao = "Maciel Barreto",
                temaProgramacao = "O mundo do Casemod (computadores turbinados)",
                textoProgramacao = "Local: AUDITÓRIO – FTC \r\nDia: 08/11  \r\nHorário: 19:00 às 20:30",
                apresentadorSite = "https://www.linkedin.com/in/maciel-barreto-ab78447a/"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_palestra_helder",
                apresentadorProgramacao = "Helder Moraes de Almeida",
                temaProgramacao = "Os Desafios da Gestão de TI",
                textoProgramacao = "Local: AUDITÓRIO – FTC \r\nDia: 08/11  \r\nHorário: 20:30 às 21:45",
                apresentadorSite = "https://www.facebook.com/heldermoraesde.almeida?ref=br_rs"
            }
        });


        #endregion

        #region Workshop
        public static readonly ObservableCollection<Programacao> Workshop = new MvxObservableCollection<Programacao>(new List<Programacao>()
        {
            new Programacao()
            {
                iconUrl = "@drawable/icon_perfil_aline",
                apresentadorProgramacao = "Alline Cardoso e Gleidson Ferreira",
                temaProgramacao = "Oratória",
                textoProgramacao = "Local: AFI - SALA 209 \r\nDia: 09/11 \r\nHorário: 19:00 às 21:45"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_perfil_manuela",
                apresentadorProgramacao = "Manuela Berbert",
                temaProgramacao = "Empreendedorismo digital",
                textoProgramacao = "Local: FTC - SALA 207 \r\nDia: 09/11 e 10/11 \r\nHorário: 19:00 às 21:45",
                apresentadorSite = "https://www.linkedin.com/in/manuela-berbert-49467076/"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_perfil_evila",
                apresentadorProgramacao = "Evila Quirino",
                temaProgramacao = "Segurança em Dispositivos Móveis",
                textoProgramacao = "Local: TABLADO \r\nDia: 09/11 \r\nHorário: 19:00 às 21:45",
                apresentadorSite = "https://www.facebook.com/evila.quirino?ref=br_rs"
            }
        });
        #endregion

    }
}
