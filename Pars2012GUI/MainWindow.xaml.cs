using System;
using System.Collections.Generic;
using System.IO;
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

namespace Pars2012GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Versenyző> versenyzok = new List<Versenyző>();
        public MainWindow()
        {
            InitializeComponent();


            //Adatfeltöltés
            File.ReadAllLines("../../../Selejtezo2012.txt").Skip(1).ToList().ForEach(x => versenyzok.Add(new Versenyző(x)));

            cbValaszt.ItemsSource = versenyzok.DistinctBy(x=>x.Nev).Select(x=>x.Nev);
            cbValaszt.SelectedItem = "Pars Krisztián";

        }

        private void cbValaszt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Versenyző kivalasztott = versenyzok.Where(n => n.Nev == cbValaszt.SelectedItem.ToString()).First();
            lblCsoport.Content = "Csoport: " + kivalasztott.Csoport;
            lblNemzet.Content = "Nemzet: " + kivalasztott.Nemzet;
            lblSorozat.Content = "Sorozat: "+ string.Join(';', kivalasztott.DobasokErdeti);
            lblEredmeny.Content = "Eredmény: " + kivalasztott.Eredmény;
            imgZaszlo.Source = new BitmapImage(new Uri($"Images/{kivalasztott.Kód}.png", UriKind.Relative));
        }
    }
}
