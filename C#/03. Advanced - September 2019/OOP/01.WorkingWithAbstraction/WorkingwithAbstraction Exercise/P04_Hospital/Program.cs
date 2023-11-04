using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            const int maxRooms = 20;
            const int maxBeds = 60;

            Dictionary<string, List<string>> doctorsAndPatients = new Dictionary<string, List<string>>();

            Dictionary<string, List<List<string>>> departmentsAndPatients = new Dictionary<string, List<List<string>>>();

            string input = Console.ReadLine();

            while (input != "Output")
            {
                string[] elements = input
                    .Split()
                    .ToArray();

                string departament = elements[0];
                string firstNameDoctor = elements[1];
                string secondNameDoctor = elements[2];
                string pacient = elements[3];

                string doctorName = firstNameDoctor + " " + secondNameDoctor;

                if (!doctorsAndPatients.ContainsKey(doctorName))
                {
                    doctorsAndPatients[doctorName] = new List<string>();
                }

                if (!departmentsAndPatients.ContainsKey(departament))
                {
                    departmentsAndPatients[departament] = new List<List<string>>();

                    for (int currentRoom = 0; currentRoom < maxRooms; currentRoom++)
                    {
                        departmentsAndPatients[departament].Add(new List<string>());
                    }
                }

                bool isFreeSpace = departmentsAndPatients[departament]
                    .SelectMany(x => x)
                    .Count() < maxBeds;

                if (isFreeSpace)
                {
                    int currentRoom = 0;

                    doctorsAndPatients[doctorName].Add(pacient);

                    for (int room = 0; room < departmentsAndPatients[departament].Count; room++)
                    {
                        if (departmentsAndPatients[departament][room].Count < 3)
                        {
                            currentRoom = room;
                            break;
                        }
                    }

                    departmentsAndPatients[departament][currentRoom].Add(pacient);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] args = input
                    .Split(" ")
                    .ToArray();

                if (args.Length == 1)
                {
                    GetThePatientsOfTheTargetDepartment(departmentsAndPatients, args);
                }
                else if (args.Length == 2)
                {
                    if (int.TryParse(args[1], out int targetRoom))
                    {
                        GetThePatientsOfTheTargetRoom(departmentsAndPatients, args, targetRoom);
                    }
                    else
                    {
                        GetThePatientsOfTheDoctor(doctorsAndPatients, args);
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static void GetThePatientsOfTheTargetDepartment(Dictionary<string, List<List<string>>> departmentsAndPatients, string[] args)
        {
            string targetDepartment = args[0];

            Console.WriteLine(string.Join("\n", departmentsAndPatients[targetDepartment]
                .Where(x => x.Count > 0)
                .SelectMany(x => x)));
        }

        private static void GetThePatientsOfTheTargetRoom(Dictionary<string, List<List<string>>> departmentsAndPatients, string[] args, int targetRoom)
        {
            string targetDepartment = args[0];

            Console.WriteLine(string.Join("\n", departmentsAndPatients[targetDepartment][targetRoom - 1]
                .OrderBy(x => x)));
        }

        private static void GetThePatientsOfTheDoctor(Dictionary<string, List<string>> doctorsAndPatients, string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];

            string targetDoctor = firstName + " " + lastName;

            Console.WriteLine(string.Join("\n", doctorsAndPatients[targetDoctor].
                OrderBy(x => x)));
        }
    }
}
