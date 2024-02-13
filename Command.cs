namespace JP55.CmdParser
{
    public class ReadyCommand
    {
        public Command Command { get; }
        public List<CommandArgument> Arguments { get; }
        public ReadyCommand(Command command, IEnumerable<CommandArgument> arguments)
        {
            Command = command;
            Arguments = arguments.ToList();
        }
    }
    public abstract class Command
    {
        public string Name { get; }
        public string HelpMessage { get; }
        public string Syntax { get; }
        public int ArgCount => Arguments.Count;
        public List<CommandArgument> Arguments { get; }
        public Command(string name, string helpMessage, string syntax, List<CommandArgument> arguments)
        {
            Name = name;
            HelpMessage = helpMessage;
            Syntax = syntax;
            Arguments = arguments;
        }
    }
}