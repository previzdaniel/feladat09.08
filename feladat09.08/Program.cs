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

        static void EredmenyKiiras(int gep, int ember)
        {
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
            Random  veletlen= new Random();
            

                int gepValasz = veletlen.Next(0, 2);

                //--------------------------------------------------------------------

                int jatekosValasz;

                Console.WriteLine("kő(0), papír(1), olló(2)");
                Console.Write("Válassz: ");
                jatekosValasz = Convert.ToInt32(Console.ReadLine());

                //Console.WriteLine("Játékos választása: {0}", lehetoseg[jatekosValasz]);
                Console.WriteLine("A gép választása: {0}", lehetoseg[gepValasz]);

                Console.WriteLine("Gép: {0} --- játékos {1}", lehetoseg[gepValasz], lehetoseg[jatekosValasz]);

            EredmenyKiiras(gepValasz, jatekosValasz);

            Console.ReadKey();
        }
    }
}
