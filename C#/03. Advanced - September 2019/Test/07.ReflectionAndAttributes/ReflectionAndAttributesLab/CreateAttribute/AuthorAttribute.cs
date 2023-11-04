using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
    private string name;

    public AuthorAttribute(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            this.name = value;
        }
    }
}
