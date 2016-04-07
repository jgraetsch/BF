using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF
{
    class Program
    {
        // wahrscheinlichen Zeichensatz definieren
        static char[] Match =
        {
                '0','1','2','3','4','5','6','7','8','9',
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                ',',';','.',':','+','*','#','='
            };

        // unser Passwort
        static string FindPassword;
        static int Combi;
        static string space;

        static void Main(string[] args)
        {
            space = " ";
            int Count;
            Console.WriteLine("Willkommen bei unserem Brute Force Test.");
            Console.WriteLine(space);
            Console.Write("Geben Sie das Test-Passwort ein: ");

            // Init Passwort
            FindPassword = (Console.ReadLine());

            // Uhrzeit setzen
            DateTime today = DateTime.Now;
            today.ToString("dd.mm.yyyy HH:mm:ss");
            Console.WriteLine(space);
            Console.WriteLine("START:\t{0}",today);

            for (Count=0;Count<=15;Count++)
            {
                Recurse(Count, 0, "");
            }
        }

        static void Recurse (int Length, int Position, string BaseString)
        {
            int Count = 0;
            for (Count = 0; Count < Match.Length; Count++)
            {
                Combi++;
                if (Position<Length -1)
                {
                    Recurse(Length, Position + 1, BaseString + Match[Count]);
                }
                if (BaseString + Match[Count]==FindPassword)
                {
                    DateTime today = DateTime.Now;
                    today.ToString("dd.mm.yyyy HH:mm:ss");
                    Console.WriteLine(space);
                    Console.WriteLine("END:\t{0}\nCombi:\t{1}",today,Combi);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }
    }
}
