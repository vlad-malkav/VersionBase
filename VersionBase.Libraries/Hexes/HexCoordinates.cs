using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionBase.Libraries.Hexes
{
    public class HexCoordinates
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public HexCoordinates(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
