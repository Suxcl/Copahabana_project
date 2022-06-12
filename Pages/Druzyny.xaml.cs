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

            this.ListaDruzyn_listobox.ItemsSource = App.GetListaDruzyn();


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
                Druzyna? a = this.ListaDruzyn_listobox.SelectedItem as Druzyna;
                var tak = new Edycja_Druzyny();
                tak.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                tak.ShowDialog();
                ListaDruzyn_listobox.Items.Refresh();
            }
        }
        private void Usun_Druzyne_btn(object sender, RoutedEventArgs e)
        {
            if (ListaDruzyn_listobox.SelectedItems.Count != 0)
            {
                Druzyna a = ListaDruzyn_listobox.SelectedItem as Druzyna;  // to jest tak zrobione bo inaczej daje błąd
                App.listaDruzyn.Remove(a);                                 // czemu? nie wiem
            }
        }

        private void listaDruzyn_listobox_selectionChange(object sender, SelectionChangedEventArgs e)
        {
            Druzyna a = ListaDruzyn_listobox.SelectedItem as Druzyna;
            Nazwa_druzyny_textblock.Text = a.nazwa;
            ListaZawodnikow_listview.ItemsSource = a.Zawodnicy;
        }
    }
}
