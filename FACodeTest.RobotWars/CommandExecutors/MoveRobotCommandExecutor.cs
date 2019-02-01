using FACodeTest.RobotWars.Commands;
using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FACodeTest.RobotWars.CommandExecutors
{
    public  class MoveRobotCommandExecutor: CommandExecutor
    {
        private readonly IList<ICommand> commands;

        public MoveRobotCommandExecutor(IContext context, IList<ICommand> commands)
            : base("^[m|r|l]+$", context)
        {
            this.commands = commands.ToList();
        }

        public override void Process(string command)
        {
            if (!this.Validate(command))
            {
                return;
            }

            var robot = this.context.LatestRobot;
            foreach (char character in command.ToLowerInvariant())
            {
                ICommand executer = GetExecuter(character);
                executer.Execute(character, robot);
            }
            Console.WriteLine(string.Format("{0} {1} {2}", robot.Latitude, robot.Longitude, robot.Direction));
        }

        private ICommand GetExecuter(char character)
        {
            return this.commands.FirstOrDefault(command => command.IsValid(character));
        }
    }
}
