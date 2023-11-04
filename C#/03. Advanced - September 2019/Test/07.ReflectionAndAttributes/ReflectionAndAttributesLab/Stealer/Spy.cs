using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    private StringBuilder message;

    public Spy()
    {
        this.message = new StringBuilder();
    }
    public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
    {
        this.message.AppendLine($"Class under investigation: {className}");

        Type type = Type.GetType(className);

        object instance = Activator.CreateInstance(type);

        FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
            .Where(x => fieldsToInvestigate.Contains(x.Name))
            .ToArray();

        foreach (FieldInfo field in fields)
        {
            this.message.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }

        return this.message.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type type = Type.GetType(className);

        FieldInfo[] publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (FieldInfo field in publicFields)
        {
            this.message.AppendLine($"{field.Name} must be private!");
        }

        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (MethodInfo method in privateMethods.Where(x => x.Name.StartsWith("get")))
        {
            this.message.AppendLine($"{method.Name} have to be public!");
        }

        MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (MethodInfo method in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            this.message.AppendLine($"{method.Name} have to be private!");
        }

        return this.message.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);

        this.message.AppendLine($"All Private Methods of Class: {className}")
            .AppendLine($"Base Class: {type.BaseType.Name}");

        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (MethodInfo method in privateMethods)
        {
            this.message.AppendLine(method.Name);
        }

        return this.message.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("get")))
        {
            this.message.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("set")))
        {
            this.message.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return this.message.ToString().TrimEnd();
    }
}

