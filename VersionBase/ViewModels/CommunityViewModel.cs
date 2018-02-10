using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionBase.Libraries.Drawing;

namespace VersionBase.ViewModels
{
    public class CommunityViewModel
    {
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }

        public CommunityViewModel()
        {
            Name = "Bob";
        }

        public CommunityViewModel(string name, Coordinates coordinates)
        {
            this.Name = name;
            this.Coordinates = coordinates;
        }
    }
}
