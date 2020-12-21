using Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DayEighteen
{
    internal class Program
    {
        private const string FilePath = @"input/day-eighteen.txt";

        private static async Task Main()
        {
            IPuzzleInputReader puzzleInputReader = new PuzzleInputReader(FilePath);
            string[] input = await puzzleInputReader.ReadPuzzleInputAsync<string[]>();
            Int64 total = 0;

            foreach (var mathTask in input)
            {
                string currentTask = mathTask;
                int answer;
                do
                {
                    var subTask = SplitTask(currentTask);
                    answer = Calculate(subTask);
                    currentTask = currentTask.Replace(subTask, answer.ToString());
                } while (currentTask.Contains('+') || currentTask.Contains('*'));

                total += answer;
            }
            Console.WriteLine("Answer: " + total);
        }

        private static string SplitTask(string mathTask)
        {
            int startIndex = mathTask.LastIndexOf('(');

            if (startIndex == -1)
                return mathTask;

            int endIndex = mathTask.IndexOf(')', startIndex);
            return mathTask.Substring(startIndex, endIndex - startIndex + 1);
        }

        private static int Calculate(string mathTask)
        {
            var strippedTask = mathTask.Replace("(", string.Empty);
            strippedTask = strippedTask.Replace(")", string.Empty);
            strippedTask = strippedTask.Replace(" ", string.Empty);

            var mathTaskArray = strippedTask.ToCharArray();

            var answer = 0;
            var operation = '\0';

            for (var current = 0; current < mathTaskArray.Length; current++)
            {
                int nextNumber;
                switch (operation)
                {
                    case '+':
                        nextNumber = NextNumber(current, mathTaskArray);
                        answer += nextNumber;
                        current += Floor(nextNumber);
                        break;

                    case '*':
                        nextNumber = NextNumber(current, mathTaskArray);
                        answer *= nextNumber;
                        current += Floor(nextNumber);
                        break;

                    default:
                        var currentNumber = NextNumber(current, mathTaskArray);
                        answer = currentNumber;
                        current += Floor(currentNumber);
                        break;
                }

                if (current < mathTaskArray.Length)
                {
                    operation = mathTaskArray[current];
                }
            }

            return answer;

            static int Floor(int nextNumber)
            {
                return (int)Math.Floor(Math.Log10(nextNumber) + 1);
            }
        }

        private static int NextNumber(int current, IReadOnlyList<char> mathTaskArray)
        {
            var s = string.Empty;

            for (var i = current; i < mathTaskArray.Count; i++)
            {
                var chartToAdd = mathTaskArray[i];
                if (char.IsDigit(chartToAdd))
                {
                    s += chartToAdd;
                }
                else
                {
                    break;
                }
            }

            return int.Parse(s);
        }
    }
}