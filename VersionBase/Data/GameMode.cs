using System.ComponentModel;

namespace VersionBase.Data
{
    public enum GameMode
    {
        [Description("Map Creation")]
        MapCreation = 0,
        [Description("Hex Edition")]
        HexEdition = 1,
        [Description("Visualization")]
        Visualization = 2
    }
}
