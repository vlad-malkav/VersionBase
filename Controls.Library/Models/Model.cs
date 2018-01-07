using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls.Library.Models
{
    public abstract class Model<TData>
    {
        public abstract void ImportData(TData data);
    }
}
