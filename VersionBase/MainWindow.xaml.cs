using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using Controls.Library.Events;
using Controls.Library.Models;
using Controls.Library.ViewModels;
using MyToolkit.Messaging;
using VersionBase.Data;
using VersionBase.Libraries.Hexes;
using VersionBase.Libraries.Tiles;
using VersionBase.Logic;
using VersionBase.Model;
using VersionBase.ViewModels;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: Honeycombs
//
// summary:	WPF implementation of Rosetta Code Honeycombs task.  Uses Polygon shapes as hexes.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace VersionBase
{
    public partial class MainWindow
    {
        //Game Logic
        public GameLogic BaseLogic { get; set; }
        //Data
        public GameData GameData { get; set; }
        //Models
        public GameModel GameModel { get; set; }
        //ViewModels
        public GameViewModel GameViewModel { get; set; }

        public MainWindow()
        {
            // VS Generated code not included
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameData = new GameData();
            GameModel = new GameModel(GameData);
            GameViewModel = new GameViewModel();
            GameViewModel.ApplyModel(GameModel, Main.ActualHeight, Main.ActualWidth);
            GameViewControl.ViewModel = GameViewModel;

            BaseLogic = new GameLogic();
            this.Close();
        }
    }
}

// Create the Event Message
public class TickerSymbolSelectedMessage
{
    public string StockSymbol { get; set; }
}