using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] elementsToAdd = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> firstIndexes = new List<int>();
            List<int> secondIndexes = new List<int>();
            List<int> thirdIndexes = new List<int>();

            foreach (string  element in elementsToAdd)
            {
                int first = addCollection.AddElement(element);
                firstIndexes.Add(first);

                int second = addRemoveCollection.AddElement(element);
                secondIndexes.Add(second);

                int third = myList.AddElement(element);
                thirdIndexes.Add(third);
            }

            Console.WriteLine(string.Join(" ", firstIndexes));
            Console.WriteLine(string.Join(" ", secondIndexes));
            Console.WriteLine(string.Join(" ", thirdIndexes));

            List<string> secondElements = new List<string>();
            List<string> thirdElements = new List<string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string secondElement = addRemoveCollection.RemoveElement();
                secondElements.Add(secondElement);

                string thirdElement = myList.RemoveElement();
                thirdElements.Add(thirdElement);
            }

            Console.WriteLine(string.Join(" ", secondElements));
            Console.WriteLine(string.Join(" ", thirdElements));
        }
    }
}
