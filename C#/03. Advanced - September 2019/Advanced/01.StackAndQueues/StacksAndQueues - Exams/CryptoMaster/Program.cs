using System;
using System.Linq;

namespace CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxSequence = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    int currentIndex = index;
                    int nextIndex = (currentIndex + step) % numbers.Length;

                    int counterSequences = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        counterSequences++;

                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % numbers.Length;
                    }

                    bool isMaxSequence = counterSequences > maxSequence;
                    if (isMaxSequence)
                    {
                        maxSequence = counterSequences;
                    }
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}
