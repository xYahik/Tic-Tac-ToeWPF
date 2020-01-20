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
        private Znaki[] znaki;
        private bool Czy_Ruch_Gracza_Pierwszego;
        private bool Czy_Gra_Zakończona;
        public MainWindow()
        {
            InitializeComponent();
            ZaczynamyRozgrywke();
        }

        private void ZaczynamyRozgrywke()
        {
            znaki = new Znaki[16];
            for (var i = 0; i < znaki.Length; i++)
                znaki[i] = Znaki.PustaKomórka;

            Czy_Ruch_Gracza_Pierwszego = true;

            Conteiner.Children.Cast<Button>().ToList().ForEach(kratka =>
            {
                kratka.Content = string.Empty;
                kratka.Background = Brushes.DarkGray;
            });
            Czy_Gra_Zakończona = false;
        }

        private void Button_Cl(object sender, RoutedEventArgs e)
        {
            if (Czy_Gra_Zakończona)
            {
                ZaczynamyRozgrywke();
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
            }
            else
            {
                Czy_Ruch_Gracza_Pierwszego = true;
            }
            Wygrana();
        }

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
            if ((znaki[10] & znaki[11] & znaki[14] & znaki[15]) == znaki[0] && znaki[0] != Znaki.PustaKomórka)
            {
                Czy_Gra_Zakończona = true;
                ButtonC3.Background = ButtonC4.Background = ButtonD3.Background = ButtonD4.Background = Brushes.Green;
            }
            #endregion          
            if (!znaki.Any(x => x == Znaki.PustaKomórka)&&Czy_Gra_Zakończona==false)
            {
                Czy_Gra_Zakończona = true;
                Conteiner.Children.Cast<Button>().ToList().ForEach(kratka =>
                {                    
                    kratka.Background = Brushes.Purple;
                });
            }
        }
    }
}
