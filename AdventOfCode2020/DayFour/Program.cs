using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared;

namespace DayFour
{
    internal static class Program
    {
        private const string FilePath = @"input/day-four.txt";

        private static async Task Main()
        {
            IPuzzleInputReader puzzleInputReader = new PuzzleInputReader(FilePath);
            string[] input = await puzzleInputReader.ReadPuzzleInputAsync<string[]>();

            HashSet<Passport> convertedInput = ConvertInput(input);
            
            Console.WriteLine($"{convertedInput.Count} passports are valid");
            Console.ReadKey();
        }

        private static HashSet<Passport> ConvertInput(string[] input)
        {
            var passportEntries = new HashSet<Passport>();
            var currentEntryString = new StringBuilder();
            var validator = new PassportValidator();
            
            foreach (var entry in input)
            {
                currentEntryString.Append(entry);
                currentEntryString.Append(' ');

                if (entry.Trim().Equals(string.Empty) == false) continue;
                string[] splittedProperties = currentEntryString.ToString().Split(" ");

                var jsonStringBuilder = new StringBuilder();
                jsonStringBuilder.Append('{');

                foreach (var property in splittedProperties)
                {
                    if (property.Trim().Equals(string.Empty))
                        continue;

                    string[] values = property.Split(":");

                    jsonStringBuilder.Append($"'{values[0]}':'{values[1]}',");
                }

                jsonStringBuilder.Append('}');

                var currentPassportEntry = JsonConvert.DeserializeObject<Passport>(jsonStringBuilder.ToString());

                var validationResult = validator.Validate(currentPassportEntry);

                if (validationResult.IsValid)
                {
                    passportEntries.Add(currentPassportEntry);
                }
                
                currentEntryString.Clear();
            }

            return passportEntries;
        }
    }
}
