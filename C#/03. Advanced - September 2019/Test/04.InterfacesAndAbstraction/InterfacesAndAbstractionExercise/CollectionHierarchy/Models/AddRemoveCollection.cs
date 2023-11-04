using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : Collection, IRemovable
    {
        public override int AddElement(string element)
        {
            this.Index = 0;

            this.Elements.Insert(this.Index, element);

            return this.Index;
        }

        public virtual string RemoveElement()
        {
            this.Index = this.Elements.Count-1;

            string removedElement = this.Elements[this.Index];

            this.Elements.RemoveAt(this.Index);

            return removedElement;
        }
    }
}
