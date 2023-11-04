using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"../../../text.txt";
            string wordsFilePath = @"../../../words.txt";

            string[] words = File.ReadAllLines(wordsFilePath);
            string[] lines = File.ReadAllLines(textFilePath);

            Dictionary<string, int> wordsAndCounts = new Dictionary<string, int>();

            foreach (string currentWord in words)
            {
                string lowerCaseWord = currentWord.ToLower();

                bool isAdded = wordsAndCounts.ContainsKey(lowerCaseWord);
                if (!isAdded)
                {
                    wordsAndCounts.Add(lowerCaseWord, 0);
                }
            }

            for (int i = 0; i < lines.Length; i++)
            {
                string[] currentLine = lines[i]
                    .ToLower()
                    .Split(new char[] { ' ', '-', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (string currentWord in currentLine)
                {
                    bool isInDictionary = wordsAndCounts.ContainsKey(currentWord);
                    if (isInDictionary)
                    {
                        wordsAndCounts[currentWord]++;
                    }
                }
            }

            string actualResultPath = @"../../../actualResult.txt";

            StringBuilder actualResult = new StringBuilder();

            foreach (var (word, count) in wordsAndCounts)
            {
                actualResult.AppendLine($"{word} - {count}");
            }

            File.WriteAllText(actualResultPath, actualResult.ToString());

            string expectedResultPath = @"../../../expectedResult.txt";

            Dictionary<string, int> sortedWordsAndCounts = wordsAndCounts
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            StringBuilder expectedResult = new StringBuilder();

            foreach (var (word, count) in sortedWordsAndCounts)
            {
                expectedResult.AppendLine($"{word} - {count}");
            }

            File.WriteAllText(expectedResultPath, expectedResult.ToString());

        }
    }
}
