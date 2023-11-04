using CollectionHierarchy.Core;
using System;

namespace CollectionHierarchy
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
