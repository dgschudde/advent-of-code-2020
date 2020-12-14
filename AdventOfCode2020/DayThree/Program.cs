using Shared;
using System;
using System.Threading.Tasks;

namespace DayThree
{
    internal static class Program
    {
        private const string FilePath = @"input/day-three-minimum-test.txt";

        private static int _xCoords;
        private static int _yCoords;

        private static async Task Main()
        {
            IPuzzleInputReader puzzleInputReader = new PuzzleInputReader(FilePath);
            
            var input = await puzzleInputReader.ReadPuzzleInputAsync<string[]>();
            
            _xCoords = input[0].Length;
            _yCoords = input.Length;

            var convertedArray = ConvertTo2DArray(input);




            Console.ReadKey();
        }

        private static char[,] ConvertTo2DArray(string[] input)
        {
            char[,] result = new char[_yCoords, _xCoords];

            for (int currentRow = 0; currentRow < input.Length; currentRow++)
            {
                char[] rowValues = input[currentRow].ToCharArray();
                for (int currentPosition = 0; currentPosition < rowValues.Length; currentPosition++)
                {
                    result[currentRow, currentPosition] = rowValues[currentPosition];
                }
            }

            return result;
        }
    }
}