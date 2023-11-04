using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, 200)
        {
            this.AggressiveMode = false;
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (!this.AggressiveMode)
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (this.AggressiveMode)
            {
                result = " *Aggressive: ON";
            }
            else
            {
                result = " *Aggressive: OFF";
            }

            return base.ToString()
                + Environment.NewLine
                + result;
        }
    }
}
