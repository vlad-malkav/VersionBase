using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VersionBase.Forms
{
    public partial class HexMapCreationInputDialog : Form
    {
        int _inputIntColums;
        int _inputIntRows;

        public Tuple<int,int> Result
        {
            get { return new Tuple<int, int>(_inputIntColums, _inputIntRows); }
            private set { _inputIntColums = value.Item1; _inputIntRows = value.Item2; }
        }

        public HexMapCreationInputDialog(string title, string labelText, int defaultColumns, int defaultRows)
        {
            InitializeComponent();
            this.Text = title;
            this.txtInputColumns.Text = defaultColumns.ToString();
            this.txtInputRows.Text = defaultRows.ToString();
        }

        public HexMapCreationInputDialog()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInputColumns.Text.Trim().Length > 0
                && int.TryParse(txtInputColumns.Text.Trim(), out int colums)
                && txtInputRows.Text.Trim().Length > 0
                && int.TryParse(txtInputRows.Text.Trim(), out int rows))
            {
                btnOk.Enabled = true;
            }
            else
            {
                btnOk.Enabled = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strColumns = txtInputColumns.Text.Trim();
            string strRows = txtInputRows.Text.Trim();
            Result = new Tuple<int, int>(int.Parse(strColumns), int.Parse(strRows));
        }
    }
}
