﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VersionBase.Views
{
    public interface IViewWithModel<TViewModel>
    {
        TViewModel ViewModel { get; set; }
    }
}
