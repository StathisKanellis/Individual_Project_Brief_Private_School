using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class Exit
    {
        public static void CheckToExitProgram()
        {
            Console.WriteLine("Do you want to EXIT from PROGRAM: y/n? ");
            string user = Console.ReadLine();
            while (user != "y" && user != "n")
            {
                Console.WriteLine("Please insert correct value");
                Console.Write(" Select: (y/n) ");
                user = Console.ReadLine();
            }
            if (user == "n")
                FrontEnd.Start();
        }

        public static void CheckToExitFolderInput()
        {
            Console.WriteLine("Do you want to EXIT from Menu: y/n? ");
            string user = Console.ReadLine();
            while (user != "y" && user != "n")
            {
                Console.WriteLine("Please insert correct value");
                Console.Write(" Select: (y/n) ");
                user = Console.ReadLine();
            }
            if (user == "y")
            {
                FrontEnd.Start();
            }
            else
            {
                FrontEnd.InsertData();
            }
        }

        public static void CheckToExitFolderSyntetic()
        {
            Console.WriteLine("Do you want to EXIT from Menu: y/n? ");
            string user = Console.ReadLine();
            while (user != "y" && user != "n")
            {
                Console.WriteLine("Please insert correct value");
                Console.Write(" Select: (y/n) ");
                user = Console.ReadLine();
            }
            if (user == "y")
            {
                FrontEnd.Start();
            }
            else
            {
                FrontEnd.ExportData();
            }

        }
    }
}
