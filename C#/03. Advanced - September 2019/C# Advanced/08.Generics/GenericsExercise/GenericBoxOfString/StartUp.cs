using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentElement = Console.ReadLine();

                Box<string> box = new Box<string>(currentElement);

                Console.WriteLine(box);
            }
        }
    }
}
