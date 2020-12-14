using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace DayFourteen
{
    internal static class Program
    {
        private const string FilePath = @"input/day-fourteen.txt";

        private static async Task Main()
        {
            IPuzzleInputReader puzzleInputReader = new PuzzleInputReader(FilePath);
            
            string[] input = await puzzleInputReader.ReadPuzzleInputAsync<string[]>();
            
            IEnumerable<FerryProgram> convertedInput = ConvertInput(input);
            
            var results = new Dictionary<long, long>();

            foreach (var ferryProgram in convertedInput)
            {
                foreach (var programItem in ferryProgram.ProgramItem)
                {
                    
                    char[] result = Convert.ToString(programItem.Value, 2).PadLeft(36, '0').ToCharArray();
                    var position = 0;
                    
                   

                    foreach (var maskCharacter in ferryProgram.Mask)
                    {
                        switch (maskCharacter)
                        {
                            case 'X':
                                break;
                            case '0':
                                result[position] = '0';
                                break;
                            case '1':
                                result[position] = '1';
                                break;
                        }
                        position++;
                    }

                    if (results.ContainsKey(programItem.Address) )
                    {
                        results.Remove(programItem.Address);
                    }
                    results.Add(programItem.Address, Convert.ToInt64(result.ToBinaryString(), 2));
                }
            }

            long totalValue = 0;
            totalValue = results.Values.Aggregate(totalValue, (current, value) => current + value);
            Console.WriteLine($"Total value: {totalValue}");

            Console.ReadKey();
        }

        private static IEnumerable<FerryProgram> ConvertInput(string[] input)
        {
            var ferryPrograms = new List<FerryProgram>();

            for (var count = 0; count < input.Length - 1;)
            {
                var currentLine = input[count];
                
                if (!currentLine.StartsWith("mask")) continue;
                
                var ferryProgram = new FerryProgram
                {
                    Mask = currentLine.Replace("mask =", string.Empty).Trim(), ProgramItem = new List<FerryProgramItem>()
                };
                
                currentLine = input[++count];

                while (currentLine != null && currentLine.StartsWith("mem"))
                {
                    var address = currentLine.Substring(currentLine.IndexOf("[", StringComparison.Ordinal) + 1,
                        (currentLine.IndexOf("]", StringComparison.Ordinal) - 1 -
                         currentLine.IndexOf("[", StringComparison.Ordinal)));

                    var value = currentLine.Substring(currentLine.IndexOf("=", StringComparison.Ordinal) + 1,
                        currentLine.Length - 1 - currentLine.IndexOf("=", StringComparison.Ordinal));

                    var ferryProgramItem = new FerryProgramItem
                    {
                        Address = long.Parse(address),
                        Value = long.Parse(value)
                    };
                    ferryProgram.ProgramItem.Add(ferryProgramItem);

                    if (count < input.Length - 1)
                    {
                        currentLine = input[++count];
                    }
                    else
                    {
                        break;
                    }
                } 

                ferryPrograms.Add(ferryProgram);
            }

            return ferryPrograms;
        }

    }
}