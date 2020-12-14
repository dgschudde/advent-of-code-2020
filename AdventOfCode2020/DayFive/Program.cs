using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace DayFive
{
    internal static class Program
    {
        private const string FilePath = @"input/day-five.txt";

        private static async Task Main()
        {
            IPuzzleInputReader puzzleInputReader = new PuzzleInputReader(FilePath);
            string[] input = await puzzleInputReader.ReadPuzzleInputAsync<string[]>();
            
            var seatIds = new List<int>();

            foreach (var entry in input)
            {
                string row = entry.Substring(0, 7);
                
                row = row.Replace("F", "0");
                row = row.Replace("B", "1");
                
                string column = entry.Substring(7, 3);

                column = column.Replace("L", "0");
                column = column.Replace("R", "1");
                
                // Convert binary value to int
                var columnValue = Convert.ToInt32(column, 2);
                var rowValue = Convert.ToInt32(row, 2);
                var seatId = (rowValue * 8) + columnValue;
                seatIds.Add(seatId);
            }

            seatIds.Sort();

            var currentSeatId = 0;

            for (var i = 0; i < seatIds.Count - 1; i++)
            {
                currentSeatId = seatIds[i];
                var nextSeatId = seatIds[i + 1];
                if (nextSeatId - currentSeatId > 1)
                {
                    break;
                }
            }
            
            var maxSeatId = seatIds.Max(x => x);
            Console.WriteLine($"Highest seat ID on a boarding pass is: {maxSeatId}");
            Console.WriteLine($"My seatId is: {currentSeatId + 1}");
            Console.ReadKey();
        }
    }
}