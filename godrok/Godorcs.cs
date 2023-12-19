using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace godrok
{
    internal class Godorcs
    {
            public int Eleje { get; set; }
            public int Vege { get; set; }
            public List<int> Adatok { get; set; }
            public Godorcs()
            {
                Adatok = new List<int>();
            }
            override public string ToString()
            {
                string sor = Adatok[0].ToString();
                for (int i = 1; i < Adatok.Count; i++)
                {
                    sor += " " + Adatok[i].ToString();
                }
                return sor;
            }
            public bool Melyulo()
            {
                int e = 1;
                while (e < Adatok.Count && Adatok[e - 1] <= Adatok[e]) e++;
                int v = Adatok.Count - 2;
                while (v >= 0 && Adatok[v + 1] <= Adatok[v]) v--;
                return e > v;
            }
            public int Maxmely()
            {
                int max = Adatok[0];
                for (int i = 1; i < Adatok.Count; i++)
                    if (max < Adatok[i])
                        max = Adatok[i];
                return max;
            }

            public int V(int szint)
            {
                int szum = 0;
                for (int i = 0; i < Adatok.Count; i++)
                {
                    if (Adatok[i] - szint > 0)
                        szum += Adatok[i] - szint;
                }
                return szum * 10;
            }
        }
    }

