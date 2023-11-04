using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputLine = Console.ReadLine()
                .ToCharArray();

            Stack<char> symbols = new Stack<char>(inputLine);

            while (symbols.Any())
            {
                char currentSymbol = symbols.Pop();

                Console.Write(currentSymbol);
            }

            Console.WriteLine();
        }
    }
}
