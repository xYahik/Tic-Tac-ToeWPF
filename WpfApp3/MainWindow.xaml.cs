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
        private bool Czy_Ruch_Gracza_1;
        private bool Czy_Gra_Zakończona;
        public MainWindow()
        {
            InitializeComponent();
            WyrszajPrzyjacielu();
        }

        private void WyrszajPrzyjacielu()
        {
            znaki = new Znaki[9];
            for (var i = 0; i < znaki.Length; i++)
                znaki[i] = Znaki.PustaKomórka;

            Czy_Ruch_Gracza_1 = true;

            Conteiner.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.Red;
                button.Foreground = Brushes.Green;
            });
            Czy_Gra_Zakończona = false;
        }

        private void Button_Cl(object sender, RoutedEventArgs e)
        {
            if (Czy_Gra_Zakończona)
            {
                WyrszajPrzyjacielu();
                return;
            }

            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if(znaki[index] != Znaki.PustaKomórka)
            {
                return;
            }
            if (Czy_Ruch_Gracza_1)
            {
                znaki[index] = Znaki.Znak_O;
            }
            else
            {
                znaki[index] = Znaki.Znak_X;
            }
            if (Czy_Ruch_Gracza_1)
            {
                button.Content = "O";
            }
            else
            {
                button.Content = "X";
            }
            if (Czy_Ruch_Gracza_1)
            {
                Czy_Ruch_Gracza_1 = false;
            }
            else
            {
                Czy_Ruch_Gracza_1 = true;
            }
            Wygrana();
        }

        private void Wygrana()
        {
            //xxx
            //---
            //---
            if(znaki[0]!=Znaki.PustaKomórka && (znaki[0]&znaki[1]&znaki[2])== znaki[0])
            {
                Czy_Gra_Zakończona = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }
            //---
            //xxx
            //---
            if (znaki[3] != Znaki.PustaKomórka && (znaki[3] & znaki[4] & znaki[5]) == znaki[3])
            {
                Czy_Gra_Zakończona = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }
            //---
            //---
            //xxx
            if (znaki[6] != Znaki.PustaKomórka && (znaki[6] & znaki[7] & znaki[8]) == znaki[6])
            {
                Czy_Gra_Zakończona = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            //--x
            //--x
            //--x
            if (znaki[2] != Znaki.PustaKomórka && (znaki[2] & znaki[5] & znaki[8]) == znaki[2])
            {
                Czy_Gra_Zakończona = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }
            //-x-
            //-x-
            //-x-
            if (znaki[1] != Znaki.PustaKomórka && (znaki[1] & znaki[4] & znaki[7]) == znaki[1])
            {
                Czy_Gra_Zakończona = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }
            //x--
            //x--
            //x--
            if (znaki[0] != Znaki.PustaKomórka && (znaki[0] & znaki[3] & znaki[6]) == znaki[0])
            {
                Czy_Gra_Zakończona = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }
            //x--
            //-x-
            //--x
            if (znaki[0] != Znaki.PustaKomórka && (znaki[0] & znaki[4] & znaki[8]) == znaki[0])
            {
                Czy_Gra_Zakończona = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }
            //--x
            //-x-
            //x--
            if (znaki[2] != Znaki.PustaKomórka && (znaki[2] & znaki[4] & znaki[6]) == znaki[2])
            {
                Czy_Gra_Zakończona = true;
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
            }

            if (!znaki.Any(x => x == Znaki.PustaKomórka))
            {
                Czy_Gra_Zakończona = true;
                Conteiner.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    
                    button.Background = Brushes.Purple;
                });
            }
        }
    }
}
