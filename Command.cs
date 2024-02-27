namespace JP55.CmdParser
{
    public abstract class CommandBase
    {
        public string Name { get; }
        public string HelpMessage { get; }
        public string Syntax { get; }
        public int ArgCount { get; }
        public CommandBase(string name, string helpMessage, string syntax, int argCount)
        {
            Name = name;
            HelpMessage = helpMessage;
            Syntax = syntax;
            ArgCount = argCount;
        }
    }
    public class Command : CommandBase
    {
        Func<string> Function { get; }
        public Command(string name, string helpMessage, string syntax, Func<string> function) : base(name, helpMessage, syntax, 0)
        {
            Function = function;
        }
        public string Execute() => Function();
    }
    public class Command<T1> : CommandBase
    {
        Func<T1, string> Function { get; }
        Func<IEnumerable<string>, T1> ArgPrepHelper { get; }
        public Command(string name, string helpMessage, string syntax, Func<IEnumerable<string>, T1> argPrepHelper, Func<T1, string> function) : base(name, helpMessage, syntax, 1)
        {
            Function = function;
            ArgPrepHelper = argPrepHelper;
        }
        public string Execute(T1 in1) => Function(in1);
        public string Execute(IEnumerable<string> args) => Execute(ArgPrepHelper(args));
    }
    public class Command<T1, T2> : CommandBase
    {
        Func<T1, T2, string> Function { get; }
        Func<IEnumerable<string>, (T1, T2)> ArgPrepHelper { get; }
        public Command(string name, string helpMessage, string syntax, Func<IEnumerable<string>, (T1, T2)> argPrepHelper, Func<T1, T2, string> function) : base(name, helpMessage, syntax, 2)
        {
            Function = function;
            ArgPrepHelper = argPrepHelper;
        }
        public string Execute(T1 in1, T2 in2) => Function(in1, in2);
        public string Execute((T1 in1, T2 in2) args) => Execute(args.in1, args.in2);
        public string Execute(IEnumerable<string> args) => Execute(ArgPrepHelper(args));
    }
    public class Command<T1, T2, T3> : CommandBase
    {
        Func<T1, T2, T3, string> Function { get; }
        Func<IEnumerable<string>, (T1, T2, T3)> ArgPrepHelper { get; }
        public Command(string name, string helpMessage, string syntax, Func<IEnumerable<string>, (T1, T2, T3)> argPrepHelper, Func<T1, T2, T3, string> function) : base(name, helpMessage, syntax, 3)
        {
            Function = function;
            ArgPrepHelper = argPrepHelper;
        }
        public string Execute(T1 in1, T2 in2, T3 in3) => Function(in1, in2, in3);
        public string Execute((T1 in1, T2 in2, T3 in3) args) => Execute(args.in1, args.in2, args.in3);
        public string Execute(IEnumerable<string> args) => Execute(ArgPrepHelper(args));
    }
    public class Command<T1, T2, T3, T4> : CommandBase
    {
        Func<T1, T2, T3, T4, string> Function { get; }
        Func<IEnumerable<string>, (T1, T2, T3, T4)> ArgPrepHelper { get; }
        public Command(string name, string helpMessage, string syntax, Func<IEnumerable<string>, (T1, T2, T3, T4)> argPrepHelper, Func<T1, T2, T3, T4, string> function) : base(name, helpMessage, syntax, 4)
        {
            Function = function;
            ArgPrepHelper = argPrepHelper;
        }
        public string Execute(T1 in1, T2 in2, T3 in3, T4 in4) => Function(in1, in2, in3, in4);
        public string Execute((T1 in1, T2 in2, T3 in3, T4 in4) args) => Execute(args.in1, args.in2, args.in3, args.in4);
        public string Execute(IEnumerable<string> args) => Execute(ArgPrepHelper(args));
    }
}