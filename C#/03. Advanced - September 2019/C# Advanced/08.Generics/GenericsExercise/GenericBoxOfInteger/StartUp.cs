using System;

namespace GenericBoxOfInteger
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(currentNumber);

                Console.WriteLine(box);
            }
        }
    }
}
