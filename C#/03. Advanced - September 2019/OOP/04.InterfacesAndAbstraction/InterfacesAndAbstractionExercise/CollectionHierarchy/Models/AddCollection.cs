using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : Collection
    {
        public override int AddElement(string element)
        {
            this.Index = this.Elements.Count;

            this.Elements.Add(element);

            return this.Index;
        }
    }
}
