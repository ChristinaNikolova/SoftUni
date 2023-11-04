using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] elementsInput = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = elementsInput[0] + "Command";

            Type[] types = Assembly.GetCallingAssembly().GetTypes();

            Type type = types
                .FirstOrDefault(x => x.Name == commandName);

            ICommand command = Activator.CreateInstance(type) as ICommand;

            string result = command.Execute(elementsInput);

            return result;
        }
    }
}
