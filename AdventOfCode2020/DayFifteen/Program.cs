using System;
using System.Collections.Generic;
using System.Linq;

namespace DayFifteen
{
    internal static class Program
    {
        private static void Main()
        {
            long spokenWord = 0;
            long turn = 0;
            long count = 0;
            
            var spokenWords = new Word[2020];

            var input = new[] {0, 3, 6};
            
            foreach (var word in input)
            {
                turn++;
                count++;
                spokenWord = word;
                var wordToSpeak = new Word
                {
                    Value = word,
                    SpokenInTurns = new List<long>() { turn }
                };

                spokenWords[count - 1] = wordToSpeak;
            }
            
            do
            {
                turn++;
                count++;
                var previousSpokenWord = spokenWords[turn - 2];

                if (previousSpokenWord.SpokenInTurns.Count > 1)
                {
                    int spokenTurnCount = previousSpokenWord.SpokenInTurns.Count;
                    long lastSpokenInTurn = previousSpokenWord.SpokenInTurns[spokenTurnCount - 1];
                    long secondLastSpokenInTurn = previousSpokenWord.SpokenInTurns[spokenTurnCount - 2];

                    var wordToSpeak = new Word()
                    {
                        Value = lastSpokenInTurn - secondLastSpokenInTurn,
                        SpokenInTurns = new List<long>() {turn}
                    };

                    if (spokenWords.Any(x => x.Value == wordToSpeak.Value))
                    {
                        var wordToAdd = spokenWords.First(x => x.Value == wordToSpeak.Value);
                        spokenWords[turn - 1] = wordToSpeak;
                    }
                    else
                    {
                        spokenWords[turn - 1] = wordToSpeak;
                    }
                }
                else
                {
                    spokenWords[count - 1] = spokenWords[0];
                    spokenWords[count - 1].SpokenInTurns.Add(turn);
                    count = 0;
                }
            } while (turn != 2019);

            
            Console.ReadKey();
        }
    }
}