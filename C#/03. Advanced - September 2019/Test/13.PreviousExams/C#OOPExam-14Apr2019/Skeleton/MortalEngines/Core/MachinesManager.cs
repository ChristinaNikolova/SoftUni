namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            if (this.pilots.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.PilotExists,
                    name);
            }

            IPilot pilot = new Pilot(name);
            this.pilots.Add(pilot);

            return string.Format(OutputMessages.PilotHired,
                name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists,
                    name);
            }

            IMachine tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);

            return string.Format(OutputMessages.TankManufactured,
                name,
                tank.AttackPoints,
                tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists,
                    name);
            }

            IMachine fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);

            return string.Format(OutputMessages.FighterManufactured,
                name,
                fighter.AttackPoints,
                fighter.DefensePoints,
                "ON");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots
                .FirstOrDefault(x => x.Name == selectedPilotName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound,
                    selectedPilotName);
            }

            IMachine machine = this.machines
                .FirstOrDefault(x => x.Name == selectedMachineName);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound,
                    selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready,
                    selectedMachineName);
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return string.Format(OutputMessages.MachineEngaged,
                selectedPilotName,
                selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = this.machines
                .FirstOrDefault(x => x.Name == attackingMachineName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound,
                    attackingMachineName);
            }

            IMachine defender = this.machines
                .FirstOrDefault(x => x.Name == defendingMachineName);

            if (defender == null)
            {
                return string.Format(OutputMessages.MachineNotFound,
                    defendingMachineName);
            }

            if (attacker.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack,
                    attackingMachineName);
            }

            if (defender.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack,
                    defendingMachineName);
            }

            attacker.Attack(defender);

            return string.Format(OutputMessages.AttackSuccessful,
                defendingMachineName,
                attackingMachineName,
                defender.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots
                .FirstOrDefault(x => x.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines
                .FirstOrDefault(x => x.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter fighter = this.machines
                 .FirstOrDefault(x => x.Name == fighterName) as IFighter;

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound,
                    fighterName);
            }

            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful,
                fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tank = this.machines
                .FirstOrDefault(x => x.Name == tankName) as ITank;

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound,
                    tankName);
            }

            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful,
                tankName);
        }
    }
}