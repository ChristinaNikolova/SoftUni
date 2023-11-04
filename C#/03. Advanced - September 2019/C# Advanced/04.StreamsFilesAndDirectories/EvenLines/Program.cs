using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"../../../text.txt";

            using (StreamReader streamReader = new StreamReader(textFilePath))
            {
                int counterLines = 0;

                while (!streamReader.EndOfStream)
                {
                    string currentLine = streamReader.ReadLine();

                    bool isEvenLine = counterLines % 2 == 0;
                    if (!isEvenLine)
                    {
                        counterLines++;
                        continue;
                    }

                    string[] wordsCurrentLine = currentLine
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    for (int i = 0; i < wordsCurrentLine.Length; i++)
                    {
                        wordsCurrentLine[i] = wordsCurrentLine[i].Replace("-", "@")
                            .Replace(",", "@")
                            .Replace(".", "@")
                            .Replace("!", "@")
                            .Replace("?", "@")
                            .ToString();
                    }

                    wordsCurrentLine = wordsCurrentLine
                        .Reverse()
                        .ToArray();

                    Console.WriteLine(string.Join(" ", wordsCurrentLine));

                    counterLines++;
                }
            }
        }
    }
}
