using DataLibrary.General;
using DataLibrary.Hexes;
using DataLibrary.Tiles;
using VersionBase.Models;
using VersionBase.Libraries;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Data
{
    public class ApplicationData
    {
        public UIData UIData;
        public GameData GameData;

        public ApplicationData()
            :this(0,0)
        {
        }

        public ApplicationData(int colCount, int rowCount)
        {
            UIData = DataGeneration.GenerateUIData();
            GameData = DataGeneration.GenerateGameData(colCount, rowCount);
        }
    }
}