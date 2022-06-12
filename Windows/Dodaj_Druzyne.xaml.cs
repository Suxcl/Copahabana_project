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
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace copahabana_1.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj_Druzyne.xaml
    /// </summary>
    public partial class Dodaj_Druzyne : Window
    {
        public Dodaj_Druzyne()
        {
            InitializeComponent();
            ListaZawodnikowDruzyny_listbox.ItemsSource = GetObsCollZaw();

        }

        public static ObservableCollection<Zawodnik> zawodnicy_listbox = new ObservableCollection<Zawodnik>();  
        public ObservableCollection<Zawodnik> GetObsCollZaw() { return zawodnicy_listbox; }
        public List<Zawodnik> GetzawAsLista() { return new List<Zawodnik>((IEnumerable<Zawodnik>)zawodnicy_listbox); }


        private void Dodaj_zawodnika_btn(object sender, RoutedEventArgs e)
        {
            Dodaj_Zawodnika dz = new Dodaj_Zawodnika();
            dz.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Nullable<bool> wynik = dz.ShowDialog();

            if (wynik == false)
            {
                Zawodnik ontu = dz.on;
                zawodnicy_listbox.Add(ontu);
                ListaZawodnikowDruzyny_listbox.Items.Refresh();
            }
            

        }

        private void Usun_zawodnika_btn(object sender, RoutedEventArgs e)
        {
            if(ListaZawodnikowDruzyny_listbox.SelectedItems.Count > 0)
            {
                Zawodnik a = ListaZawodnikowDruzyny_listbox.SelectedItem as Zawodnik;
                zawodnicy_listbox.Remove(a);
            }
        }

        private void Dodaj_druzyne_btn(object sender, RoutedEventArgs e)
        {
            
            if (name_druzyna.Text != "" && zawodnicy_listbox.Count() > 0)
            {
                App.listaDruzyn.Add(new Druzyna(name_druzyna.Text, GetzawAsLista()));
                
                this.Close();
            }
            
        }
    }
}
