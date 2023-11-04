using System;
using System.Collections.Generic;
using System.Linq;

namespace HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> namesKeysValues = new Dictionary<string, Dictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] elements = input
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = elements[0];

                string[] kvps = elements[1]
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                bool isNameAdded = namesKeysValues.ContainsKey(name);
                if (!isNameAdded)
                {
                    namesKeysValues.Add(name, new Dictionary<string, string>());
                }

                for (int i = 0; i < kvps.Length; i++)
                {
                    string[] currentElement = kvps[i]
                        .Split(":", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string key = currentElement[0];
                    string value = currentElement[1];

                    bool isKeyAdded = namesKeysValues[name].ContainsKey(key);
                    if (!isKeyAdded)
                    {
                        namesKeysValues[name].Add(key, string.Empty);
                    }

                    namesKeysValues[name][key] = value;
                }
            }

            string[] lastCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string searchedName = lastCommand[1];

            Dictionary<string, string> keysAndValues = namesKeysValues[searchedName]
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Info on {searchedName}:");

            int infoIndex = 0;

            foreach (var (key, value) in keysAndValues.OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{key}: {value}");
                infoIndex += key.Length + value.Length;
            }

            Console.WriteLine($"Info index: {infoIndex}");

            bool isSuccess = infoIndex >= targetInfoIndex;
            if (isSuccess)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                int neededInfo = targetInfoIndex - infoIndex;

                Console.WriteLine($"Need {neededInfo} more info.");
            }
        }
    }
}
