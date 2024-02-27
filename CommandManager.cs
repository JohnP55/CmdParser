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
    public class ArgumentCountMismatchException : Exception
    {
        public ArgumentCountMismatchException() : base("The amount of arguments provided does not match the command.") { }
        public ArgumentCountMismatchException(int expected, int got) : base($"The amount of arguments provided does not match the command. (Expected {expected}, got {got})") { }
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
        public string ParseAndExecute(IEnumerable<string> argv)
        {
            if (argv.Count() == 0) return HelpMsg();
            string name = argv.First();
            CommandBase? command = null;
            foreach (var cmd in Commands)
            {
                if (cmd.Name == name)
                {
                    command = cmd;
                    break;
                }
            }

            if (command is null)
                return HelpMsg();

            var cmdArgs = argv.Skip(1);

            if (cmdArgs.Count() != command.ArgCount)
                return HelpMsg();

            var method = command.GetType().GetMethod("Execute", new[] { typeof(IEnumerable<string>) })!;
            return (string)method.Invoke(command, new[] { cmdArgs })!;
        }
    }
}
