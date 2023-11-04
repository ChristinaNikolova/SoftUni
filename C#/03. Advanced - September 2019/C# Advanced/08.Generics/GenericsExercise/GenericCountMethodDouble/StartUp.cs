using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<double> numbers = new List<double>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());
                numbers.Add(currentNumber);
            }

            double numberToCompare = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            int result = box.GetTheCountOfTheGreatherElements(numbers, numberToCompare);

            Console.WriteLine(result);
        }
    }
}
