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
using copahabana_1.Klasy;
using copahabana_1.Windows;
using copahabana_1.Pages;
using System.Diagnostics;
using System.IO;

namespace copahabana_1.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Sedziowie.xaml
    /// </summary>
    public partial class Sedziowie : Page
    {
        public Sedziowie()
        {
            InitializeComponent();

            this.ListaSedziow_listbox.ItemsSource = App.GetObsCollSedzia();


        }

        
        // Dodanie nowego sędziego poprzed nowe okno
        private void Dodaj_Sedziego(object sender, RoutedEventArgs e)
        {
            Dodaj_Sedziego dod_sed = new Dodaj_Sedziego();
            dod_sed.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _ = dod_sed.ShowDialog();
        }

        private void Edytuj_Sedziego(object sender, RoutedEventArgs e)
        {
            
            if (ListaSedziow_listbox.SelectedItems.Count == 1)
            {
                Sedzia? a = ListaSedziow_listbox.SelectedItem as Sedzia;
                var edycja_sedziego = new Edytuj_Sedziego(a);                   // stworzenie klasy okna edycji sędziego i przekazanie parametru wybranego z lisboxa
                edycja_sedziego.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                edycja_sedziego.ShowDialog();
                ListaSedziow_listbox.Items.Refresh();                           // jako że lista sędziów jest statyczna trzeba ją manulanie odświeżyć
            }
        }

        private void Usun_Sedziego(object sender, RoutedEventArgs e)
        {
            if (ListaSedziow_listbox.SelectedItems.Count!=0)                        // sprawdzenie czy cokolwiek jest zaznaczone
            {
                Sedzia a = ListaSedziow_listbox.SelectedItem as Sedzia;           // zczytanie zazanczonej wartosci jako klasa Sedzia
                App.listaSedziow.Remove(a);
             
            }

        }
    }
}

