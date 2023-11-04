using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> indexes = new Stack<int>();

            string expression = Console.ReadLine();

            for (int i = 0; i < expression.Length; i++)
            {
                char currentSymbol = expression[i];

                if (currentSymbol == '(')
                {
                    indexes.Push(i);
                }
                else if (currentSymbol == ')')
                {
                    int openBracketIndex = indexes.Pop();

                    string expressionToPrint = expression.Substring(openBracketIndex, i - openBracketIndex + 1);

                    Console.WriteLine(expressionToPrint);
                }
            }
        }
    }
}
