using System.Collections.Generic;
using System.Linq;
using Controls.Library.Events;
using MyToolkit.Messaging;
using VersionBase.Libraries.Hexes;

namespace Controls.Library.Models
{
    public class HexMapModel
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public List<HexModel> ListHexModel { get; set; }

        public HexMapModel()
        {
            ListHexModel = new List<HexModel>();
        }

        public void ImportData(HexMapData hexMapData)
        {
            Columns = hexMapData.Columns;
            Rows = hexMapData.Rows;
            ListHexModel = hexMapData.ListHexData.Select(x => new HexModel(x)).ToList();
            Messenger.Default.Register<GetHexModelFromPositionRequestMessage>(this, GetHexModelFromPositionRequestMessageFunction);
        }

        private void GetHexModelFromPositionRequestMessageFunction(GetHexModelFromPositionRequestMessage msg)
        {
            msg.CallSuccessCallback(GetHexModel(msg.Column, msg.Row));
        }

        public HexModel GetHexModel(int column, int row)
        {
            return ListHexModel.FirstOrDefault(x => x.Column == column && x.Row == row);
        }
    }
}
