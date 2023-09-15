using System.Text.RegularExpressions;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //en tom summa för att lagra siffror
            decimal sum = 0;
            // en sträng som heter newSymbols som innehåller siffror och bokstäver
            string newSymbols = "29535123p48723487597645723645";
            // Här går den igenom varje siffra från 0 till 9
            for (char number = '0'; number <= '9'; number++)
            {
                //detta mönster är till för att hitta siffror omgivna av andra siffror
                string pattern = $@"{number}(\d*?){number}";
                // här letar den efter något som förekommit i strängen
                MatchCollection matches = Regex.Matches(newSymbols, pattern);
                if (matches.Count > 0)
                    //går igenom varje match den hitta
                    foreach (Match match in matches)
                    {
                        //hämtar matchningen som en sträng
                        string matchSimular = match.Value;
                        //konverterar matchningen till en decimal och lägger till det i summan
                        decimal sameNumber;
                        if (decimal.TryParse(matchSimular, out sameNumber))
                        {
                            sum += sameNumber;
                        }
                        //här delar den upp före och efter strängen
                        string beforeMatch = newSymbols.Substring(0, match.Index);
                        string afterMatch = newSymbols.Substring(match.Index + match.Length);


                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(beforeMatch);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(match.Value);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(afterMatch);

                    }

            }
            Console.WriteLine(" The total is: " + sum);

            
        }
    }
}