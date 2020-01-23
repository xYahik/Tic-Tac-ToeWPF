using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_ToeLIB
{


    public class TicTacToe
    {
        public enum Znaki
        {
            PustaKomórka,
            Znak_O,
            Znak_X
        }
        /// <summary>
        /// Przechowuje wszystkie komórki
        /// </summary>
        public Znaki[] znaki;
        /// <summary>
        /// Przechowuje wartość boolean dla wyznaczenia który gracz zaczyna
        /// </summary>
        public bool Czy_Ruch_Gracza_Pierwszego;
        /// <summary>
        /// Przechowuje wartość boolean dla wyznaczenia czy gra została zakończona
        /// </summary>
        public bool Czy_Gra_Zakończona;
        /// <summary>
        /// Przechowuje liczbę zwycięstw danego gracza
        /// </summary>
        public float wygranychX, wygranychO = 0;
        /// <summary>
        /// Przechowuje wartość boolean czy drugim przeciwnikiem jest komputer
        /// </summary>
        public bool _computerPlaying = false;
        /// <summary>
        /// Przechowuje Nazwe drugiego gracza. Po przełączeniu na PC zmienia wartość na "PC" i na odwrót.
        /// </summary>
        public string Gracz2Nazwa = "Gracz";

        
        

    }
}
