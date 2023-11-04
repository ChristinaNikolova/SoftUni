using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (MethodInfo method in methods)
        {
            AuthorAttribute[] attributes = method
                .GetCustomAttributes<AuthorAttribute>()
                .ToArray();

            foreach (AuthorAttribute attribute in attributes)
            {
                Console.WriteLine($"{method.Name} is written by {attribute.Name}");
            }
        }
    }
}
