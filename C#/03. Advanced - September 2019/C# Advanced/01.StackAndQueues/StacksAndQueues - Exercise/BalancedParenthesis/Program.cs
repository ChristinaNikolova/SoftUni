using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> symbols = new Stack<char>();

            string lineInput = Console.ReadLine();

            bool isBalanced = true;

            bool isEvenLenght = lineInput.Length % 2 == 0;
            if (!isEvenLenght)
            {
                isBalanced = false;
            }
            else
            {
                for (int i = 0; i < lineInput.Length; i++)
                {
                    char currentSymbol = lineInput[i];

                    if (currentSymbol == '(' || currentSymbol == '[' || currentSymbol == '{')
                    {
                        symbols.Push(currentSymbol);
                    }
                    else if (currentSymbol == ')' || currentSymbol == ']' || currentSymbol == '}')
                    {
                        bool isEmpty = symbols.Count == 0;
                        if (isEmpty)
                        {
                            isBalanced = false;
                            break;
                        }

                        char openSymbol = symbols.Pop();

                        bool isValid = currentSymbol == ')' && openSymbol == '('
                            || currentSymbol == ']' && openSymbol == '['
                            || currentSymbol == '}' && openSymbol == '{';

                        if (!isValid)
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
            }

            bool isSuccess = isBalanced && symbols.Count == 0;
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
