using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FACodeTest.RobotWars.CommandExecutors
{
    public abstract class CommandExecutor:ICommandExecutor
    {
        private readonly Regex regex;
        protected readonly IContext context;

        protected CommandExecutor(string pattern, IContext context)
        {
            this.context = context;
            this.regex = new Regex(pattern, RegexOptions.IgnoreCase);
        }
        public bool Validate(string command)
        {
            return this.regex.IsMatch(command);
        }

        public bool Validate(string command, out Match match)
        {
            match = this.regex.Match(command);
            return match.Success;
        }

        public abstract void Process(string command);
    }
}
