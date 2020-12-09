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

        public async Task<int[]> ReadPuzzleInputAsync()
        {
            if (IsFilePathValid() == false)
            {
                Console.WriteLine("Provided filepath is invalid.");
            }

            try
            {
                using StreamReader reader = File.OpenText(_filePath);
                string input = await reader.ReadToEndAsync();
                string[] splittedResult = input.Split(Environment.NewLine);

                return Array.ConvertAll(splittedResult, int.Parse);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Something went wrong while reading the input file: {ex.Message}");
                throw;
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