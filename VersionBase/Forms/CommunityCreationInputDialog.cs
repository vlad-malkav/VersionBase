using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionBase.Libraries.Drawing;
using VersionBase.Models;
using VersionBase.ViewModels;

namespace VersionBase.Forms
{
    public partial class CommunityCreationInputDialog: Form
    {
        private Coordinates Coordinates { get; set; }
        private Coordinates CoordinatesFromCenter { get; set; }
        private Coordinates CoordinatesCellRadiusFromCenter { get; set; }
        public Tuple<CommunityModel, CommunityViewModel> Result { get; set; }
        public bool CanValidate { get; set; }

        public CommunityCreationInputDialog(Coordinates coordinates, Coordinates coordinatesFromCenter, double cellRadius)
        {
            InitializeComponent();
            Coordinates = coordinates;
            CoordinatesFromCenter = coordinatesFromCenter;
            CoordinatesCellRadiusFromCenter = new Coordinates(
                CoordinatesFromCenter.X / cellRadius,
                CoordinatesFromCenter.Y / cellRadius);
            AddButton.Enabled = false;
            this.ActiveControl = TextBoxName;
            TextBoxName.KeyUp += TextBoxKeyUp;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Result = new Tuple<CommunityModel, CommunityViewModel>(
                new CommunityModel(
                    this.CoordinatesCellRadiusFromCenter,
                    this.TextBoxName.Text,
                    this.TextBoxType.Text,
                    this.TextBoxSize.Text,
                    this.TextBoxInhabitants.Text,
                    this.TextBoxDescription.Text),
                new CommunityViewModel(
                Coordinates,
                this.CoordinatesFromCenter,
                this.TextBoxName.Text,
                this.TextBoxType.Text,
                this.TextBoxSize.Text,
                this.TextBoxInhabitants.Text,
                this.TextBoxDescription.Text));
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            CanValidate = !string.IsNullOrEmpty(this.TextBoxName.Text);
            AddButton.Enabled = CanValidate;
        }

        private void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddButton_Click(sender,e);
            }
        }
    }
}
