using System;
using System.Collections.Generic;
using System.Text;

namespace FACodeTest.RobotWars.Configurations
{
    public class Arena : IArena
    {
        public Arena(uint x, uint y)
        {
            this.UpperLatitude = x;
            this.UpperLongitude = y;
        }

        public uint UpperLatitude { get; private set; }
        public uint UpperLongitude { get; private set; }
    }
}
