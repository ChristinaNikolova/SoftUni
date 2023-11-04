using MilitaryElite.Contracts;
using MilitaryElite.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corp corp)
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public Corp Corp { get; private set; }

        public override string ToString()
        {
            return base.ToString()
                + Environment.NewLine
                + $"Corps: {this.Corp}";
        }
    }
}
