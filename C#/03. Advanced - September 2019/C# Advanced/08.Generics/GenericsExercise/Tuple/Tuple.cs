using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TItemOne, TItemTwo>
    {
        private TItemOne firstItem;
        private TItemTwo secondItem;

        public Tuple(TItemOne firstItem, TItemTwo secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }

        public TItemOne FirstItem
        {
            get
            {
                return this.firstItem;
            }
            private set
            {
                this.firstItem = value;
            }
        }

        public TItemTwo SecondItem
        {
            get
            {
                return this.secondItem;
            }
            private set
            {
                this.secondItem = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem}";
        }
    }
}
