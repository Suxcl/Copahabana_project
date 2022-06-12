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
    /// Logika interakcji dla klasy Edytuj_Sedziego.xaml
    /// </summary>
    public partial class Edytuj_Sedziego : Window
    {
        public Sedzia a { get; set; }
        public Edytuj_Sedziego(Sedzia a)
        {
            InitializeComponent();

            this.a = a;
            this.Sedzia_Imie.Text = a.imie;
            this.Sedzia_Nazwisko.Text = a.nazw;

        }

        private void Edycja_Sedziego(object sender, RoutedEventArgs e)
        {
            if(this.Sedzia_Imie.Text != "" && this.Sedzia_Nazwisko.Text != "")
            {
                
                a.imie = Sedzia_Imie.Text;
                a.nazw = Sedzia_Nazwisko.Text;
                System.Diagnostics.Trace.WriteLine(a);
                this.Close();
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić poprawne dane");
            }
        }
    }
}
