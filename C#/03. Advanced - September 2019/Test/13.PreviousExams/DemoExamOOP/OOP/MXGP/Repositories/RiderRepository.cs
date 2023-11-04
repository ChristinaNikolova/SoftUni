using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }
        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders.AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            IRider rider = this.riders
                .FirstOrDefault(x => x.Name == name);

            return rider;
        }

        public bool Remove(IRider model)
        {
            IRider rider = this.GetByName(model.Name);

            if (rider == null)
            {
                return false;
            }

            this.riders.Remove(rider);

            return true;
        }
    }
}
