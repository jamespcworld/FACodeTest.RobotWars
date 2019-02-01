using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FACodeTest.RobotWars.Builders
{
    public interface IArenaBuilder
    {
        IArena Create(uint latitude, uint longitude);
    }
}
