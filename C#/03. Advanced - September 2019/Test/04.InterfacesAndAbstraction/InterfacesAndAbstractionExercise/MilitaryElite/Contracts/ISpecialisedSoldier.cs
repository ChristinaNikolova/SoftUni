using MilitaryElite.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corp Corp { get; }
    }
}
