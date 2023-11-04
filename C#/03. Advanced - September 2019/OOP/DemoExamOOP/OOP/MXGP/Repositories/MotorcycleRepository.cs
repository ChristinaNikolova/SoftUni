using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }
        public void Add(IMotorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motorcycles.AsReadOnly();
        }

        public IMotorcycle GetByName(string name)
        {
            IMotorcycle motorcycle = this.motorcycles
                .FirstOrDefault(x => x.Model == name);

            return motorcycle;
        }

        public bool Remove(IMotorcycle model)
        {
            IMotorcycle motorcycle = this.GetByName(model.Model);

            if (motorcycle == null)
            {
                return false;
            }

            this.motorcycles.Remove(motorcycle);

            return true;
        }
    }
}
