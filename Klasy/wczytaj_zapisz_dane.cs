using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace copahabana_1.Klasy
{
    public class wczytaj_zapisz_dane
    {
        

        string Path_Sedziowie = @"\DaneSedziow.txt";
        string Path_Druzyny = @"\DaneDruzyn.xml";
        string Path_Rozgrywki = @"\DaneRozgrywek.txt";

        // ===== Sedziowie =====
        public void WczytajSedziow()
        {
            if (File.Exists(Path_Sedziowie))
            {
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
            }
        }

        public void ZapiszSedziow()
        {
            List<Sedzia> lista = App.GetListSedzia();
            if (File.Exists(Path_Sedziowie))
            {
                
                using (StreamWriter sw = new StreamWriter(Path_Sedziowie)) 
                {
                    foreach (Sedzia s in lista)
                    {
                        sw.WriteLine(s.ToString());
                    }
                    sw.Close();
                }
            }
        }
        // ===== Druzyny =====

        /*
        public void WczytajDruzyny()
        {
            if (File.Exists(Path_Druzyny))
            {
                string[] text = File.ReadAllLines(Path_Druzyny);
                foreach (string line in text)
                {
                    if (line != "")
                    {
                        string[] dane = line.Split('|');
                        string[] zaw = dane[1].Split(',');
                        List<string> zaw_list = new List<string>();
                        List<Zawodnik> zaw_zaw = new List<Zawodnik>();
                        foreach(string s in zaw) {
                            string[] imie_nazw_zaw = s.Split(",");
                                }

                        App.listaDruzyn.Add(new Druzyna(dane[0], zaw_list));
                        System.Diagnostics.Trace.WriteLine("Bruh" + dane);
                    }
                }
            }
        }
        */
       

        /// <summary>
        /// Writes the given object instance to an XML file.
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [XmlIgnore] attribute.</para>
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        /// 
        /*
        public void ZapiszDruzny<Druzyna>(Druzyna objectToWrite, bool append = false) where Druzyna : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(Druzyna));
                writer = new StreamWriter(Path_Druzyny , append );
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        //
        */
        public void ZapiszDruzyny()
        {
            if (File.Exists(Path_Druzyny))
            {
                TextWriter writer = new StreamWriter(Path_Druzyny);
                foreach (Druzyna Dr in App.listaDruzyn)
                {
                    try
                    {
                        var serializer = new XmlSerializer(typeof(Druzyna));
                        serializer.Serialize(writer, Dr);
                    }
                    finally
                    {
                        if (writer != null)
                            writer.Close();
                    }
                }
            }
            
        }

        /// <summary>
        /// Reads an object instance from an XML file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the XML file.</returns>
        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }


        }

        public void WczytajDruzyny()
        {
            if (File.Exists(Path_Druzyny))
            {
                TextWriter reader = new StreamWriter(Path_Druzyny);
                var serializer = new XmlSerializer(typeof(Druzyna));
                
            }
        }


            // ===== Rozgrywki =====

        }
}
