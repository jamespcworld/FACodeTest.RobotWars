using FACodeTest.RobotWars.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FACodeTest.RobotWars.Builders
{
    public class ArenaBuilder:IArenaBuilder
    {
        public IArena Create(uint latitude, uint longitude)
        {
            return new Arena(latitude, longitude);
        }
    }
}
