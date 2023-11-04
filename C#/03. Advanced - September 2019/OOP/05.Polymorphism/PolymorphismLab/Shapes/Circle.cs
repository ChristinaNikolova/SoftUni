using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set
            {
                this.radius = value;
            }
        }

        public override double CalculateArea()
        {
            double area = Math.PI * Math.Pow(this.Radius, 2);

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override string Draw()
        {
            return base.Draw() + nameof(Circle);
        }
    }
}
