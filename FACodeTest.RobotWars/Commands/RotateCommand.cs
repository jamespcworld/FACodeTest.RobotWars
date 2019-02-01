using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FACodeTest.RobotWars.Commands
{
    public class RotateCommand : ICommand
    {
        private const string rightCommand = "R";
        private const string leftCommand = "L";

        public bool Execute(char command, IRobot robot)
        {
            if (!this.IsValid(command))
            {
                return false;
            }

            this.ProcessCommand(command, robot);
            return true;
        }

        private void ProcessCommand(char command, IRobot robot)
        {
            string commandAsString = command.ToString();
            if (this.IsLeftCommand(commandAsString))
            {
                robot.Rotate(false);
            }

            if (this.IsRightCommand(commandAsString))
            {
                robot.Rotate(true);
            }
        }

        private bool IsRightCommand(string command)
        {
            return command.Equals(rightCommand, StringComparison.InvariantCultureIgnoreCase);
        }

        private bool IsLeftCommand(string command)
        {
            return command.Equals(leftCommand, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsValid(char command)
        {
            string commandAsString = command.ToString();
            return this.IsLeftCommand(commandAsString)
                || this.IsRightCommand(commandAsString);
        }
    }
}
