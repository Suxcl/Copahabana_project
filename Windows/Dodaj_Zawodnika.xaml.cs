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
using System.Collections.ObjectModel;
using copahabana_1.Klasy;

namespace copahabana_1.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj_Zawodnika.xaml
    /// </summary>
    public partial class Dodaj_Zawodnika : Window
    {
        

        public Zawodnik on { get; set; }
        public Dodaj_Zawodnika()
        {
            InitializeComponent();
            
        }
        private void Dodaj_Zaw(object sender, RoutedEventArgs e)
        {
            if(Zaw_Imie.Text != "" && Zaw_Nazwisko.Text != "")
            {
                on = new Zawodnik(Zaw_Imie.Text, Zaw_Nazwisko.Text);
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić poprawne dane");
            }
            
        }
        
    }
}
