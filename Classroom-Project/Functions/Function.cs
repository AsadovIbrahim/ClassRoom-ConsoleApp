using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom_Project.Functions
{
    public static class Function
    {

        public static void Logo()
        {

            
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(@"
                                       _________      .__                  .__   
                                      /   _____/ ____ |  |__   ____   ____ |  |  
                                      \_____  \_/ ___\|  |  \ /  _ \ /  _ \|  |  
                                      /        \  \___|   Y  (  <_> |  <_> )  |__
                                     /_______  /\___  >___|  /\____/ \____/|____/
                                             \/     \/     \/                    ");


            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void SetConsoleColor(string option)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(option);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void PressAnyKey()
        {
            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }

    }

}
