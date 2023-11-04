using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> versions = new Stack<string>();

            StringBuilder text = new StringBuilder();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int commandNumber = int.Parse(elements[0]);

                if (commandNumber == 1)
                {
                    versions.Push(text.ToString());

                    string textToAdd = elements[1];
                    text.Append(textToAdd);
                }
                else if (commandNumber == 2)
                {
                    versions.Push(text.ToString());

                    int countToRemove = int.Parse(elements[1]);

                    int count = Math.Min(countToRemove, text.Length);

                    for (int j = 0; j < count; j++)
                    {
                        text.Length--;
                    }
                }
                else if (commandNumber == 3)
                {
                    int index = int.Parse(elements[1]) - 1;

                    bool isIndexValid = index >= 0 && index <= text.Length - 1;
                    if (isIndexValid)
                    {
                        char symbolToPrint = text[index];

                        Console.WriteLine(symbolToPrint);
                    }
                }
                else if (commandNumber == 4)
                {
                    string previousVersion = versions.Pop();
                    text.Clear();
                    text.Append(previousVersion);
                }
            }
        }
    }
}
