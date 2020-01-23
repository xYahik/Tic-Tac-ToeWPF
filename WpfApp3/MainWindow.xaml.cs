using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tic_Tac_ToeLIB;
namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /*/// <summary>
        /// Przechowuje wszystkie komórki
        /// </summary>
        private Znaki[] znaki;
        /// <summary>
        /// Przechowuje wartość boolean dla wyznaczenia który gracz zaczyna
        /// </summary>
        private bool Czy_Ruch_Gracza_Pierwszego;
        /// <summary>
        /// Przechowuje wartość boolean dla wyznaczenia czy gra została zakończona
        /// </summary>
        private bool Czy_Gra_Zakończona;
        /// <summary>
        /// Przechowuje liczbę zwycięstw danego gracza
        /// </summary>
        private float wygranychX, wygranychO = 0;
        /// <summary>
        /// Przechowuje wartość boolean czy drugim przeciwnikiem jest komputer
        /// </summary>
        private bool _computerPlaying = false;
        /// <summary>
        /// Przechowuje Nazwe drugiego gracza. Po przełączeniu na PC zmienia wartość na "PC" i na odwrót.
        /// </summary>
        string Gracz2Nazwa = "Gracz";
        /// <summary>
        /// Po wczytaniu okna rozpoczyna rozgrywkę
        /// </summary>*/
        TicTacToe game = new TicTacToe();
        public MainWindow()
        {
            InitializeComponent();
            ZaczynamyRozgrywke();
        }
        /// <summary>
        /// Inicjalizuje stan początkowy gry
        /// </summary>
        private void ZaczynamyRozgrywke()
        {
            game.znaki = new TicTacToe.Znaki[16];
            for (var i = 0; i < game.znaki.Length; i++)
                game.znaki[i] = TicTacToe.Znaki.PustaKomórka;
            ButtonRewanz.IsEnabled = false;
            game.Czy_Ruch_Gracza_Pierwszego = true;
            foreach (Button button in FindVisualChildren<Button>(Conteiner))
            {
               
                if (button.Name != "ButtonReset" && button.Name != "ButtonRewanz" && button.Name != "ButtonPC")
                {
                    button.Content = " ";
                    button.Background = Brushes.DarkGray;
                    button.Foreground = Brushes.Black;
                    button.Opacity = 1;
                }
            }

            game.Czy_Gra_Zakończona = false;
        }
        /// <summary>
        /// Ustalenie ruchów graczy oraz ich znaków
        /// </summary>
        /// <remarks>
        /// Jeżeli jest ruch gracz pierwszego to umożliwia mu postawienie tylko znaku O,
        /// następnie ruch ma gracz z X.Za każdym ruchem zmieniana jest wartość parametru Czy_Ruch_Gracza_Pierwszego 
        /// aż do momentu wygrania parti przez jednego z graczy lub następstwa remisu
        /// </remarks>
        /// <param name="sender">Przycisk który został kliknięty</param>
        /// <param name="e">Wydarzenia kliknięcia</param>
        private void Button_Cl(object sender, RoutedEventArgs e)
        {
            
            if (game.Czy_Gra_Zakończona)
            {
                UpdateWynik();
                return;
            }

            var kratka = (Button)sender;
            var column = Grid.GetColumn(kratka);
            var row = Grid.GetRow(kratka);

            var index = column + (row * 4);
            if(game.znaki[index] != TicTacToe.Znaki.PustaKomórka)
            {
                return;
            }
            if (game.Czy_Ruch_Gracza_Pierwszego)
            {
                game.znaki[index] = TicTacToe.Znaki.Znak_O;

            }
            else
            {
                game.znaki[index] = TicTacToe.Znaki.Znak_X;
            }
            if (game.Czy_Ruch_Gracza_Pierwszego)
            {
                kratka.Content = "O";
                kratka.Foreground = Brushes.Red;
            }
            else
            {
                kratka.Content = "X";
                kratka.Foreground = Brushes.Blue;
            }
            if (game.Czy_Ruch_Gracza_Pierwszego)
            {
                game.Czy_Ruch_Gracza_Pierwszego = false;
                if (game._computerPlaying)
                {
                    Wygrana();
                    List<Button> buttons = new List<Button>();
                    foreach (Button button in FindVisualChildren<Button>(Conteiner))
                    {

                        if (button.Name != "ButtonReset" && button.Name != "ButtonRewanz" && button.Name != "ButtonPC")
                        {
                            if (button.Foreground == Brushes.Black)
                            {
                                buttons.Add(button);
                            }
                        }
                    }
                    var random = new Random();
                    int indexx = random.Next(0, buttons.Count);
                    
                    Button_Cl(buttons[indexx], new RoutedEventArgs());

                }
            }
            else
            {
                game.Czy_Ruch_Gracza_Pierwszego = true;
            }

            Wygrana();

        }
        /// <summary>
        /// Ustalenie logiki gry
        /// </summary>
        private void Wygrana()
        {

            #region wPoziomie
            
            if ((game.znaki[0] & game.znaki[1] & game.znaki[2] & game.znaki[3]) == game.znaki[0] && game.znaki[0] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA1.Background = ButtonA2.Background = ButtonA3.Background = ButtonA4.Background = Brushes.Green;
            }
            if ((game.znaki[4] & game.znaki[5] & game.znaki[6] & game.znaki[7]) == game.znaki[4] && game.znaki[4] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonB1.Background = ButtonB2.Background = ButtonB3.Background = ButtonB4.Background = Brushes.Green;
            }
            if ((game.znaki[8] & game.znaki[9] & game.znaki[10] & game.znaki[11]) == game.znaki[8] && game.znaki[8] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonC1.Background = ButtonC2.Background = ButtonC3.Background = ButtonC4.Background = Brushes.Green;
            }
            if ((game.znaki[12] & game.znaki[13] & game.znaki[14] & game.znaki[15]) == game.znaki[12]&& game.znaki[12] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonD1.Background = ButtonD2.Background = ButtonD3.Background = ButtonD4.Background = Brushes.Green;
            }
            #endregion
            #region wPionie
            if ((game.znaki[0] & game.znaki[4] & game.znaki[8] & game.znaki[12]) == game.znaki[0]&& game.znaki[0] != TicTacToe.Znaki.PustaKomórka )
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA1.Background = ButtonB1.Background = ButtonC1.Background = ButtonD1.Background = Brushes.Green;
            }
            if ((game.znaki[1] & game.znaki[5] & game.znaki[9] & game.znaki[13]) == game.znaki[1]&& game.znaki[1] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA2.Background = ButtonB2.Background = ButtonC2.Background = ButtonD2.Background = Brushes.Green;
            }        
            if ((game.znaki[2] & game.znaki[6] & game.znaki[10] & game.znaki[14]) == game.znaki[2] && game.znaki[2] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA3.Background = ButtonB3.Background = ButtonC3.Background = ButtonD3.Background = Brushes.Green;
            }
            if ((game.znaki[3] & game.znaki[7] & game.znaki[11] & game.znaki[15]) == game.znaki[3]&& game.znaki[3] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA4.Background = ButtonB4.Background = ButtonC4.Background = ButtonD4.Background = Brushes.Green;
            }

            #endregion
            #region skosy
            if ((game.znaki[0] & game.znaki[5] & game.znaki[10] & game.znaki[15]) == game.znaki[0] && game.znaki[0] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA1.Background = ButtonB2.Background = ButtonC3.Background = ButtonD4.Background = Brushes.Green;
            }
            if ((game.znaki[3] & game.znaki[6] & game.znaki[9] & game.znaki[12]) == game.znaki[3] && game.znaki[3] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA4.Background = ButtonB3.Background = ButtonC2.Background = ButtonD1.Background = Brushes.Green;
            }
            #endregion
            #region kwadraty
            if ((game.znaki[0] & game.znaki[1] & game.znaki[4] & game.znaki[5]) == game.znaki[0] && game.znaki[0] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA1.Background = ButtonA2.Background = ButtonB1.Background = ButtonB2.Background = Brushes.Green;
            }
            if ((game.znaki[1] & game.znaki[2] & game.znaki[5] & game.znaki[6]) == game.znaki[1] && game.znaki[1] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA2.Background = ButtonA3.Background = ButtonB2.Background = ButtonB3.Background = Brushes.Green;
            }
            if ((game.znaki[2] & game.znaki[3] & game.znaki[6] & game.znaki[7]) == game.znaki[2] && game.znaki[2] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonA3.Background = ButtonA4.Background = ButtonB3.Background = ButtonB4.Background = Brushes.Green;
            }
            if ((game.znaki[4] & game.znaki[5] & game.znaki[8] & game.znaki[9]) == game.znaki[4] && game.znaki[4] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonB1.Background = ButtonB2.Background = ButtonC1.Background = ButtonC2.Background = Brushes.Green;
            }
            if ((game.znaki[5] & game.znaki[6] & game.znaki[9] & game.znaki[10]) == game.znaki[5] && game.znaki[5] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonB2.Background = ButtonB3.Background = ButtonC2.Background = ButtonC3.Background = Brushes.Green;
            }
            if ((game.znaki[6] & game.znaki[7] & game.znaki[10] & game.znaki[11]) == game.znaki[6] && game.znaki[6] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonB3.Background = ButtonB4.Background = ButtonC3.Background = ButtonC4.Background = Brushes.Green;
            }
            if ((game.znaki[8] & game.znaki[9] & game.znaki[12] & game.znaki[13]) == game.znaki[8] && game.znaki[8] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonC1.Background = ButtonC2.Background = ButtonD1.Background = ButtonD2.Background = Brushes.Green;
            }
            if ((game.znaki[9] & game.znaki[10] & game.znaki[13] & game.znaki[14]) == game.znaki[9] && game.znaki[9] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonC2.Background = ButtonC3.Background = ButtonD2.Background = ButtonD3.Background = Brushes.Green;
            }
            if ((game.znaki[10] & game.znaki[11] & game.znaki[14] & game.znaki[15]) == game.znaki[10] && game.znaki[10] != TicTacToe.Znaki.PustaKomórka)
            {
                game.Czy_Gra_Zakończona = true;
                ButtonC3.Background = ButtonC4.Background = ButtonD3.Background = ButtonD4.Background = Brushes.Green;
            }
            #endregion

            bool _continue = true;
            foreach (Button button in FindVisualChildren<Button>(Conteiner))
            {

                if (!(button.Name == "ButtonReset" || button.Name == "ButtonRewanz" || button.Name == "ButtonPC") && game.Czy_Gra_Zakończona)
                {
                    if (button.Background == Brushes.Green && _continue)
                    {
                        if (button.Content.ToString() == "X")
                        {
                            if(game._computerPlaying)
                                game.wygranychX += 0.5f;
                            else
                                game.wygranychX += 1;
                        }
                        else if (button.Content.ToString() == "O")
                        {
                            if (game._computerPlaying)
                                game.wygranychO += 0.5f;
                            else
                                game.wygranychO += 1;
                        }
                        _continue = false;
                    }
                        
                }
            }

            UpdateWynik();
            if (game.Czy_Gra_Zakończona)
            {
                ButtonRewanz.IsEnabled = true;
                foreach (Button button in FindVisualChildren<Button>(Conteiner))
                {

                    if (!(button.Name == "ButtonReset" || button.Name == "ButtonRewanz" || button.Name == "ButtonPC"))
                    {

                        button.Opacity = 0.4;
                    }
                }
            }
            if (!game.znaki.Any(x => x == TicTacToe.Znaki.PustaKomórka)&& game.Czy_Gra_Zakończona ==false)
            {
                game.Czy_Gra_Zakończona = true;
                foreach (Button button in FindVisualChildren<Button>(Conteiner))
                {

                    if (!(button.Name == "ButtonReset" || button.Name == "ButtonRewanz" || button.Name == "ButtonPC") && game.Czy_Gra_Zakończona)
                    {

                        button.Opacity = 0.4;
                        button.Background = Brushes.Purple;
                    }
                }
                ButtonRewanz.IsEnabled = true;
            }
        }
        /// <summary>
        /// Rozpoczyna rozgrykę od nowa
        /// </summary>
        /// <param name="sender">Przycisk który został kliknięty</param>
        /// <param name="e">Wydarzenia kliknięcia</param>
        private void ButtonRewanz_Click(object sender, RoutedEventArgs e)
        {
            
            ZaczynamyRozgrywke();
        }
        /// <summary>
        /// Wlącza/Wyłącza grę przeciwko PC
        /// </summary>
        /// <param name="sender">Przycisk który został kliknięty</param>
        /// <param name="e">Wydarzenia kliknięcia</param>
        private void ButtonPC_Click(object sender, RoutedEventArgs e)
        {
            ZaczynamyRozgrywke();
            var przycisk = (Button)sender;
            if (!game._computerPlaying)
            {
                game.wygranychO = 0;
                game.wygranychX = 0;
                game._computerPlaying = true;
                przycisk.Foreground = Brushes.Green;
                game.Gracz2Nazwa = "PC";
                UpdateWynik();
            }
            else
            {
                game.wygranychO = 0;
                game.wygranychX = 0;
                game._computerPlaying = false;
                przycisk.Foreground = Brushes.Black;
                game.Gracz2Nazwa = "Gracz";
                UpdateWynik();
            }

        }
        /// <summary>
        /// Resetuje punkty zawodników
        /// </summary>
        /// <param name="sender">Przycisk który został kliknięty</param>
        /// <param name="e">Wydarzenia kliknięcia</param>
        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            game.wygranychO = 0;
            game.wygranychX = 0;
            UpdateWynik();
        }
        /// <summary>
        /// Aktualizuje tabele wyników obu graczy.
        /// </summary>
        private void UpdateWynik()
        {
            
            WynikGracz1.Content = String.Format("Gracz1: {0}", game.wygranychO);
            WynikGracz2.Content = String.Format("{0}: {1}", game.Gracz2Nazwa, game.wygranychX);
        }
        /// <summary>
        /// Funkcja przeszukuje drzewo w celu znalezienia wszystkich object'ów T, znajdujących się w podanym object'cie rodzicu.
        /// </summary>
        /// <param name="depObj">Object w którym szukamy T typu</param>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
