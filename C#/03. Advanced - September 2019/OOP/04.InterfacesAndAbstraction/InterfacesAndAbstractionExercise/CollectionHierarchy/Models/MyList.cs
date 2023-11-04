using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, ICountable
    {
        public int CountElements => this.Elements.Count;

        public override string RemoveElement()
        {
            this.Index = 0;

            string removedElement = this.Elements[this.Index];

            this.Elements.RemoveAt(this.Index);

            return removedElement;
        }
    }
}
