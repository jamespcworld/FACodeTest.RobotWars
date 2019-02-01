using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FACodeTest.RobotWars.CommandExecutors
{
    public  class CreateArenaCommandExecutor:CommandExecutor
    {
        private const string latitudeGroupName = "Latitude";
        private const string longitudeGroupName = "Longitude";
        private static readonly string regexPattern = String.Format(@"^(?<{0}>\d+) (?<{1}>\d+)$", latitudeGroupName, longitudeGroupName);

        public CreateArenaCommandExecutor(IContext context)
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

            uint latitude = Convert.ToUInt32(match.Groups[latitudeGroupName].Value);
            uint longitude = Convert.ToUInt32(match.Groups[longitudeGroupName].Value);
            this.context.Arena = this.context.ArenaBuilder.Create(latitude, longitude);

        }
    }
}
