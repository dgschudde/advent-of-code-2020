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

            ulong total = 0;

            foreach (var mathTask in input)
            {
                var currentTask = mathTask;
                ulong subTaskValue = 0;

                while (currentTask.Contains('+') || currentTask.Contains('*'))
                {
                    var subTask = SplitTask(currentTask);
                    subTaskValue = Calculate(subTask);
                    currentTask = currentTask.Replace(subTask, subTaskValue.ToString());
                }

                try
                {
                    checked
                    {
                        total += subTaskValue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
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

        private static ulong Calculate(string mathTask)
        {
            var strippedTask = mathTask.Replace("(", string.Empty);
            strippedTask = strippedTask.Replace(")", string.Empty);
            strippedTask = strippedTask.Replace(" ", string.Empty);

            var mathTaskArray = strippedTask.ToCharArray();

            ulong answer = 0;
            var operation = '\0';

            for (ulong current = 0; current < (ulong)mathTaskArray.Length; current++)
            {
                ulong nextNumber;
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

                if (current < (ulong)mathTaskArray.Length)
                {
                    operation = mathTaskArray[current];
                }
            }

            return answer;

            static ulong Floor(ulong nextNumber)
            {
                return (ulong)Math.Floor(Math.Log10(nextNumber) + 1);
            }
        }

        private static ulong NextNumber(ulong current, IReadOnlyList<char> mathTaskArray)
        {
            var s = string.Empty;

            for (ulong i = current; i < (ulong)mathTaskArray.Count; i++)
            {
                var chartToAdd = mathTaskArray[(int)i];
                if (char.IsDigit(chartToAdd))
                {
                    s += chartToAdd;
                }
                else
                {
                    break;
                }
            }

            return ulong.Parse(s);
        }
    }
}