using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace copahabana_1.Klasy
{
    public class wczytaj_zapisz_dane
    {
        

        string Path_Sedziowie = "/DaneSedziow.txt";
        public void WczytajSedziow()
        {
            //Trace.WriteLine(System.IO.File.Exists(Path_Sedziowie));
            /*
             * 
             * nie działa bo nie wiem dlaczego nie m,oże znaleźć ścieżki
             * 
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = Path.Combine(directory, "DaneSedziow.txt"); 
            Environment.CurrentDirectory = "F:\\";
            */
            
      
            
      
            
            //File.Exists(Path_Sedziowie
            if (true)
            {

                

                /*
                    string[] text = File.ReadAllLines(Path_Sedziowie);
                foreach (string line in text)
                {
                    if (line != "")
                    {
                        string[] dane = line.Split(',');
                        App.listaSedziow.Add(new Sedzia(dane[0], dane[1]));
                        System.Diagnostics.Trace.WriteLine("Bruh" + dane);
                    }
                }
                */
            }
            
        }

        public void ZapiszSedziow()
        {
            ObservableCollection<Sedzia> lista = App.listaSedziow;
            if (File.Exists(Path_Sedziowie))
            {   
                using(TextWriter writer = new StreamWriter(Path_Sedziowie))
                {
                    foreach (Sedzia s in lista)
                    {
                        writer.WriteLine(s.ToString());
                    }
                }
                
            }
            
        }
       
    }
}
