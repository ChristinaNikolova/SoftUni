using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ")
                .ToArray();

            string[] websites = Console.ReadLine()
                .Split(" ")
                .ToArray();

            Smartphone smartphone = new Smartphone();

            CallCommand(phoneNumbers, smartphone);

            BrowseCommand(websites, smartphone);
        }

        private static void BrowseCommand(string[] websites, Smartphone smartphone)
        {
            foreach (string website in websites)
            {
                try
                {
                    string result = smartphone.Browse(website);

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void CallCommand(string[] phoneNumbers, Smartphone smartphone)
        {
            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    string result = smartphone.Call(phoneNumber);

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
