using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copahabana_1.Klasy
{
    public class Druzyna
    {
        public string nazwa { get; set; }

        public List<Zawodnik> Zawodnicy;

        

        public Druzyna(string nazwa, List<Zawodnik> zaw)
        {
            Zawodnicy = zaw;
            this.nazwa = nazwa;
        }

        public void DodajZawodnika(Zawodnik a)
        {
            Zawodnicy.Add(a);
        }
        public void UsunZawodnika(Zawodnik a)
        {
            if (Zawodnicy.Contains(a)) {  Zawodnicy.Remove(a); }
        }
        public List<Zawodnik> ZwrocZawodnikow()
        {
            return Zawodnicy;
        }

        // metoda losuje podaną ilość zawodników z druzyny
        public List<Zawodnik> WylosujZawodnika(int ilosc)
        {
            int ilosc_zaw = Zawodnicy.Count();
            List<Zawodnik> wylosowani = new List<Zawodnik>();
            var random = new Random();
            for(int j = 0; j < ilosc; j++)
            {
                int val = random.Next(ilosc_zaw);
                Zawodnik on = Zawodnicy[val];
                if (!wylosowani.Contains(on))
                {
                    wylosowani.Add(on);
                }
                else
                {
                    while (wylosowani.Contains(on))
                    {
                        on = Zawodnicy[random.Next(ilosc_zaw)];
                    }
                }
            }
            return wylosowani;

        }

    }
}
