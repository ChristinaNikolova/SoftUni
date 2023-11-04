using MilitaryElite.Contracts;
using MilitaryElite.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, Corp corp) 
            : base(id, firstName, lastName, salary, corp)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (IRepair repair in this.repairs)
            {
                message.AppendLine($"  {repair.ToString()}");
            }

            return message.ToString().TrimEnd();
        }
    }
}
