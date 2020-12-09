using System;
using System.IO;
using System.Threading.Tasks;

namespace Shared
{
    public sealed class PuzzleInputReader : IPuzzleInputReader
    {
        private readonly string _filePath;

        public PuzzleInputReader(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<T> ReadPuzzleInputAsync<T>()
        {
            string[] splittedResult;

            if (IsFilePathValid() == false)
            {
                Console.WriteLine("Provided filepath is invalid.");
                return default;
            }

            try
            {
                using StreamReader reader = File.OpenText(_filePath);
                string input = await reader.ReadToEndAsync();
                splittedResult = input.Split(Environment.NewLine);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Something went wrong while reading the input file: {ex.Message}");
                throw;
            }

            if (typeof(T) == typeof(int[]))
            {
                return (T)Convert.ChangeType(ReadPuzzleInputAsync(splittedResult), typeof(int[]));
            }

            if (typeof(T) == typeof(string[]))
            {
                return (T)Convert.ChangeType(splittedResult, typeof(string[]));
            }
            return default;
        }

        private static int[] ReadPuzzleInputAsync(string[] splittedResults)
        {
            if (splittedResults == null)
            {
                Console.WriteLine("No results to concert available.");
                return default;
            }

            try
            {
                return Array.ConvertAll(splittedResults, int.Parse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while processing the input file: {ex.Message}");
                throw;
            }
        }

        private bool IsFilePathValid()
        {
            try
            {
                Path.Combine(_filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}