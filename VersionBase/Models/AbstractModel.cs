using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionBase.Models
{
    public abstract class AbstractModel<TData>
    {
        public abstract void ImportData(TData data);
    }
}
