using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copahabana_1.Klasy
{
    public class Rozgrywka
    {
        public string Nazwa_rozgrywek;
        protected List<Spotkanie> Lista_spotkan;
        protected Dictionary<Druzyna, int> Wyniki_spotkan;
        public bool czy_zakonczono_faze_poczatkowa;
        protected Gra gra;
        protected List<Spotkanie> Spotkania_final;
        protected Dictionary<Druzyna, int> Wyniki_final;
        public bool Czy_zakonczono;

        public Rozgrywka(string nazwa_rozgr, Gra gra)
        {
            this.Nazwa_rozgrywek = nazwa_rozgr;
            int ilosc_druzyn = App.listaDruzyn.Count();

            List<Druzyna> list_druz = App.GetListaDruzyn();
            for(int i = 0; i < ilosc_druzyn-1; i++)
            {
                for(int j = i+1; j <ilosc_druzyn;j++)
                {
                    Lista_spotkan.Add(new Spotkanie(list_druz[i], list_druz[j], gra, App.GetListSedzia()));
                }
            }
            
            for(int k = 0; k < list_druz.Count; k++)
            {
                Wyniki_spotkan.Add(list_druz[k], 0);
            }
            czy_zakonczono_faze_poczatkowa = false;
            Czy_zakonczono = false;
            this.gra = gra;

        }

        protected void DodajPunkt(Druzyna a)
        {
            if (czy_zakonczono_faze_poczatkowa == false)
            {
                Wyniki_spotkan[a] = Wyniki_spotkan[a] + 1;
            }
            else{
                Wyniki_final[a] = Wyniki_final[a] + 1;
            }
        }

        public Dictionary<Druzyna, int> TablicaWynikow()
        {
            return Wyniki_spotkan;
        }
        public Dictionary<Druzyna, int> TablicaFinal()
        {
            return Wyniki_final;
        }
        public void KolejneSpotkanie()
        {
            if (czy_zakonczono_faze_poczatkowa == false)
            {
                int ilosc = 0;                               // zliczanie ilości spotkań
                foreach(Spotkanie sp in Lista_spotkan)
                {
                    ilosc++;
                    if (sp.czy_zakonczono == false)          // szukanie pierwszego spotkania które nie sotało rozegrane
                    {
                        sp.RozegrajSpotkanie();  
                        sp.czy_zakonczono = true;
                        DodajPunkt(sp.Wygrany);
                        break;                               // zakończenie pętli jeśli nierozegrane spotkanie zostało znalezione
                    }
                    
                }
                if (ilosc == Lista_spotkan.Count())         // jeśli żadne spotkaniez fazy każdy na każdego nie czeka na rozegranie 
                {                                           // tworzymy od razu fazę ćwierćfinałów
                    czy_zakonczono_faze_poczatkowa = true;
                    ilosc = 0;
                    List<Druzyna> druzyny_finalowe = new List<Druzyna>();
                    foreach (KeyValuePair<Druzyna, int> item in Wyniki_spotkan.OrderBy(key => key.Value)) 
                    { 
                        ilosc++;
                        druzyny_finalowe.Add(item.Key);                     //sortujemy dziennik by znaleźć
                        Wyniki_final[item.Key] = 0;                         // które drużyny mają najwięcej pkt i wybieramy ich 8
                        if (ilosc == 8) { break; }
                    }

                    List<int> numerki = new List<int>();
                    var random = new Random();                      //Rozlosowywanie spotkań ćwierćfinałów
                    int uno, dos;
                    while (Spotkania_final.Count < 4)
                    {
                        uno = random.Next(7);
                        while (numerki.Contains(uno))
                        {
                            uno = random.Next(7);
                        }
                        dos = random.Next(7);
                        while (numerki.Contains(dos))
                        {
                            dos = random.Next(7);
                        }
                        Spotkania_final.Add(new Spotkanie(druzyny_finalowe[uno], druzyny_finalowe[dos], gra, App.GetListSedzia()));
                    }
                }
            }
            else
            {
                if(Czy_zakonczono == false)
                {
                    int ilosc = 0;
                    foreach (Spotkanie sp in Spotkania_final)
                    {
                        ilosc++;
                        if (sp.czy_zakonczono == false)          
                        {
                            sp.RozegrajSpotkanie();
                            sp.czy_zakonczono = true;
                            DodajPunkt(sp.Wygrany);
                            if(ilosc == 7) { Czy_zakonczono = true; }         // w momencie gdy rozegramy 7 spotkanie(finałowe) nastepuje zmiana wartosci boolwskiej o zakończeniu rozgrywek
                            break;                               
                        }

                    }
                    if(ilosc == Spotkania_final.Count())
                    {
                        if(ilosc == 4) { 
                            Spotkania_final.Add(new Spotkanie(Spotkania_final[0].Wygrany, Spotkania_final[1].Wygrany, gra, App.GetListSedzia()));
                            Spotkania_final.Add(new Spotkanie(Spotkania_final[2].Wygrany, Spotkania_final[3].Wygrany, gra, App.GetListSedzia()));
                        }
                        if(ilosc == 6) {
                            Spotkania_final.Add(new Spotkanie(Spotkania_final[4].Wygrany, Spotkania_final[5].Wygrany, gra, App.GetListSedzia()));
                        }
                    }
                }
            }

        }

        
   

    }
}
