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



namespace copahabana_1.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        // To poniżej znajduje który przycisk z panelu nawigacji został kliknięty i przekierowywuje na odpowidznią stronę
        private void Kliknieto_opcje(object sender, RoutedEventArgs e)
        {
            var Wybrana_opcja = e.OriginalSource as NavButton;
            if(Wybrana_opcja != null) { NavigationService.Navigate(Wybrana_opcja.NavUri); }
        }


        public abstract class osoba
        {
            protected string imie { get; }
            protected string nazw { get; }

            public osoba(string imie, string nazw)
            {
                this.imie = imie;
                this.nazw = nazw;
            }

        }
        public class Sedzia : osoba
        {
            public int rozegrane_spotkania { get; set; }
            public Sedzia(string imie, string nazw) : base(imie, nazw) { }

            public override string ToString()
            {
                return this.imie + " " + this.nazw;
            }
        }


        public Sedzia sedzia1 = new Sedzia("Jan", "niezbędny");


        public List<Sedzia> SedziaList { get; set; } = new List<Sedzia> { };


    }
}
