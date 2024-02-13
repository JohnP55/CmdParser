using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP55.CmdParser
{
    public enum CommandArgumentType
    {
        FLAG,
        VALUE,
        KEY_VALUE
    }
    public class CommandArgument
    {
        public string Name { get; }
        public CommandArgumentType Type { get; }
        public int ArgCount { get; }

        public CommandArgument(string name, CommandArgumentType type, int argCount)
        {
            Name = name;
            Type = type;
            ArgCount = argCount;
        }
    }
}
