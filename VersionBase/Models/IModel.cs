using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionBase.Models
{
    public interface IModel<TData>
    {
        void ImportData(TData data);
    }
}
