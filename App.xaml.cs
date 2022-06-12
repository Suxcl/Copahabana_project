using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using copahabana_1.Pages;
using copahabana_1.Klasy;
using System.Collections.ObjectModel;

namespace copahabana_1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // klasa zapisu i odczytu wartosci z plików
        public static wczytaj_zapisz_dane wczytywanie_zapisywanie = new wczytaj_zapisz_dane();
         

        



        // ===== Sędziowie =====

        public static ObservableCollection<Sedzia> listaSedziow = new ObservableCollection<Sedzia>();
        public static List<Sedzia> GetListSedzia() { return new List<Sedzia>((IEnumerable<Sedzia>)App.listaSedziow); }
        public static ObservableCollection<Sedzia> GetObsCollSedzia() { return listaSedziow; }
        public static void AddSedzia_To_List(Sedzia a) { listaSedziow.Add(a); }

        //public static void RemoveSedzia_From_List(Sedzia a) { listaSedziow.Remove(a); }
        

        public static List<Sedzia> LosujSedziegoBadzWielu(int ilosc) 
        { 
            List<Sedzia> sedzias = new List<Sedzia>();
            var random = new Random();

            for (int j = 0; j < ilosc; j++)
            {
                int ilosc_sedziow = listaSedziow.Count();
                int val = random.Next(ilosc_sedziow);
                Sedzia on = listaSedziow[val];
                if (!sedzias.Contains(on))
                {
                    sedzias.Add(on);
                }
                else
                {
                    while (sedzias.Contains(on)){
                        on = listaSedziow[random.Next(ilosc_sedziow)];
                    }
                }
                
            }
            return sedzias;
            
        }


        //Wczytywanie zapisywanie --na razie nie działa--
        public static void WczytajSedziow() { wczytywanie_zapisywanie.WczytajSedziow(); }
        public static void ZapiszSedziow() { wczytywanie_zapisywanie.ZapiszSedziow(); }


        // ===== Zawodnicy =====

        public static ObservableCollection<Zawodnik> listaZawodnikow = new ObservableCollection<Zawodnik>();

        public static ObservableCollection<Zawodnik> GetObsCollZawodnik() { return listaZawodnikow; }
        public static List<Zawodnik> GetListaZawodnikow() { return new List<Zawodnik>((IEnumerable<Zawodnik>)listaZawodnikow); }

        // ===== Druzyny =====

        public static ObservableCollection<Druzyna> listaDruzyn = new ObservableCollection<Druzyna>();

        public static ObservableCollection<Druzyna> GetObsCollDruzyna() { return listaDruzyn; }
        public static List<Druzyna> GetListaDruzyn() { return new List<Druzyna>((IEnumerable<Druzyna>)listaDruzyn); }
        
        // ===== Rozgrywki =====

        public static ObservableCollection<Rozgrywka> listaRozgrywek = new ObservableCollection<Rozgrywka>();

        public static ObservableCollection<Rozgrywka> GetObsCollRozgrywki() { return listaRozgrywek; }
        public static List<Rozgrywka> GetListaRozgrywek() { return new List<Rozgrywka>((IEnumerable<Rozgrywka>)App.listaRozgrywek); }
        



    }
}
