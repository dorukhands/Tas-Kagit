using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tas_kagıt
{
    class Program
    {
        private static bool amp;

        static void Main(string[] args)
        {
            int nWin = 0, nLose = 0;

            Console.Title = "Taş Kağıt Makas";

            Console.WriteLine("\n\tBaşlamak için bir tuşa basın..");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Echo("\n\tTaş Kağıt Makas\n\t-----------------\n\n", ConsoleColor.Yellow);
                Echo("\t[1] ", ConsoleColor.White);
                Echo("Taş\n", ConsoleColor.Gray);
                Echo("\t[2] ", ConsoleColor.White);
                Echo("Kağıt\n", ConsoleColor.Gray);
                Echo("\t[3] ", ConsoleColor.White);
                Echo("Makas\n", ConsoleColor.Gray);

                string userSelection = "x";
                bool selection = false;

                while (!selection)
                {
                    userSelection = Console.ReadKey(true).KeyChar.ToString();
                    selection = ShowSelection(userSelection, "Kullanıcı");
                }

                string computerSelection = new Random().Next(1, 4).ToString();

                ShowSelection(computerSelection, "Bilgisayar");

                if (userSelection.Equals(computerSelection))
                    Echo(String.Format("\n\n\t{0} : {0} berabere.\n", GetElement(userSelection)), ConsoleColor.White);
                else if (userSelection == "1" && computerSelection == "2")
                { Echo("\n\n\tKağıt makası sarar: Bilgisayar kazandı.\n", ConsoleColor.Magenta); nLose++; }
                else if (userSelection == "1" && computerSelection == "3")
                { Echo("\n\n\tTaş makası kırar: Kullanıcı kazandı.\n", ConsoleColor.Green); nWin++; }
                else if (userSelection == "2" && computerSelection == "1")
                { Echo("\n\n\tKağıt makası sarar: Kullanıcı kazandı.\n", ConsoleColor.Green); nWin++; }
                else if (userSelection == "2" && computerSelection == "3")
                { Echo("\n\n\tMakas kağıdı keser: Bilgisayar kazandı.\n", ConsoleColor.Magenta); nLose++; }
                else if (userSelection == "3" && computerSelection == "1")
                { Echo("\n\n\tTaş makası kırar: Bilgisayar kazandı.\n", ConsoleColor.Magenta); nLose++; }
                else if (userSelection == "3" && computerSelection == "2")
                { Echo("\n\n\tMakas kağıdı keser: Kullanıcı kazandı.\n", ConsoleColor.Green); nWin++; }


                Echo(String.Format("\n\tKullanıcı:  {0} puan\n\tBilgisayar: {1} puan", nWin, nLose), ConsoleColor.White);
            }
        }

        static string GetElement(string selection)
        {
            switch (selection)
            {
                case "1": return "Taş";
                case "2": return "Kağıt";
                case "3": return "Makas";
                default: return String.Empty;
            }
        }

        static bool ShowSelection(string x, string user)
        {
            x = GetElement(x);
            if (x == String.Empty)
            {
                Echo("\n\tYanlış seçim! Tekrar deneyin..\n", ConsoleColor.Red);
                return false;
            }

            Echo(String.Format("\n\t{0}: {1}", user, x), ConsoleColor.Green);
            return true;
        }

        static void Echo(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
