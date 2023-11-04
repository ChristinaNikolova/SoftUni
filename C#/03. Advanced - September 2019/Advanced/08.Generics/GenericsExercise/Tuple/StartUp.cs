using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                 .Split(" ")
                 .ToArray();

            string firstName = firstLine[0];
            string secondName = firstLine[1];

            string fullName = firstName + " " + secondName;
            string address = firstLine[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, address);

            string[] secondLine = Console.ReadLine()
                 .Split(" ")
                 .ToArray();

            string name = secondLine[0];
            int litersBeer = int.Parse(secondLine[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(name, litersBeer);

            string[] thirdLine = Console.ReadLine()
                 .Split(" ")
                 .ToArray();

            int intNumber = int.Parse(thirdLine[0]);
            double doubleNumber = double.Parse(thirdLine[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNumber, doubleNumber);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
