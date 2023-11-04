using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;
    using MXGP.Models;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder();

            string result = string.Empty;
            ChampionshipController championshipController = new ChampionshipController();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] elements = input
                    .Split(" ")
                    .ToArray();

                    string command = elements[0];

                    if (command == "CreateRider")
                    {
                        string name = elements[1];
                        result = championshipController.CreateRider(name);
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        string type = elements[1];
                        string model = elements[2];
                        int horsePower = int.Parse(elements[3]);

                        result = championshipController.CreateMotorcycle(type, model, horsePower);
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        string nameRider = elements[1];
                        string nameMotor = elements[2];

                        result = championshipController.AddMotorcycleToRider(nameRider, nameMotor);
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string nameRace = elements[1];
                        string nameRide = elements[2];

                        result = championshipController.AddRiderToRace(nameRace, nameRide);
                    }
                    else if (command == "CreateRace")
                    {
                        string name = elements[1];
                        int labs = int.Parse(elements[2]);

                        result = championshipController.CreateRace(name, labs);
                    }
                    else if (command == "StartRace")
                    {
                        string name = elements[1];
                        result = championshipController.StartRace(name);
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                message.AppendLine(result);
            }

            Console.WriteLine(message);
        }
    }
}
