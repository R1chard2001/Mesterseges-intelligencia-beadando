using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LabdaLabirintus
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2.15 feladat
            Palya.PalyaLegeneralasa();
            Backtrack bt = new Backtrack();
            List<Allapot> ut = bt.Keres(20);
            if (ut.Count > 0)
            {
                bool exit = false;
                int index = 0;
                Console.CursorVisible = false;
                while (!exit)
                {
                    Console.WriteLine("ESC: Kilépés, balra nyíl: előző állapot, jobbra nyíl következő állapot");
                    Console.WriteLine("Lépés sorszáma: {0} ", index + 1);
                    Console.WriteLine(ut[index]);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (index > 0)
                                index--;
                            Console.SetCursorPosition(0, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            if (index < ut.Count - 1)
                                index++;
                            Console.SetCursorPosition(0, 0);
                            break;
                        default:
                            Console.SetCursorPosition(0, 0);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Nincs megoldás a megadott mélységen.");
                Console.ReadKey();
            }
        }
        
    }
}
