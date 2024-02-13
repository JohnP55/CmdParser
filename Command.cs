namespace JP55.CmdParser
{
    public abstract class CommandBase
    {
        public string Name { get; }
        public string HelpMessage { get; }
        public string Syntax { get; }
        public int ArgCount => ArgTypes.Count - 1;
        public List<Type> ArgTypes { get; } = new List<Type>();
        public CommandBase(string name, string helpMessage, string syntax)
        {
            Name = name;
            HelpMessage = helpMessage;
            Syntax = syntax;
        }
    }
    public class Command<TOut> : CommandBase
    {
        Func<TOut> Function { get; }
        public Command(string name, string helpMessage, string syntax, Func<TOut> function) : base(name, helpMessage, syntax)
        {
            Function = function;
            ArgTypes.Add(typeof(TOut));
        }
        public TOut Execute() => Function();
    }
    public class Command<T1, TOut> : CommandBase
    {
        Func<T1, TOut> Function { get; }
        Func<CommandBase, IEnumerable<string>, T1> ArgPrepHelper { get; }
        public Command(string name, string helpMessage, string syntax, Func<CommandBase, IEnumerable<string>, T1> argPrepHelper, Func<T1, TOut> function) : base(name, helpMessage, syntax)
        {
            Function = function;
            ArgPrepHelper = argPrepHelper;
            ArgTypes.Add(typeof(T1));
            ArgTypes.Add(typeof(TOut));
        }
        public TOut Execute(T1 in1) => Function(in1);
        public TOut Execute(IEnumerable<string> args) => Execute(ArgPrepHelper(this, args));
    }
    public class Command<T1, T2, TOut> : CommandBase
    {
        Func<T1, T2, TOut> Function { get; }
        Func<CommandBase, IEnumerable<string>, (T1, T2)> ArgPrepHelper { get; }
        public Command(string name, string helpMessage, string syntax, Func<CommandBase, IEnumerable<string>, (T1, T2)> argPrepHelper, Func<T1, T2, TOut> function) : base(name, helpMessage, syntax)
        {
            Function = function;
            ArgPrepHelper = argPrepHelper;
            ArgTypes.Add(typeof(T1));
            ArgTypes.Add(typeof(T2));
            ArgTypes.Add(typeof(TOut));
        }
        public TOut Execute(T1 in1, T2 in2) => Function(in1, in2);
        public TOut Execute((T1 in1, T2 in2) args) => Execute(args.in1, args.in2);
        public TOut Execute(IEnumerable<string> args) => Execute(ArgPrepHelper(this, args));
    }
    public class Command<T1, T2, T3, TOut> : CommandBase
    {
        Func<T1, T2, T3, TOut> Function { get; }
        Func<CommandBase, IEnumerable<string>, (T1, T2, T3)> ArgPrepHelper { get; }
        public Command(string name, string helpMessage, string syntax, Func<CommandBase, IEnumerable<string>, (T1, T2, T3)> argPrepHelper, Func<T1, T2, T3, TOut> function) : base(name, helpMessage, syntax)
        {
            Function = function;
            ArgPrepHelper = argPrepHelper;
            ArgTypes.Add(typeof(T1));
            ArgTypes.Add(typeof(T2));
            ArgTypes.Add(typeof(T3));
            ArgTypes.Add(typeof(TOut));
        }
        public TOut Execute(T1 in1, T2 in2, T3 in3) => Function(in1, in2, in3);
        public TOut Execute((T1 in1, T2 in2, T3 in3) args) => Execute(args.in1, args.in2, args.in3);
        public TOut Execute(IEnumerable<string> args) => Execute(ArgPrepHelper(this, args));
    }
    public class Command<T1, T2, T3, T4, TOut> : CommandBase
    {
        Func<T1, T2, T3, T4, TOut> Function { get; }
        Func<CommandBase, IEnumerable<string>, (T1, T2, T3, T4)> ArgPrepHelper { get; }
        public Command(string name, string helpMessage, string syntax, Func<CommandBase, IEnumerable<string>, (T1, T2, T3, T4)> argPrepHelper, Func<T1, T2, T3, T4, TOut> function) : base(name, helpMessage, syntax)
        {
            Function = function;
            ArgPrepHelper = argPrepHelper;
            ArgTypes.Add(typeof(T1));
            ArgTypes.Add(typeof(T2));
            ArgTypes.Add(typeof(T3));
            ArgTypes.Add(typeof(T4));
            ArgTypes.Add(typeof(TOut));
        }
        public TOut Execute(T1 in1, T2 in2, T3 in3, T4 in4) => Function(in1, in2, in3, in4);
        public TOut Execute((T1 in1, T2 in2, T3 in3, T4 in4) args) => Execute(args.in1, args.in2, args.in3, args.in4);
        public TOut Execute(IEnumerable<string> args) => Execute(ArgPrepHelper(this, args));
    }
}