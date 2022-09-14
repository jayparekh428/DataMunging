using CodingTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Helpers
{
    public static class DataProcessHelper
    {
        private static List<Row> GenericParse(string input, int skipBeginning, int skipEnd, 
                                                Models.Range name, Models.Range a, Models.Range b)
        {
            try
            {
                string[] split = input.Split("\n");
                var parsed = split
                    .Skip(skipBeginning)
                    .Take(split.Length - (skipBeginning + skipEnd))
                    .Where(row => !row.Contains("----"))
                    .Select(x =>
                    {
                        return new Row()
                        {
                            Name = x.Substring(name.From, name.Length).Trim(),
                            ValueA = int.Parse(x.Substring(a.From, a.Length)),
                            ValueB = int.Parse(x.Substring(b.From, b.Length))
                        };
                    })
                    .ToList();
                return parsed;
            }
            catch
            {
                throw;
            }                                    
        }

        public static List<Row> ParseWeather(string input)
        {
            return GenericParse(
                input: input,
                skipBeginning: 2, // skip header + empty row
                skipEnd: 2, // skip total row + empty line
                name: Models.Range.New(2, 2), // day name is a 2-digit number
                a: Models.Range.New(6, 2), // temp starts at character index 6 and is 2 digits
                b: Models.Range.New(12, 2)); // temp starts at character index 12 and is 2 digits
        }


        public static List<Row> ParseFootball(string input)
        {
            return GenericParse(input, 1, 1, Models.Range.New(7, 15), Models.Range.New(43, 2), Models.Range.New(50, 2));
        }

       
        public static void LogError(Exception ex)
        {
            Console.WriteLine($"Exception Occured. Error Message : {ex.Message}. Source: {ex.Source} Trace : {ex.StackTrace}");
        }
    }
}
