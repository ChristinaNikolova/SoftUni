using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggersAndFans = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> vloggersAndSubs = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string vloggername = elements[0];

                if (elements.Length == 4)
                {
                    bool isAdded = vloggersAndFans.ContainsKey(vloggername);
                    if (!isAdded)
                    {
                        vloggersAndFans.Add(vloggername, new List<string>());
                        vloggersAndSubs.Add(vloggername, new List<string>());
                    }
                }
                else if (elements.Length == 3)
                {
                    string fan = elements[0];
                    string vloggerToFollow = elements[2];

                    bool areAdded = vloggersAndFans.ContainsKey(fan) && vloggersAndFans.ContainsKey(vloggerToFollow);
                    bool areSame = fan == vloggerToFollow;

                    if (!areAdded || areSame)
                    {
                        continue;
                    }

                    bool isAlreadyFollowed = vloggersAndFans[vloggerToFollow].Contains(fan);
                    if (isAlreadyFollowed)
                    {
                        continue;
                    }

                    vloggersAndFans[vloggerToFollow].Add(fan);
                    vloggersAndSubs[fan].Add(vloggerToFollow);
                }
            }

            int totalUsers = vloggersAndSubs.Count;

            Console.WriteLine($"The V-Logger has a total of {totalUsers} vloggers in its logs.");

            Dictionary<string, List<string>> sortedVloggersAndFans = vloggersAndFans
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => vloggersAndSubs[x.Key].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int counter = 1;

            foreach (var (vlogger, fans) in sortedVloggersAndFans)
            {
                List<string> subs = vloggersAndSubs[vlogger];

                Console.WriteLine($"{counter}. {vlogger} : {fans.Count} followers, {subs.Count} following");


                if (counter == 1)
                {
                    bool areAny = fans.Any();
                    if (areAny)
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, fans.OrderBy(x => x)
                            .Select(x => $"*  {x}")));
                    }
                }

                counter++;
            }
        }
    }
}
