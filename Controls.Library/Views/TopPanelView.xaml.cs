﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controls.Library.Annotations;
using Controls.Library.ViewModels;

namespace Controls.Library.Views
{
    /// <summary>
    /// Interaction logic for TopPanelView.xaml
    /// </summary>
    public partial class TopPanelView : UserControl, INotifyPropertyChanged
    {
        public TopPanelView()
        {
            InitializeComponent();
        }

        public TopPanelViewModel ViewModel
        {
            get { return (TopPanelViewModel)Resources["ViewModel"]; }
            set
            {
                Resources["ViewModel"] = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
