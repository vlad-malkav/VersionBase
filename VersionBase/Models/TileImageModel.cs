﻿using System.Drawing;
using System.Windows.Media.Imaging;
using VersionBase.Libraries.Drawing;
using VersionBase.Libraries.Tiles;

namespace VersionBase.Models
{
    public class TileImageModel : Model<TileImageData>
    {
        private string _id;
        private string _name;
        private string _imageName;
        private Bitmap _bitmap;
        private BitmapImage _bitmapImage;

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string ImageName
        {
            get { return _imageName; }
        }

        public Bitmap Bitmap
        {
            get { return _bitmap; }
        }

        public BitmapImage BitmapImage
        {
            get { return _bitmapImage; }
        }

        public TileImageModel() { }

        public override void ImportData(TileImageData data)
        {
            _id = data.Id;
            _imageName = data.ImageName;
            _name = data.Name;
            _bitmap = HexMapDrawingHelper.GetBitmapFromTileImageData(data);
            _bitmapImage = HexMapDrawingHelper.GetBitmapImageFromTileImageData(data);
        }
    }
}