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
using System.Windows.Shapes;
using copahabana_1.Pages;
using copahabana_1.Klasy;

namespace copahabana_1.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj_Sedziego.xaml
    /// </summary>
    public partial class Dodaj_Sedziego : Window
    {
        public Dodaj_Sedziego()
        {
            InitializeComponent();
        }

        private void Dodaj_sedziego(object sender, RoutedEventArgs e)
        {
            if(Sedzia_Imie.Text=="" || Sedzia_Nazwisko.Text == "")
            {
                MessageBox.Show("Proszę wprowadzić poprawne dane");
            }
            else
            {
                App.listaSedziow.Add(new Sedzia(Sedzia_Imie.Text, Sedzia_Nazwisko.Text));
                
                this.Close();
            }
        }
    }
}
