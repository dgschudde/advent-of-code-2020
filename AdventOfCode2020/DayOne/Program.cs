using Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DayOne
{
    internal class Program
    {
        private const string FilePath = @"input/day-one.txt";

        public IPuzzleInputReader InputReader { get; }

        public Program(IPuzzleInputReader puzzleInputReader)
        {
            InputReader = puzzleInputReader;
        }

        private static async Task Main()
        {
            IPuzzleInputReader puzzleInputReader = new PuzzleInputReader(FilePath);
            var input = await puzzleInputReader.ReadPuzzleInputAsync<int[]>();

            var middle = input.Max() / 2 + 1;

            var lowerNumbers = input.Where(results => results < middle);
            var higherNumbers = input.Where(results => results >= middle);

            int highResult = 0;
            int lowResult = 0;

            var highNumbers = higherNumbers as int[] ?? higherNumbers.ToArray();
            foreach (var lowNumber in lowerNumbers)
            {
                if (highResult > 0 && lowResult > 0)
                {
                    break;
                }

                foreach (var highNumber in highNumbers)
                {
                    if (lowNumber + highNumber != 2020) continue;
                    highResult = highNumber;
                    lowResult = lowNumber;
                    break;
                }
            }

            int answer = lowResult * highResult;

            Console.WriteLine($"Answer: {lowResult} * {highResult} = {answer}");
            Console.ReadKey();
        }
    }
}