using System;

namespace _07._N_Choose_K_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int count = Solve(n, k);

            Console.WriteLine(count);
        }

        private static int Solve(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == n || k == 0)
            {
                return 1;
            }

            return Solve(n - 1, k - 1) + Solve(n - 1, k);
        }
    }
}
