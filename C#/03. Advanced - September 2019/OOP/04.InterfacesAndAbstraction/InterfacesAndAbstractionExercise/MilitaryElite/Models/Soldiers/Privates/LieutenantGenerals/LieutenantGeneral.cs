using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Soldiers.Privates.LieutenantGenerals
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (IPrivate @private in this.privates)
            {
                message.AppendLine($"  {@private.ToString()}");
            }

            return message.ToString().TrimEnd();
        }
    }
}
