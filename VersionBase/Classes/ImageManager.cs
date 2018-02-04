using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MyToolkit.Messaging;
using VersionBase.Events;
using VersionBase.Libraries.Drawing;

namespace VersionBase.Classes
{
    public class ImageManager
    {
        public Dictionary<string, Bitmap> DictionaryBitmap { get; set; }
        public Dictionary<string, BitmapImage> DictionaryBitmapImage { get; set; }

        public ImageManager()
        {
            DictionaryBitmap = new Dictionary<string, Bitmap>();
            DictionaryBitmapImage = new Dictionary<string, BitmapImage>();
            Messenger.Default.Register<GetBitmapByNameMessage>(this, GetBitmapByNameMessageFunction);
            Messenger.Default.Register<GetBitmapImageByNameMessage>(this, GetBitmapImageByNameMessageFunction);
        }

        private void GetBitmapByNameMessageFunction(GetBitmapByNameMessage msg)
        {
            msg.CallSuccessCallback(GetBitmap(msg.ImageName));
        }

        private void GetBitmapImageByNameMessageFunction(GetBitmapImageByNameMessage msg)
        {
            msg.CallSuccessCallback(GetBitmapImage(msg.ImageName));
        }

        public Bitmap GetBitmap(string name)
        {
            if (!DictionaryBitmap.ContainsKey(name))
            {
                DictionaryBitmap.Add(name, HexMapDrawingHelper.GetBitmapFromName(name));
            }
            return DictionaryBitmap[name];
        }

        public BitmapImage GetBitmapImage(string name)
        {
            if (!DictionaryBitmapImage.ContainsKey(name))
            {
                DictionaryBitmapImage.Add(name, HexMapDrawingHelper.GetBitmapImageFromName(name));
            }
            return DictionaryBitmapImage[name];
        }
    }
}
