using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat09_08
{
    class Program
    {
        static string[] lehetoseg = new string[3] { "kő", "papír", "olló" };

        static int EmberNyer(int gep, int ember)
        {
            if (lehetoseg[gep] == "kő" && lehetoseg[ember] == "papír" ||
                lehetoseg[gep] == "papír" && lehetoseg[ember] == "olló" ||
                lehetoseg[gep] == "olló" && lehetoseg[ember] == "kő")
            {
                return 2;
            }
            else if (lehetoseg[gep] == "kő" && lehetoseg[ember] == "olló" ||
                lehetoseg[gep] == "papír" && lehetoseg[ember] == "kő" ||
                lehetoseg[gep] == "olló" && lehetoseg[ember] == "papír")
            {
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

        
        static void Main(string[] args)
        {
            bool tovabb = true;

            while (tovabb)
            {
                int jatekosValasz = JatekosValasztas();

                int gepValasz = GepValasztas();

                EredmenyKiiras(gepValasz, jatekosValasz);

                tovabb = AkarJatszani();
            }

            Console.ReadKey();
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
    }
}
