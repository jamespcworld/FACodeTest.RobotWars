using FACodeTest.RobotWars.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FACodeTest.RobotWars.Configurations
{
    public interface IContext
    {
        IArena Arena { get; set; }
        IRobot LatestRobot { get; set; }

        IArenaBuilder ArenaBuilder { get; }
        IRobotBuilder RobotBuilder { get; }
    }
}
