using Shared;
using System;
using System.Threading.Tasks;

namespace DayThree
{
    internal class Program
    {
        private const string FilePath = @"input/day-three-minumumtest.txt";

        public IPuzzleInputReader InputReader { get; }

        public Program(IPuzzleInputReader puzzleInputReader)
        {
            InputReader = puzzleInputReader;
        }

        private static async Task Main()
        {
            IPuzzleInputReader puzzleInputReader = new PuzzleInputReader(FilePath);
            var input = await puzzleInputReader.ReadPuzzleInputAsync<string[]>();
            var result = ConvertTo2DArray(input);

            Console.ReadKey();
        }

        private static char[,] ConvertTo2DArray(string[] input)
        {
            int width = input[0].Length;
            int height = input.Length;

            char[,] result = new char[width, height];

            for (int currentRow = 0; currentRow < input.Length; currentRow++)
            {
                char[] rowValues = input[currentRow].ToCharArray();
                for (int currentPosition = 0; currentPosition < rowValues.Length; currentPosition++)
                {
                    result[currentPosition, currentRow] = rowValues[currentPosition];
                }
            }

            return result;
        }
    }
}