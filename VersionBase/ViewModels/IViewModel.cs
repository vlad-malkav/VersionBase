using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToolkit.Mvvm;

namespace VersionBase.ViewModels
{
    public abstract class AbstractViewModel<TModel> : ViewModelBase // from MyToolkit
    {
        public abstract void ApplyModel(TModel model);
    }
}
