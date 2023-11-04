using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalBedsPerDepartment = 60;
            int patientsPerRoom = 3;

            Dictionary<string, List<string>> departmentsAndPatients = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctorsAndPatients = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Output")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string department = elements[0];
                string firstName = elements[1];
                string lastName = elements[2];
                string doctor = firstName + " " + lastName;
                string patient = elements[3];

                bool isDepartmentAdded = departmentsAndPatients.ContainsKey(department);
                if (!isDepartmentAdded)
                {
                    departmentsAndPatients.Add(department, new List<string>());
                }

                bool isFreeBed = departmentsAndPatients[department].Count <= totalBedsPerDepartment;
                if (!isFreeBed)
                {
                    continue;
                }

                departmentsAndPatients[department].Add(patient);

                bool isDoctorAdded = doctorsAndPatients.ContainsKey(doctor);
                if (!isDoctorAdded)
                {
                    doctorsAndPatients.Add(doctor, new List<string>());
                }

                doctorsAndPatients[doctor].Add(patient);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (elements.Length == 1)
                {
                    string department = elements[0];

                    List<string> patients = departmentsAndPatients[department];

                    bool areAny = patients.Count > 0;
                    if (areAny)
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, patients));
                    }
                }
                else if (elements.Length == 2)
                {
                    string elementToCheck = elements[1];

                    bool isRoomNumber = char.IsDigit(elementToCheck[0]);
                    if (isRoomNumber)
                    {
                        string department = elements[0];
                        int roomNumber = int.Parse(elementToCheck);

                        List<string> patients = departmentsAndPatients[department]
                            .Skip(patientsPerRoom * (roomNumber - 1))
                            .Take(patientsPerRoom)
                            .OrderBy(x => x)
                            .ToList();

                        bool areAny = patients.Count > 0;
                        if (areAny)
                        {
                            Console.WriteLine(string.Join(Environment.NewLine, patients));
                        }
                    }
                    else
                    {
                        string firstName = elements[0];
                        string lastName = elementToCheck;

                        string doctor = firstName + " " + lastName;

                        List<string> patients = doctorsAndPatients[doctor]
                            .OrderBy(x => x)
                            .ToList();

                        bool areAny = patients.Count > 0;
                        if (areAny)
                        {
                            Console.WriteLine(string.Join(Environment.NewLine, patients));
                        }
                    }
                }
            }
        }
    }
}
