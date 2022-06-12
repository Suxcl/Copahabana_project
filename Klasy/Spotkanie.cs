using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copahabana_1.Klasy
{
    public class Spotkanie
    {
        public Druzyna DruzynaA;
        public Druzyna DruzynaB;
        public List<Zawodnik> ZawodnicyA; // należy wylosować odpowiedznią liczbę zawodników do wybranej gry
        public List<Zawodnik> ZawodnicyB;
        public string Rodzaj_Gry;
        public List<Sedzia> Sedziowie;
        public bool czy_zakonczono;
        public Druzyna Wygrany;

        public Spotkanie(Druzyna A, Druzyna B, Gra gra, List<Sedzia> Sedzia_Sedziowie)
        {

            DruzynaA = A;
            DruzynaB = B;
            ZawodnicyA = A.WylosujZawodnika(gra.Ilosc_zawodnikow);
            ZawodnicyB = B.WylosujZawodnika(gra.Ilosc_zawodnikow);
            this.Rodzaj_Gry = gra.Nazwa_gry;
            Sedziowie = App.LosujSedziegoBadzWielu(gra.Ilosc_sedziow);
            czy_zakonczono = false;
            
        }

        public void RozegrajSpotkanie()
        {
            // może się coś dopisze nie wiem jak na razie będzie 50/50
            var random = new Random();
            if (random.Next(100) + 1 < 50)
            {
                Wygrany = DruzynaA;
            }
            else
            {
                Wygrany = DruzynaB;
            }
            czy_zakonczono = true;
        }
    }
}
