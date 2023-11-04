using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double GetTheSurfaceArea()
        {
            double surfaceArea = this.GetTheLateralSurfaceArea() + 2 * this.Length * this.Width;

            return surfaceArea;
        }

        public double GetTheLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * (this.Length * this.Height + this.Width * this.Height);

            return lateralSurfaceArea;
        }

        public double GetTheVolume()
        {
            double volume = this.Length * this.Width * this.Height;

            return volume;
        }
    }
}
