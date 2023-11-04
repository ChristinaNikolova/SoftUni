using System;

namespace _02._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            long factoriel = Factoriel(number);

            Console.WriteLine(factoriel);
        }

        private static long Factoriel(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * Factoriel(number - 1);
        }
    }
}
