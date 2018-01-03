using System.ComponentModel;

namespace VersionBase.Libraries.Enums
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
