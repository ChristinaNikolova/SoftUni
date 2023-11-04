using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get => this.height;
            private set
            {
                this.height = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            double area = this.Height * this.Width;

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public override string Draw()
        {
            return base.Draw() + nameof(Rectangle);
        }
    }
}
