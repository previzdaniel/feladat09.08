using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace feladat09_08
{
    class Program
    {
        //Tulajdonságok
        static string[] lehetoseg = new string[3] { "kő", "papír", "olló" };

        static int gepNyer = 0;
        static int jatekosNyer = 0;
        static int menet = 0;
        static bool tovabb = true;
        //-----------------------------------------------------------------------
        static int EmberNyer(int gep, int ember)
        {
            if (lehetoseg[gep] == "kő" && lehetoseg[ember] == "papír" ||
                lehetoseg[gep] == "papír" && lehetoseg[ember] == "olló" ||
                lehetoseg[gep] == "olló" && lehetoseg[ember] == "kő")
            {
                jatekosNyer++;
                return 2;
            }
            else if (lehetoseg[gep] == "kő" && lehetoseg[ember] == "olló" ||
                lehetoseg[gep] == "papír" && lehetoseg[ember] == "kő" ||
                lehetoseg[gep] == "olló" && lehetoseg[ember] == "papír")
            {
                gepNyer++;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static int GepValasztas()
        {
            Random veletlen = new Random();
            return veletlen.Next(0, 2);
        }

        static int JatekosValasztas()
        {
            Console.WriteLine("kő(0), papír(1), olló(2)");
            Console.Write("Válassz: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void EredmenyKiiras(int gep, int ember)
        {
            Console.WriteLine("Gép: {0} --- játékos {1}", lehetoseg[gep], lehetoseg[ember]);
            switch (EmberNyer(gep, ember))
            {
                case 0:
                    Console.WriteLine("Döntetlen!");
                    break;
                case 1:
                    Console.WriteLine("Skynet nyert!");
                    break;
                case 2:
                    Console.WriteLine("Játékos nyert!");
                    break;
            }
        }

        private static bool AkarJatszani()
        {
            Console.WriteLine("**************************************************************");
            Console.Write("Tovább? [i/n]:");
            string valasz = Console.ReadLine().ToLower();
            Console.WriteLine("\n**************************************************************");
            if (valasz == "i")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void StatisztikaKiiras()
        {
            Console.WriteLine("Menetek száma: {0}, " +
                              "\tJátékos győzelmek száma: {1}, " +
                              "\tGép győzelmek száma: {2}", menet, jatekosNyer, gepNyer);
        }

        private static void StatisztikaFajlbol()
        {
            Console.WriteLine("---------------> Statisztika <---------------");
            Console.WriteLine("Menet\tJátékos győzelmek\tGép győzelmek");
            StreamReader stat = new StreamReader("Statisztika.txt");
            while (!stat.EndOfStream)
            {
                string[] szovegAdat = stat.ReadLine().Split(';');
                int[] adat = new int[3];
                //adat[0] = int.Parse(szovegAdat[0]);
                //adat[1] = int.Parse(szovegAdat[1]);
                //adat[2] = int.Parse(szovegAdat[2]);
                for (int i = 0; i < adat.Length; i++)
                {
                    adat[i] = int.Parse(szovegAdat[i]);
                }
                Console.WriteLine("|{0,3}|\t      |{1,3}|\t\t    |{2,3}|", adat[0], adat[1], adat[2]);
            }
            stat.Close();

            Console.WriteLine("-------------> Statisztika vége <-------------\n");
        }


        static void Main(string[] args)
        {
            StatisztikaFajlbol();

            while (tovabb)
            {
                menet++;

                int jatekosValasz = JatekosValasztas();

                int gepValasz = GepValasztas();

                EredmenyKiiras(gepValasz, jatekosValasz);

                tovabb = AkarJatszani();
            }

            StatisztikaKiiras();

            StatisztikaFajlba();

            Console.ReadKey();
        }


        private static void StatisztikaFajlba()
        {
            string adat = menet.ToString()+";"+
                          jatekosNyer.ToString()+";"+
                          gepNyer.ToString();
            //FileStream ki = new FileStream("Statisztika.txt", FileMode.Append);
            StreamWriter sKi = new StreamWriter("Statisztika.txt", true);
            sKi.WriteLine(adat);
            sKi.Close();
        }
    }
}
