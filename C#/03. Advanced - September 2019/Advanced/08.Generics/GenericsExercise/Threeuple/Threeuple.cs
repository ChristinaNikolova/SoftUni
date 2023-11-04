using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<TItemOne, TItemTwo, TItemThree>
    {
        private TItemOne firstItem;
        private TItemTwo secondItem;
        private TItemThree thirdItem;

        public Threeuple(TItemOne firstItem, TItemTwo secondItem, TItemThree thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.ThirdItem = thirdItem;
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

        public TItemThree ThirdItem
        {
            get
            {
                return this.thirdItem;
            }
            private set
            {
                this.thirdItem = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem} -> {this.ThirdItem}";
        }
    }
}
