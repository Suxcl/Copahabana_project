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

            


        }


        public static int wartosc = 3;


        // To poniżej znajduje który przycisk z panelu nawigacji został kliknięty i przekierowywuje na odpowidznią stronę
        private void Kliknieto_opcje(object sender, RoutedEventArgs e)
        {
            var Wybrana_opcja = e.OriginalSource as NavButton;
            if (Wybrana_opcja != null) { NavigationService.Navigate(Wybrana_opcja.NavUri); }
        }

        private void ZamknijProgram(object sender, RoutedEventArgs e)
        {
            App.ZapiszSedziow();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
