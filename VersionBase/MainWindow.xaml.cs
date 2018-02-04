using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Serialization;
using DataLibrary.General;
using VersionBase.Events;
using VersionBase.Forms;
using Microsoft.Win32;
using MyToolkit.Messaging;
using VersionBase.Classes;
using VersionBase.Libraries;
using VersionBase.Logic;
using VersionBase.Models;
using VersionBase.ViewModels;
using VersionBase.Data;
using VersionBase.Helpers;

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
        //Models
        public ApplicationModel ApplicationModel { get; set; }
        //ViewModels
        public ApplicationViewModel ApplicationViewModel { get; set; }
        //Holders
        public ImageManager ImageManager { get; set; }

        public MainWindow()
        {
            // VS Generated code not included
            ImageManager = new ImageManager();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationData applicationData = new ApplicationData();
            applicationData.UIData = DataGeneration.GenerateUIData();

            ApplicationModel = new ApplicationModel();
            ApplicationModel.ImportData(applicationData);

            ApplicationViewModel = new ApplicationViewModel();
            ApplicationViewModel.ApplyModel(ApplicationModel);
            ApplicationViewControl.DataContext = ApplicationViewModel;

            BaseLogic = new GameLogic();
            Messenger.Default.Register<NewMessage>(this, New);
            Messenger.Default.Register<LoadMessage>(this, Load);
            Messenger.Default.Register<SaveMessage>(this, Save);
            Messenger.Default.Register<QuitMessage>(this, Quit);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // calculates incorrect when window is maximized
            //var t1 = this.ActualWidth - 20;
            //var t2 = this.ActualHeight - 190;
        }

        private void New(NewMessage msg)
        {
            HexMapCreationInputDialog dialog = new HexMapCreationInputDialog(
                "Title", "Label", 10, 5);
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ApplicationModel.GameModel.ImportData(DataGeneration.GenerateGameData(dialog.Result.Item1, dialog.Result.Item2));
                ApplicationViewModel.GameViewModel.ApplyModel(ApplicationModel.GameModel);
            }
        }

        private void Load(LoadMessage msg)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Xml files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            try
            {
                // Process input if the user clicked OK.
                if (userClickedOK == true)
                {
                    // Open the selected file to read.
                    System.IO.Stream fileStream = openFileDialog1.OpenFile();

                    XmlSerializer xs = new XmlSerializer(typeof(GameData));
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                    {
                        ApplicationModel.GameModel.ImportData((GameData)xs.Deserialize(reader));
                        ApplicationViewModel.GameViewModel.ApplyModel(ApplicationModel.GameModel);
                    }
                    fileStream.Close();
                }
            }
            catch (Exception e)
            {
            }
            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
        }

        private void Save(SaveMessage msg)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Xml files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            var showDialog = saveFileDialog1.ShowDialog();

            if (showDialog != null && showDialog.Value)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    XmlSerializer xs = new XmlSerializer(typeof(GameData));
                    TextWriter tw = new StreamWriter(myStream);
                    xs.Serialize(tw, SaveHelper.SaveGameModel(ApplicationModel.GameModel));
                    myStream.Close();
                }
            }
        }

        private void Quit(QuitMessage msg)
        {
            this.Close();
        }
    }
}