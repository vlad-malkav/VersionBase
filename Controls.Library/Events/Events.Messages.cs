using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.Library.Models;
using VersionBase.Libraries.Tiles;

namespace Controls.Library.Events
{
    public class HexClickedRightButtonMessage
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class HexClickedLeftButtonMessage
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class TileRequestAskedMessage
    {
        
    }

    public class TileRequestAnsweredMessage
    {
        public TileData TileData { get; set; }
    }
}
