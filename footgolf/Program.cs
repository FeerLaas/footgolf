using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace footgolf
{
    class Program
    {
        static List<Versenyzo> Mezony = new List<Versenyzo>();
        static void Main(string[] args)
        {
            F02();
            F03();
            F04();
            F06();
            F07();
            F08();
            Console.ReadKey();
        }

        private static void F08()
        {
            var egyesuletek = Mezony.GroupBy(x => x.Egyesulet).Select(x => new { EgyesuletNev = x.Key, EgyesuletCount = x.Count() }).ToList();
            for (int i = egyesuletek.Count - 1; i > 0; i--)
                if (egyesuletek[i].EgyesuletCount <= 2 || egyesuletek[i].EgyesuletNev == "n.a.") egyesuletek.Remove(egyesuletek[i]);
            Console.WriteLine("F08: Egyesület statisztika: ");
            foreach (var t in egyesuletek)
                Console.WriteLine($"\t{t.EgyesuletNev} - {t.EgyesuletCount} fő");

        }

        private static void F07()
        {
            StreamWriter sw = new StreamWriter(@"..\..\Res\oszpontFF.txt", false, Encoding.UTF8);
            var ffversenyzok = Mezony.Where(x => x.Kategoria == true);
            foreach (var f in ffversenyzok)
                sw.WriteLine($"{f.Nev};{f.Eredmeny()}");
            sw.Close();
        }

        private static void F06()
        {
            var legjobb = Mezony.Where(x => x.Kategoria == false).OrderByDescending(x => x.Eredmeny()).FirstOrDefault();
            Console.WriteLine($"F06: A bajnok női versenyző:\n\tNév: {legjobb.Nev}\n\tEgyesület: {legjobb.Egyesulet}\n\tÖsszpont: {legjobb.Eredmeny()}");
        }

        private static void F04()
        {
            Console.WriteLine($"F04: A női versenyzők aránya: {(((double)Mezony.Count(x => x.Kategoria == false) / Mezony.Count) * 100).ToString("0.00")}%");
        }

        private static void F03()
        {
            Console.WriteLine($"F03: Versenyzők száma: {Mezony.Count}");
        }

        private static void F02()
        {
            StreamReader sr = new StreamReader(@"..\..\Res\fob2016.txt", Encoding.UTF8);
            while (!sr.EndOfStream) Mezony.Add(new Versenyzo(sr.ReadLine()));
            Console.WriteLine("F02: Adatok feltöltve.");
            sr.Close();
        }
    }
}
