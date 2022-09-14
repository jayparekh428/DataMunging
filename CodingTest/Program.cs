using CodingTest.Helpers;
using CodingTest.Models;

namespace CodingTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
            
        }

        /// <summary>
        /// This method will print Menu and accept a choice to execute menu option
        /// </summary>
        /// <returns></returns>
        public static bool MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t****************");
            Console.WriteLine("\t*              *");
            Console.WriteLine("\t*              *");
            Console.WriteLine("\t* 1. Weather   *");
            Console.WriteLine("\t* 2. Football  *");
            Console.WriteLine("\t*              *");
            Console.WriteLine("\t*              *");
            Console.WriteLine("\t****************");
            Console.WriteLine("\tPlease select option (1 or 2. Any other key to exit  : ");
            Console.ForegroundColor = ConsoleColor.White;
            switch (Console.ReadLine())
            {
                case "1":
                    ProcessWeatherData();
                    return true;
                case "2":
                    ProcessFootballData();
                    return true;                
                default:
                    return false;
            }
        }

        /// <summary>
        /// This method will read the Weather Data file and returns days with smallest spread
        /// </summary>
        public static void ProcessWeatherData()
        {
            try
            {
                string input = File.ReadAllText("Data/weather.dat");
                List<Row> rows = DataProcessHelper.ParseWeather(input);
                Row dayWithSmallestSpread = rows
                    .OrderBy(x => x.AbsDiff)
                    .First();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("#################################");
                Console.WriteLine($"Day: {dayWithSmallestSpread.Name}" +
                    $" min: {dayWithSmallestSpread.ValueB}" +
                    $" max: {dayWithSmallestSpread.ValueA}" +
                    $" spread: {dayWithSmallestSpread.AbsDiff}");
                Console.WriteLine("#################################");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch(Exception ex)
            {
                DataProcessHelper.LogError(ex);
            }
            
        }

        /// <summary>
        /// This method will read football data file and will return team with smalles spread of goals
        /// </summary>
        public static void ProcessFootballData()
        {
            try
            {
                string input = File.ReadAllText("Data/football.dat");

                var teamWithSmallestDiff = DataProcessHelper.ParseFootball(input)
                    .OrderBy(x => x.AbsDiff)
                    .First();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("#################################");
                Console.WriteLine($"Day: {teamWithSmallestDiff.Name}" +
                    $" goal against: {teamWithSmallestDiff.ValueA}" +
                    $" for: {teamWithSmallestDiff.ValueB}" +
                    $" diff: {teamWithSmallestDiff.AbsDiff}");
                Console.WriteLine("#################################");
                Console.ForegroundColor = ConsoleColor.White;
            }            
            catch (Exception ex)
            {
                DataProcessHelper.LogError(ex);
            }
            
        }


    }
}