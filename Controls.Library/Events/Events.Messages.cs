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
        public HexModel HexModel { get; set; }
    }

    public class HexClickedLeftButtonMessage
    {
        public HexModel HexModel { get; set; }
    }

    public class TileRequestAskedMessage
    {
        
    }

    public class TileRequestAnsweredMessage
    {
        public TileData TileData { get; set; }
    }
}
