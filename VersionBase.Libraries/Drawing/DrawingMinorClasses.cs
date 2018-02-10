using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionBase.Libraries.Drawing
{
    public class Move
    {
        public double XMove { get; set; }
        public double YMove { get; set; }

        public Move(double xMove, double yMove)
        {
            XMove = xMove;
            YMove = yMove;
        }
    }

    public class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinates(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
