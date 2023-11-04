using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
        where T : IComparable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public T Left
        {
            get
            {
                return this.left;
            }
            private set
            {
                this.left = value;
            }
        }

        public T Right
        {
            get
            {
                return this.right;
            }
            private set
            {
                this.right = value;
            }
        }

        public bool AreEqual()
        {
            return this.Left.Equals(this.Right);
        }

        public T GetTheHeavierElement()
        {
            int result = this.Left.CompareTo(this.Right);

            if (result == 1)
            {
                return this.Left;
            }
            else if (result == -1)
            {
                return this.Right;
            }
            else
            {
                return default(T);
            }
        }
    }
}
