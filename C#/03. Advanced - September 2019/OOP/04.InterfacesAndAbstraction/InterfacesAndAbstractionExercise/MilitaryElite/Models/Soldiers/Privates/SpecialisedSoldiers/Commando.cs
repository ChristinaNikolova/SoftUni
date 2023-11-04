using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Models.Enums;

namespace MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, Corp corp) 
            : base(id, firstName, lastName, salary, corp)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (IMission mission in this.missions)
            {
                message.AppendLine($"  {mission.ToString()}");
            }

            return message.ToString().TrimEnd();
        }
    }
}
