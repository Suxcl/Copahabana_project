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
using copahabana_1.Windows;
using copahabana_1.Klasy;

namespace copahabana_1.Pages
{

    public partial class Druzyny : Page
    {
        public Druzyny()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Zawodnik> temp = new List<Zawodnik>();
            temp.Add(new Zawodnik("Paweł", "Rudź1"));
            temp.Add(new Zawodnik("Paweł", "Rudź2"));
            temp.Add(new Zawodnik("Paweł", "Rudź3"));
            temp.Add(new Zawodnik("Paweł", "Rudź4"));
            App.listaDruzyn.Add(new Druzyna("Bocian Boćki", temp));

            this.ListaDruzyn_listobox.ItemsSource = App.GetObsCollDruzyna();


        }

        

        private void Dodaj_Druzyne_btn(object sender, RoutedEventArgs e)
        {
            var dod_dru = new Dodaj_Druzyne();
            dod_dru.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dod_dru.ShowDialog();
        }

        private void Edytuj_Druzyne_btn(object sender, RoutedEventArgs e)
        {
            if(ListaDruzyn_listobox.SelectedItems.Count == 1)
            {
                Druzyna a = this.ListaDruzyn_listobox.SelectedItem as Druzyna;
                Edycja_Druzyny tak = new Edycja_Druzyny(a);
                tak.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                if (tak.ShowDialog() == false)
                {
                    (ListaDruzyn_listobox.SelectedItem as Druzyna).Zawodnicy = tak.Dr.Zawodnicy;
                    
                    
                }
                this.ListaDruzyn_listobox.ItemsSource = App.GetObsCollDruzyna();

            }
        }
        private void Usun_Druzyne_btn(object sender, RoutedEventArgs e)
        {
            if (ListaDruzyn_listobox.SelectedItems.Count != 0)
            {
                Druzyna a = ListaDruzyn_listobox.SelectedItem as Druzyna;  
                App.listaDruzyn.Remove(a);                                 
            }
        }

        private void listaDruzyn_listobox_selectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (ListaDruzyn_listobox.Items.Count != 0)
            {
                Druzyna a = ListaDruzyn_listobox.SelectedItem as Druzyna;
                Nazwa_druzyny_textblock.Text = a.nazwa;
                ListaZawodnikow_listview.ItemsSource = a.Zawodnicy;
            }
            else
            {
                Nazwa_druzyny_textblock.Text = "";
                ListaZawodnikow_listview.ItemsSource = null;
            }
            
        }
    }
}
