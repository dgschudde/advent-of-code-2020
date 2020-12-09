using Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DayTwo
{
    internal class Program
    {
        private const string FilePath = @"input/day-two.txt";

        public IPuzzleInputReader InputReader { get; }

        public Program(IPuzzleInputReader puzzleInputReader)
        {
            InputReader = puzzleInputReader;
        }

        private static async Task Main()
        {
            IPuzzleInputReader puzzleInputReader = new PuzzleInputReader(FilePath);
            var input = await puzzleInputReader.ReadPuzzleInputAsync<string[]>();

            var passwordPolicyParser = new PasswordPolicyParser(input);
            var parsedInput = passwordPolicyParser.ParseInput();

            int occurrences = parsedInput.Count(passwordPolicy => passwordPolicy.IsValid());

            Console.WriteLine($"{occurrences} password(s) are valid");
            Console.ReadKey();
        }
    }
}