using System;
using WildFarm.Core;

namespace WildFarm
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
