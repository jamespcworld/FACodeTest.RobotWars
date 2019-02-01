using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FACodeTest.RobotWars.Commands
{
    public interface ICommand
    {
        bool Execute(char command, IRobot robot);
        bool IsValid(char command);
    }
}
