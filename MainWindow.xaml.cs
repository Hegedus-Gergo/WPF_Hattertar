using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int mennyiseg = Convert.ToInt32(adatmennyiseg.Text);
            
            if (adatmennyisegmertekegyseg.SelectedIndex == 1) {
                mennyiseg *= 1000;
            }
            if (adatmennyisegmertekegyseg.SelectedIndex == 2) {
                mennyiseg *= 1000000;
            }
            if (adatmennyisegmertekegyseg.SelectedIndex == 3)
            {
                mennyiseg *= 1000000000;
            }

            int sebesseg = Convert.ToInt32(csuszka.Value);

            if (sebessegmertekegyseg.SelectedIndex == 1)
                sebesseg *= 1000;
            if (sebessegmertekegyseg.SelectedIndex == 2)
                sebesseg *= 1000000;

            int second = mennyiseg / sebesseg;
            int ora=0, perc=0, nap=0;
            if (second > 60) {
                perc = second / 60;
                second = second - perc * 60;
            }
//            perc = second > 60 ? second / 60 : 0;
            if (perc > 60)
            { ora = perc/60;
                perc = perc - ora * 60;
            }

            if (ora > 24) {
                nap = ora / 24;
                ora = ora - nap * 24;
            }

            if (nap==0 && ora == 0 && perc == 0)
            lbido.Content = second + "s";
            else if (nap==0 && ora == 0)
            lbido.Content = perc+"m" + second + "s";
            else if (nap == 0)
            lbido.Content = ora+"h"+perc+"m"+second+"s";
            else
            lbido.Content = nap+"d"+ora + "h" + perc + "m" + second + "s";
        }

        private void csuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            csuszkaertek.Content = Math.Round(csuszka.Value);
        }
    }
}