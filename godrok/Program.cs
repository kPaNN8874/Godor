﻿
using System;
using System.Collections.Generic;
using System.IO;
namespace godrok
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] ut = new int[2001];
            int meter = 0;
            List<Godorcs> godrok = new List<Godorcs>();
            Console.WriteLine("1. feladat");
            StreamReader olvaso = new StreamReader("melyseg.txt");
            while (!olvaso.EndOfStream)
            {
                meter++;
                ut[meter] = int.Parse(s: olvaso.ReadLine());
            }
            Console.WriteLine("A fájl adatainak száma: {0}", meter);
            olvaso.Close();
            Console.WriteLine("2. feladat");
            Console.Write("Adjon meg egy távolságértéket! ");
            int hely = int.Parse(Console.ReadLine());
            Console.WriteLine("Ezen a helyen a felszín {0} méter mélyen van.", ut[hely]);
            Console.WriteLine("3. feladat");
            int sima = 0;
            for (int i = 0; i < meter; i++)
                if (ut[i] == 0)
                    sima++;
            Console.WriteLine("Az érintetlen terület aránya {0:P2}.", (double)sima / meter);
            #region 4. feladat - Gödrök készítése, kiírása
            int m = 2;
            while (m < meter)
            {
                if (ut[m - 1] == 0 && ut[m] != 0) 
                {
                    Godorcs ujgodor = new Godorcs();
                    ujgodor.Eleje = m;
                    ujgodor.Adatok.Add(ut[m]);
                    m++;
                    while (ut[m] != 0)
                    {
                        ujgodor.Adatok.Add(ut[m]);
                        m++;
                    }
                    ujgodor.Vege = m - 1;
                    godrok.Add(ujgodor);
                }
                m++;
            }
            StreamWriter kiiro = new StreamWriter("godrok.txt");
            for (int i = 0; i < godrok.Count; i++)
            {
                kiiro.WriteLine(godrok[i]);
            }
            kiiro.Close();
            #endregion
            Console.WriteLine("5. feladat");
            Console.WriteLine("A gödrök száma: {0}", godrok.Count);

            Console.WriteLine("6. feladat");
            int ez = 0;
            while (godrok[ez].Vege < hely)
                ez++;
            bool G = godrok[ez].Eleje <= hely && godrok[ez].Vege >= hely;
            if (!G)
            {
                Console.WriteLine("Az adott helyen nincs gödör.");
            }
            else
            {
                Console.WriteLine("a)");
                Console.WriteLine("A gödör kezdete: {0} méter, a gödör vége: {1} méter.", godrok[ez].Eleje, godrok[ez].Vege);

                Console.WriteLine("b)");
                Console.WriteLine(godrok[ez].Melyulo() ? "Folyamatosan mélyül." : "Nem mélyül folyamatosan.");

                Console.WriteLine("c)");
                Console.WriteLine("A legnagyobb mélysége {0} méter.", godrok[ez].Maxmely());

                Console.WriteLine("d)");
                Console.WriteLine("A térfogata {0} m ^ 3.", godrok[ez].V(0));

                Console.WriteLine("e)");
                Console.WriteLine("A vízmennyiség {0} m ^ 3.", godrok[ez].V(1));
            }
        }
    }
}