using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        private string name;
        private Stat stat;
        private Weapon weapon;

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public Stat Stat
        {
            get
            {
                return this.stat;
            }
            private set
            {
                this.stat = value;
            }
        }

        public Weapon Weapon
        {
            get
            {
                return this.weapon;
            }
            private set
            {
                this.weapon = value;
            }
        }

        public int GetTotalPower()
        {
            int totalPower = this.GetStatPower() + this.GetWeaponPower();

            return totalPower;
        }

        public int GetWeaponPower()
        {
            int totalWeaponPower = this.Weapon.Sharpness
                + this.Weapon.Size
                + this.Weapon.Solidity;

            return totalWeaponPower;
        }

        public int GetStatPower()
        {
            int totalStatPower = this.Stat.Agility
                + this.Stat.Flexibility
                + this.Stat.Intelligence
                + this.Stat.Skills
                + this.Stat.Strength;

            return totalStatPower;
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"{this.Name} - {this.GetTotalPower()}")
                .AppendLine($"  Weapon Power: {this.GetWeaponPower()}")
                .Append($"  Stat Power: {this.GetStatPower()}");

            return message.ToString();
        }
    }
}
