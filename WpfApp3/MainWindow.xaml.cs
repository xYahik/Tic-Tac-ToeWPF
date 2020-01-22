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

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
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
        /// </summary>
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
            znaki = new Znaki[16];
            for (var i = 0; i < znaki.Length; i++)
                znaki[i] = Znaki.PustaKomórka;
            ButtonRewanz.IsEnabled = false;
            Czy_Ruch_Gracza_Pierwszego = true;
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

            Czy_Gra_Zakończona = false;
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
            
            if (Czy_Gra_Zakończona)
            {
                UpdateWynik();
                return;
            }

            var kratka = (Button)sender;
            var column = Grid.GetColumn(kratka);
            var row = Grid.GetRow(kratka);

            var index = column + (row * 4);
            if(znaki[index] != Znaki.PustaKomórka)
            {
                return;
            }
            if (Czy_Ruch_Gracza_Pierwszego)
            {
                znaki[index] = Znaki.Znak_O;

            }
            else
            {
                znaki[index] = Znaki.Znak_X;
            }
            if (Czy_Ruch_Gracza_Pierwszego)
            {
                kratka.Content = "O";
                kratka.Foreground = Brushes.Red;
            }
            else
            {
                kratka.Content = "X";
                kratka.Foreground = Brushes.Blue;
            }
            if (Czy_Ruch_Gracza_Pierwszego)
            {
                Czy_Ruch_Gracza_Pierwszego = false;
                if (_computerPlaying)
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
                Czy_Ruch_Gracza_Pierwszego = true;
            }

            Wygrana();

        }
        /// <summary>
        /// Ustalenie logiki gry
        /// </summary>
        private void Wygrana()
        {

            #region wPoziomie
            
            if ((znaki[0] & znaki[1] & znaki[2] & znaki[3]) == znaki[0] && znaki[0] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA1.Background = ButtonA2.Background = ButtonA3.Background = ButtonA4.Background = Brushes.Green;
            }
            if ((znaki[4] & znaki[5] & znaki[6] & znaki[7]) == znaki[4] && znaki[4] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonB1.Background = ButtonB2.Background = ButtonB3.Background = ButtonB4.Background = Brushes.Green;
            }
            if ((znaki[8] & znaki[9] & znaki[10] & znaki[11]) == znaki[8] && znaki[8] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonC1.Background = ButtonC2.Background = ButtonC3.Background = ButtonC4.Background = Brushes.Green;
            }
            if ((znaki[12] & znaki[13] & znaki[14] & znaki[15]) == znaki[12]&&znaki[12] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonD1.Background = ButtonD2.Background = ButtonD3.Background = ButtonD4.Background = Brushes.Green;
            }
            #endregion
            #region wPionie
            if ((znaki[0] & znaki[4] & znaki[8] & znaki[12]) == znaki[0]&& znaki[0] != Znaki.PustaKomórka )
            {
                Czy_Gra_Zakończona = true;
                ButtonA1.Background = ButtonB1.Background = ButtonC1.Background = ButtonD1.Background = Brushes.Green;
            }
            if ((znaki[1] & znaki[5] & znaki[9] & znaki[13]) == znaki[1]&&znaki[1] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA2.Background = ButtonB2.Background = ButtonC2.Background = ButtonD2.Background = Brushes.Green;
            }        
            if ((znaki[2] & znaki[6] & znaki[10] & znaki[14]) == znaki[2] && znaki[2] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA3.Background = ButtonB3.Background = ButtonC3.Background = ButtonD3.Background = Brushes.Green;
            }
            if ((znaki[3] & znaki[7] & znaki[11] & znaki[15]) == znaki[3]&&znaki[3] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA4.Background = ButtonB4.Background = ButtonC4.Background = ButtonD4.Background = Brushes.Green;
            }

            #endregion
            #region skosy
            if ((znaki[0] & znaki[5] & znaki[10] & znaki[15]) == znaki[0] && znaki[0] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA1.Background = ButtonB2.Background = ButtonC3.Background = ButtonD4.Background = Brushes.Green;
            }
            if ((znaki[3] & znaki[6] & znaki[9] & znaki[12]) == znaki[3] && znaki[3] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA4.Background = ButtonB3.Background = ButtonC2.Background = ButtonD1.Background = Brushes.Green;
            }
            #endregion
            #region kwadraty
            if ((znaki[0] & znaki[1] & znaki[4] & znaki[5]) == znaki[0] && znaki[0] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA1.Background = ButtonA2.Background = ButtonB1.Background = ButtonB2.Background = Brushes.Green;
            }
            if ((znaki[1] & znaki[2] & znaki[5] & znaki[6]) == znaki[1] && znaki[1] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA2.Background = ButtonA3.Background = ButtonB2.Background = ButtonB3.Background = Brushes.Green;
            }
            if ((znaki[2] & znaki[3] & znaki[6] & znaki[7]) == znaki[2] && znaki[2] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonA3.Background = ButtonA4.Background = ButtonB3.Background = ButtonB4.Background = Brushes.Green;
            }
            if ((znaki[4] & znaki[5] & znaki[8] & znaki[9]) == znaki[4] && znaki[4] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonB1.Background = ButtonB2.Background = ButtonC1.Background = ButtonC2.Background = Brushes.Green;
            }
            if ((znaki[5] & znaki[6] & znaki[9] & znaki[10]) == znaki[5] && znaki[5] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonB2.Background = ButtonB3.Background = ButtonC2.Background = ButtonC3.Background = Brushes.Green;
            }
            if ((znaki[6] & znaki[7] & znaki[10] & znaki[11]) == znaki[6] && znaki[6] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonB3.Background = ButtonB4.Background = ButtonC3.Background = ButtonC4.Background = Brushes.Green;
            }
            if ((znaki[8] & znaki[9] & znaki[12] & znaki[13]) == znaki[8] && znaki[8] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonC1.Background = ButtonC2.Background = ButtonD1.Background = ButtonD2.Background = Brushes.Green;
            }
            if ((znaki[9] & znaki[10] & znaki[13] & znaki[14]) == znaki[9] && znaki[9] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonC2.Background = ButtonC3.Background = ButtonD2.Background = ButtonD3.Background = Brushes.Green;
            }
            if ((znaki[10] & znaki[11] & znaki[14] & znaki[15]) == znaki[10] && znaki[10] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonC3.Background = ButtonC4.Background = ButtonD3.Background = ButtonD4.Background = Brushes.Green;
            }
            #endregion

            bool _continue = true;
            foreach (Button button in FindVisualChildren<Button>(Conteiner))
            {

                if (!(button.Name == "ButtonReset" || button.Name == "ButtonRewanz" || button.Name == "ButtonPC") &&Czy_Gra_Zakończona)
                {
                    if (button.Background == Brushes.Green && _continue)
                    {
                        if (button.Content.ToString() == "X")
                        {
                            if(_computerPlaying)
                            wygranychX += 0.5f;
                            else
                            wygranychX += 1;
                        }
                        else if (button.Content.ToString() == "O")
                        {
                            if (_computerPlaying)
                                wygranychO += 0.5f;
                            else
                                wygranychO += 1;
                        }
                        _continue = false;
                    }
                        
                }
            }

            UpdateWynik();
            if (Czy_Gra_Zakończona)
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
            if (!znaki.Any(x => x == Znaki.PustaKomórka)&&Czy_Gra_Zakończona==false)
            {
                Czy_Gra_Zakończona = true;
                foreach (Button button in FindVisualChildren<Button>(Conteiner))
                {

                    if (!(button.Name == "ButtonReset" || button.Name == "ButtonRewanz" || button.Name == "ButtonPC") && Czy_Gra_Zakończona)
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
            if (!_computerPlaying)
            {
                wygranychO = 0;
                wygranychX = 0;
                _computerPlaying = true;
                przycisk.Foreground = Brushes.Green;
                Gracz2Nazwa = "PC";
                UpdateWynik();
            }
            else
            {
                wygranychO = 0;
                wygranychX = 0;
                _computerPlaying = false;
                przycisk.Foreground = Brushes.Black;
                Gracz2Nazwa = "Gracz";
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
            wygranychO = 0;
            wygranychX = 0;
            UpdateWynik();
        }
        /// <summary>
        /// Aktualizuje tabele wyników obu graczy.
        /// </summary>
        private void UpdateWynik()
        {
            
            WynikGracz1.Content = String.Format("Gracz1: {0}", wygranychO);
            WynikGracz2.Content = String.Format("{0}: {1}", Gracz2Nazwa, wygranychX);
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
