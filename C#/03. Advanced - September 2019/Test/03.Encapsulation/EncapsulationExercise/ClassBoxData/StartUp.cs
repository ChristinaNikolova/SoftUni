using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                double surfaceArea = box.GetTheSurfaceArea();
                double lateralSurfaceArea = box.GetTheLateralSurfaceArea();
                double volume = box.GetTheVolume();

                Console.WriteLine($"Surface Area - {surfaceArea:F2}");
                Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
                Console.WriteLine($"Volume - {volume:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
