using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public abstract class Collection : IAddable
    {
        private List<string> elements;

        public Collection()
        {
            this.Elements = new List<string>();
            this.Index = 0;
        }
        public List<string> Elements { get; private set; }

        public int Index { get; protected set; }

        public abstract int AddElement(string element);
    }
}
