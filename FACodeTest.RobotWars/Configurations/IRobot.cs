using System;
using System.Collections.Generic;
using System.Text;

namespace FACodeTest.RobotWars.Configurations
{
    public interface IRobot
    {
        RobotDirection Direction { get; }
        uint Latitude { get; }
        uint Longitude { get; }
        IArena Arena { get; set; }
        void Move();
        void Rotate(bool clockwise = true);
        bool EnterArena(IArena arena, uint x, uint y, RobotDirection direction);
    }
}
