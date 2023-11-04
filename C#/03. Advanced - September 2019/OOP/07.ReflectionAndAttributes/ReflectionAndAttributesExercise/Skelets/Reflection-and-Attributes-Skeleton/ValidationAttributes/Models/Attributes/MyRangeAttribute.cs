using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes.Models
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int number = Convert.ToInt32(obj);

            return number > this.minValue && number < this.maxValue;
        }
    }
}
