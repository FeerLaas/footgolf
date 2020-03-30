using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace footgolf
{
    class Versenyzo
    {
        public Versenyzo(string s)
        {
            var loc = s.Split(';');
            Nev = loc[0];
            Kategoria = loc[1] == "Felnott ferfi";
            Egyesulet = loc[2];
            Pontok = new int[8];
            for (int i = 3; i < loc.Length; i++) Pontok[i - 3] = int.Parse(loc[i]);
        }
        public string Nev { get; set; }
        public bool Kategoria { get; set; }
        public string Egyesulet { get; set; }
        public int[] Pontok { get; set; }
        public int Eredmeny()
        {
            Pontok = Pontok.OrderByDescending(x => x).ToArray();
            int pontszam = Pontok.Sum();
            for (int i = 6; i < Pontok.Length; i++)
            {
                if (Pontok[i] != 0) pontszam -= (Pontok[i] - 10);
            }
            return pontszam;
        }
    }
}
