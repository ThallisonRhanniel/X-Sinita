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
                iconUrl = "@drawable/icon_perfil_batman",
                apresentadorProgramacao = "Bruce Wayne ",
                temaProgramacao = "The Dark Knight",
                textoProgramacao = "Batman é um personagem fictício, um super-herói da banda desenhada americana publicada pela DC Comics. Foi criado pelo escritor Bill Finger e pelo artista Bob Kane, e apareceu pela primeira vez na revista Detective Comics #27 (Maio de 1939)."
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_perfil_stormtroopers",
                apresentadorProgramacao = "Stormtroopers",
                temaProgramacao = "Como ser um sniper",
                textoProgramacao = "Stormtroopers, conhecidos por suas complexas, úteis e distinitas armaduras brancas, bem como suas impecáveis armas de paintball com mira 'impecável', os primeiros a serem explodidos e também os primeiros a pedir trégua, já que quase nunca Darth Vader os ajuda"
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_perfil_mario",
                apresentadorProgramacao = "It's me Mario",
                temaProgramacao = "Como é ser irmão do Mario Verde",
                textoProgramacao = "Mario (マリオ, Mario?) é um personagem fictício da franquia e série de jogos eletrônicos Mario da Nintendo, criado pelo desenvolvedor e designer de jogos eletrônicos japonês Shigeru Miyamoto. Servindo como mascote da Nintendo e protagonista homônimo da série, Mario já apareceu em mais de 200 jogos desde sua criação."
            }
        });
        #endregion

        #region Palestras
        public static readonly ObservableCollection<Programacao> Palestras = new MvxObservableCollection<Programacao>(new List<Programacao>()
        {
            new Programacao()
            {
                iconUrl = "@drawable/icon_perfil_batman",
                apresentadorProgramacao = "Bruce Wayne ",
                temaProgramacao = "The Dark Knight",
                textoProgramacao = "Batman é um personagem fictício, um super-herói da banda desenhada americana publicada pela DC Comics. Foi criado pelo escritor Bill Finger e pelo artista Bob Kane, e apareceu pela primeira vez na revista Detective Comics #27 (Maio de 1939)."
            },
            new Programacao()
            {
                iconUrl = "@drawable/icon_perfil_stormtroopers",
                apresentadorProgramacao = "Stormtroopers",
                temaProgramacao = "Como ser um sniper",
                textoProgramacao = "Stormtroopers, conhecidos por suas complexas, úteis e distinitas armaduras brancas, bem como suas impecáveis armas de paintball com mira 'impecável', os primeiros a serem explodidos e também os primeiros a pedir trégua, já que quase nunca Darth Vader os ajuda"
            }
        });


        #endregion

        #region Workshop
        public static readonly ObservableCollection<Programacao> Workshop = new MvxObservableCollection<Programacao>(new List<Programacao>()
        {
            new Programacao()
            {
                iconUrl = "@drawable/icon_perfil_batman",
                apresentadorProgramacao = "Bruce Wayne ",
                temaProgramacao = "The Dark Knight",
                textoProgramacao = "Batman é um personagem fictício, um super-herói da banda desenhada americana publicada pela DC Comics. Foi criado pelo escritor Bill Finger e pelo artista Bob Kane, e apareceu pela primeira vez na revista Detective Comics #27 (Maio de 1939)."
            }
        });
        #endregion

    }
}
