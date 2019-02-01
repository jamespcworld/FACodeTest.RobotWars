using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FACodeTest.RobotWars.CommandExecutors
{
    public  class CreateRobotCommandExecutor : CommandExecutor
    {
        private const string latitudeGroupName = "Latitude";
        private const string longitudeGroupName = "Longitude";
        private const string directionGroupName = "Direction";

        private static readonly string regexPattern = string.Format(@"^(?<{0}>\d+) (?<{1}>\d+) (?<{2}>[n|e|s|w])$", latitudeGroupName, longitudeGroupName, directionGroupName);

        public CreateRobotCommandExecutor(IContext context)
            : base(regexPattern, context)
        {
        }

        public override void Process(string command)
        {
            Match match;
            if (!this.Validate(command, out match))
            {
                return;
            }

            this.context.LatestRobot = this.context.RobotBuilder.Create();

            if (this.context.LatestRobot == null)
            {
                return;
            }

            uint latitude = Convert.ToUInt32(match.Groups[latitudeGroupName].Value);
            uint longitude = Convert.ToUInt32(match.Groups[longitudeGroupName].Value);
            RobotDirection direction = ConvertToDirection(match.Groups[directionGroupName].Value);

            bool robotCreated = this.context.LatestRobot.EnterArena(this.context.Arena, latitude, longitude, direction);

        }

        private RobotDirection ConvertToDirection(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "e":
                    return RobotDirection.East;
                case "s":
                    return RobotDirection.South;
                case "w":
                    return RobotDirection.West;
                default:
                    return RobotDirection.North;
            }
        }
    }
}
