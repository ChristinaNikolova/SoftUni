using System;

namespace _04._GeneratingVectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] vector = new int[number];
            int index = 0;

            GenereateVector(index, vector);
        }

        private static void GenereateVector(int index, int[] vector)
        {
            if(index == vector.Length)
            {
                Console.WriteLine(string.Join(string.Empty, vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                GenereateVector(index + 1, vector);
            }
        }
    }
}
