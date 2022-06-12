using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copahabana_1.Klasy
{
    public class Sedzia : Osoba
    {
        
        
        

        public Sedzia(string imie, string nazw) : base(imie, nazw) {  }
        public override string ToString()
        {
            return base.imie + "," + base.nazw;
        }
    }
}
