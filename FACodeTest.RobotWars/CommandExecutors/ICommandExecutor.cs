using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FACodeTest.RobotWars.CommandExecutors
{
    public interface ICommandExecutor
    {
        bool Validate(string command);
        bool Validate(string command, out Match match);
        void Process(string command);
    }
}
