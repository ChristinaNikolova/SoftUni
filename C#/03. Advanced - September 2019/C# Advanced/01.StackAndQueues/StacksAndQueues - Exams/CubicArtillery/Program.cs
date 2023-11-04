using System;
using System.Collections.Generic;
using System.Linq;

namespace CubicArtillery
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> bunkers = new Queue<string>();
            Queue<int> weaponsCurrentBunker = new Queue<int>();

            int maxCapacityBunker = int.Parse(Console.ReadLine());
            string input = string.Empty;

            int leftCapacity = maxCapacityBunker;

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                string[] elementsCurrentLine = input
                    .Split(' ')
                    .ToArray();

                foreach (string element in elementsCurrentLine)
                {
                    bool isNumber = char.IsDigit(element[0]);
                    if (!isNumber)
                    {
                        bunkers.Enqueue(element);
                    }
                    else
                    {
                        bool isPlaceFound = false;

                        int currentWeapon = int.Parse(element);

                        while (bunkers.Count > 1)
                        {
                            bool isCapacityEnough = currentWeapon <= leftCapacity;
                            if (isCapacityEnough)
                            {
                                leftCapacity -= currentWeapon;
                                weaponsCurrentBunker.Enqueue(currentWeapon);
                                isPlaceFound = true;
                                break;
                            }
                            else
                            {
                                string currentBunker = bunkers.Dequeue();
                                leftCapacity = maxCapacityBunker;

                                bool isEmpty = weaponsCurrentBunker.Count == 0;
                                if (isEmpty)
                                {
                                    Console.WriteLine($"{currentBunker} -> Empty");
                                }
                                else
                                {
                                    Console.WriteLine($"{currentBunker} -> {string.Join(", ", weaponsCurrentBunker)}");
                                    weaponsCurrentBunker.Clear();
                                }
                            }
                        }

                        if (!isPlaceFound)
                        {
                            bool isActuallCapacityEnough = maxCapacityBunker >= currentWeapon;
                            if (isActuallCapacityEnough)
                            {
                                while (leftCapacity < currentWeapon)
                                {
                                    leftCapacity += weaponsCurrentBunker.Dequeue();
                                }

                                leftCapacity -= currentWeapon;
                                weaponsCurrentBunker.Enqueue(currentWeapon);
                            }
                        }
                    }
                }
            }
        }
    }
}
