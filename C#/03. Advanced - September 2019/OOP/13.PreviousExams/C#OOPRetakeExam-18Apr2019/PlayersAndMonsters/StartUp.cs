namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ManagerController manager = new ManagerController();

            StringBuilder message = new StringBuilder();
            string result = string.Empty;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Report")
            {
                try
                {
                    string[] elements = input.Split();

                    string command = elements[0];

                    if (command == "AddPlayer")
                    {
                        string type = elements[1];
                        string username = elements[2];

                        result = manager.AddPlayer(type, username);
                    }
                    else if (command == "AddCard")
                    {
                        string type = elements[1];
                        string username = elements[2];

                        result = manager.AddCard(type, username);
                    }
                    if (command == "AddPlayerCard")
                    {
                        string username = elements[1];
                        string cardName = elements[2];

                        result = manager.AddPlayerCard(username, cardName);
                    }
                    if (command == "Fight")
                    {
                        string attacker = elements[1];
                        string defender = elements[2];

                        result = manager.Fight(attacker, defender);
                    }
                }
                catch (Exception ex)
                {
                    message.AppendLine(ex.Message);
                    continue;
                }

                message.AppendLine(result);
            }

            message.AppendLine(manager.Report());

            Console.WriteLine(message);
        }
    }
}