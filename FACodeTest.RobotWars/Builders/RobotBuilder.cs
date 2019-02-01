using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FACodeTest.RobotWars.Builders
{
    public class RobotBuilder:IRobotBuilder
    {
        public IRobot Create()
        {
            return new Robot();
        }
    }
}
