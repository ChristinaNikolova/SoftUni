using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> elements = new List<string>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentElement = Console.ReadLine();
                elements.Add(currentElement);
            }

            string elementToCompare = Console.ReadLine();

            Box<string> box = new Box<string>(elements);

            int result = box.GetTheCountOfTheGreatherElements(elementToCompare);

            Console.WriteLine(result);
        }
    }
}
