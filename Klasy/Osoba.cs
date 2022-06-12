using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copahabana_1.Klasy
{
    public abstract class Osoba
    {
        public string imie { get; set; }
        public string nazw { get; set; }
        public Osoba(string imie, string nazw)
        {
            this.imie = imie;
            this.nazw = nazw;
        }

    }
}
