using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.General
{
    public class GameData
    {
        public HexMapData HexMapData { get; set; }

        public GameData() { }

        public GameData(HexMapData hexMapData)
        {
            HexMapData = hexMapData;
        }
    }
}
