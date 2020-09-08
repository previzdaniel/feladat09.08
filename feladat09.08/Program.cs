using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat09_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Random  veletlen= new Random();
            string[] lehetoseg = new string[] {"kő", "papír", "olló"};

            int gepValasz = veletlen.Next(0, 2);

            Console.WriteLine("A gép választása: {0}",lehetoseg[gepValasz]);
            //--------------------------------------------------------------------

            int jatekosValasz;

            Console.WriteLine("kő (0), papír(1), olló(2)");
            Console.Write("Válassz: ");
            jatekosValasz = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Játékos választása: {0}", lehetoseg[jatekosValasz]);
            //----------------------------------------------------------------------

            if (lehetoseg[gepValasz] == "kő" && lehetoseg[jatekosValasz] == "papír" || lehetoseg[gepValasz] == "papír" && lehetoseg[jatekosValasz] == "olló" || lehetoseg[gepValasz] == "olló" && lehetoseg[jatekosValasz] == "kő")
            {
                Console.WriteLine("A játékos nyert!");
            }
            if (lehetoseg[gepValasz] == "kő" && lehetoseg[jatekosValasz] == "olló" || lehetoseg[gepValasz] == "papír" && lehetoseg[jatekosValasz] == "kő" || lehetoseg[gepValasz] == "olló" && lehetoseg[jatekosValasz] == "papír")
            {
                Console.WriteLine("Gép nyert");
            }
            if (lehetoseg[gepValasz] == "kő" && lehetoseg[jatekosValasz] == "kő" || lehetoseg[gepValasz] == "papír" && lehetoseg[jatekosValasz] == "papír" || lehetoseg[gepValasz] == "olló" && lehetoseg[jatekosValasz] == "olló")
            {
                Console.WriteLine("x");
            }

            Console.ReadKey();
        }
    }
}
