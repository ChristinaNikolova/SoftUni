using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"../../../text.txt";
            string outputFilePath = @"../../../output.txt";

            string[] lines = File.ReadAllLines(textFilePath);

            int counterLines = 1;
            StringBuilder finalOutput = new StringBuilder();

            foreach (string currentLine in lines)
            {
                int lettersCount = currentLine
                    .Where(x => char.IsLetter(x))
                    .Count();

                int punctuationsCount = currentLine
                    .Where(x => char.IsPunctuation(x))
                    .Count();

               finalOutput.AppendLine($"Line {counterLines}: {currentLine} ({lettersCount})({punctuationsCount})");

                counterLines++;
            }

            File.WriteAllText(outputFilePath, finalOutput.ToString());
        }
    }
}
