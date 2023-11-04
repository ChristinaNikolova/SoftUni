using System;
using System.Linq;

namespace Threeuple
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
            string town = string.Join(" ", firstLine.Skip(3));

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, address, town);

            string[] secondLine = Console.ReadLine()
                 .Split(" ")
                 .ToArray();

            string name = secondLine[0];
            int litersBeer = int.Parse(secondLine[1]);
            string drunkCondition = secondLine[2];

            bool isDrunk = drunkCondition == "drunk";

            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(name, litersBeer, isDrunk);

            string[] thirdLine = Console.ReadLine()
                 .Split(" ")
                 .ToArray();

            string nameThirdLine = thirdLine[0];
            double bankBalance = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];

            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(nameThirdLine, bankBalance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
