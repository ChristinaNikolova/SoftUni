using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;

            ListyIterator<string> listyIterator = null;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];

                if (command == "Create")
                {
                    string[] elementsToAdd = elements
                        .Skip(1)
                        .ToArray();

                    listyIterator = new ListyIterator<string>(elementsToAdd);
                }
                else if (command == "Move")
                {
                    bool result = listyIterator.Move();

                    Console.WriteLine(result);
                }
                else if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "HasNext")
                {
                    bool result = listyIterator.HasNext();

                    Console.WriteLine(result);
                }
                else if (command == "PrintAll")
                {
                    if (listyIterator.Any())
                    {
                        Console.WriteLine(string.Join(" ", listyIterator));
                    }
                }
            }
        }
    }
}
