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
using copahabana_1.Klasy;

namespace copahabana_1.Windows
{
    public partial class Edycja_Druzyny : Window
    {
        public Druzyna Dr { get; set; }
        public Edycja_Druzyny(Druzyna a)
        {
            InitializeComponent();

            this.Dr = a;
            name_druzyna.Text = Dr.nazwa;

            ListaZawodnikowDruzyny_listbox.ItemsSource = Dr.Zawodnicy;
        }

        private void Dodaj_zawodnika_btn(object sender, RoutedEventArgs e)
        {
            Dodaj_Zawodnika dz = new Dodaj_Zawodnika();
            dz.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Nullable<bool> wynik = dz.ShowDialog();
            if (wynik == false)
            {
                Zawodnik ontu = dz.on;
                Dr.Zawodnicy.Add(ontu);
                ListaZawodnikowDruzyny_listbox.Items.Refresh();
            }

        }

        private void Usun_zawodnika_btn(object sender, RoutedEventArgs e)
        {
            if (ListaZawodnikowDruzyny_listbox.SelectedItems.Count > 0)
            {
                Zawodnik a = ListaZawodnikowDruzyny_listbox.SelectedItem as Zawodnik;
                Dr.Zawodnicy.Remove(a);
                ListaZawodnikowDruzyny_listbox.Items.Refresh();
            }
        }

        private void Zapisz_zmiany_btn(object sender, RoutedEventArgs e)
        {
            if (name_druzyna.Text != "" && ListaZawodnikowDruzyny_listbox.Items.Count > 0)
            {
                Dr.nazwa = name_druzyna.Text;
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić poprawne dane");
            }
        }
    }
}
