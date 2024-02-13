using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace JP55.CmdParser
{
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException() : base("The specified command was not found in the command manager.") { }
    }
    public class CommandManager
    {
        public List<CommandBase> Commands { get; } = new List<CommandBase>();
        public CommandManager() { }
        public CommandManager(params CommandBase[] commands)
        {
            Commands.AddRange(commands);
        }
        public void AddCommand(CommandBase command)
        {
            Commands.Add(command);
        }
        public string HelpMsg()
        {
            if (Commands.Count == 0) return "No commands.";
            List<string> individualCommands = new List<string>();
            foreach (var command in Commands)
            {
                individualCommands.Add($"{command.Name}: {command.Syntax}{Environment.NewLine}\t{command.HelpMessage}");
            }
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", individualCommands);
        }
        public CommandBase? Parse(IEnumerable<string> args)
        {
            if (args.Count() == 0) return null;
            string name = args.First();
            foreach (var command in Commands)
            {
                if (command.Name == name)
                    return command;
            }
            
            return null;
        }
        public TOut Execute<TOut>(CommandBase command, IEnumerable<string> args)
        {
            var method = command.GetType().GetMethod("Execute", new[] { typeof(IEnumerable<string>) })!;
            return (TOut)method.Invoke(command, new[] { args })!;
        }
    }
}
