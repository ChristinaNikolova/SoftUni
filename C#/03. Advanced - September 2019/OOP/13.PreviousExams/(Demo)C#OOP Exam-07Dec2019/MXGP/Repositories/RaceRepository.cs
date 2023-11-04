using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            IRace race = this.races
                .FirstOrDefault(x => x.Name == name);

            return race;
        }

        public bool Remove(IRace model)
        {
            IRace race = this.GetByName(model.Name);

            if (race == null)
            {
                return false;
            }

            this.races.Remove(race);

            return true;
        }
    }
}
