using MilitaryElite.Contracts;
using MilitaryElite.Models.Enums;
using MilitaryElite.Models.OtherItems;
using MilitaryElite.Models.Soldiers.Privates;
using MilitaryElite.Models.Soldiers.Privates.LieutenantGenerals;
using MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers;
using MilitaryElite.Models.Soldiers.Spies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string typeSoldier = elements[0];
                string id = elements[1];
                string firstName = elements[2];
                string lastName = elements[3];

                ISoldier soldier = null;

                if (typeSoldier == "Private")
                {
                    decimal salary = decimal.Parse(elements[4]);

                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (typeSoldier == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(elements[4]);

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < elements.Length; i++)
                    {
                        string targetId = elements[i];

                        IPrivate @private = (IPrivate)soldiers
                            .FirstOrDefault(x => x.Id == targetId);

                        ILieutenantGeneral lieutenantGeneral = soldier as ILieutenantGeneral;
                        lieutenantGeneral.AddPrivate(@private);
                    }
                }
                else if (typeSoldier == "Engineer")
                {
                    decimal salary = decimal.Parse(elements[4]);
                    string targetCorp = elements[5];

                    bool isCorpValid = Enum.TryParse<Corp>(targetCorp, out Corp corp);
                    if (!isCorpValid)
                    {
                        continue;
                    }

                    soldier = new Engineer(id, firstName, lastName, salary, corp);

                    IEngineer engineer = soldier as IEngineer;

                    for (int i = 6; i < elements.Length; i += 2)
                    {
                        string partName = elements[i];
                        int hours = int.Parse(elements[i + 1]);

                        IRepair repair = new Repair(partName, hours);
                        engineer.AddRepair(repair);
                    }
                }
                else if (typeSoldier == "Commando")
                {
                    decimal salary = decimal.Parse(elements[4]);
                    string targetCorp = elements[5];

                    bool isCorpValid = Enum.TryParse<Corp>(targetCorp, out Corp corp);
                    if (!isCorpValid)
                    {
                        continue;
                    }

                    soldier = new Commando(id, firstName, lastName, salary, corp);

                    ICommando commando = soldier as ICommando;

                    for (int i = 6; i < elements.Length; i += 2)
                    {
                        string codeName = elements[i];
                        string targetMissionState = elements[i + 1];

                        bool isMissionStateValid = Enum.TryParse<MissionState>(targetMissionState, out MissionState missionState);
                        if (!isMissionStateValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, missionState);
                        commando.AddMission(mission);
                    }
                }
                else if (typeSoldier == "Spy")
                {
                    int codeNumber = int.Parse(elements[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                soldiers.Add(soldier);
            }

            foreach (ISoldier soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
