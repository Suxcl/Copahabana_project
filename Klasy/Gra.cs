using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copahabana_1.Klasy
{
    public class Gra
    {
        public string Nazwa_gry;
        public int Ilosc_sedziow;
        public int Ilosc_zawodnikow;

        public Gra(string nazwa, int ilosc_s, int ilosc_z)
        {
            Nazwa_gry = nazwa;
            Ilosc_sedziow = ilosc_s;
            Ilosc_zawodnikow = ilosc_z;
        }

    }
}
