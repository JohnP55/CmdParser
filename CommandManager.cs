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
        public List<Command> Commands { get; } = new List<Command>();
        public CommandManager() { }
        public CommandManager(params Command[] commands)
        {
            Commands.AddRange(commands);
        }
        public void AddCommand(Command command)
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
        public ReadyCommand? Parse(IEnumerable<string> args)
        {
            if (args.Count() == 0) return null;
            string name = args.First();
            Command? command = null;
            foreach (var cmditer in Commands)
            {
                if (cmditer.Name == name)
                {
                    command = cmditer;
                    break;
                }
            }
            if (command is null) return null;

            List<CommandArgument> arguments = new List<CommandArgument>();
            int i = 1;
            while (i < args.Count())
            {
                CommandArgument? argument = null;
                foreach(var argiter in command.Arguments)
                {
                    if (args.ElementAt(i) == argiter.Name)
                    {
                        argument = argiter;
                        break;
                    }
                }
                if (argument is null) return null;


                i += argument.ArgCount;
            }
        }
        public TOut Execute<TOut>(Command command, IEnumerable<string> args)
        {
            var method = command.GetType().GetMethod("Execute", new[] { typeof(IEnumerable<string>) })!;
            return (TOut)method.Invoke(command, new[] { args })!;
        }
    }
}
