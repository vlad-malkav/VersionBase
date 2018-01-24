namespace VersionBase.Forms
{
    partial class HexMapCreationInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblInputColumns = new System.Windows.Forms.Label();
            this.txtInputColumns = new System.Windows.Forms.TextBox();
            this.lblInputRows = new System.Windows.Forms.Label();
            this.txtInputRows = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tblLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 4;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayout.Controls.Add(this.lblInputColumns, 0, 0);
            this.tblLayout.Controls.Add(this.txtInputColumns, 1, 0);
            this.tblLayout.Controls.Add(this.lblInputRows, 2, 0);
            this.tblLayout.Controls.Add(this.txtInputRows, 3, 0);
            this.tblLayout.Location = new System.Drawing.Point(12, 12);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(222, 27);
            this.tblLayout.TabIndex = 0;
            // 
            // lblInputColums
            // 
            this.lblInputColumns.AutoSize = true;
            this.lblInputColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputColumns.Location = new System.Drawing.Point(3, 0);
            this.lblInputColumns.Name = "lblInputColums";
            this.lblInputColumns.Size = new System.Drawing.Size(50, 27);
            //this.lblInputColumns.TabIndex = 1;
            this.lblInputColumns.Text = "Colums :";
            this.lblInputColumns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInputColums
            // 
            this.txtInputColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputColumns.Location = new System.Drawing.Point(51, 3);
            this.txtInputColumns.Name = "txtInputColums";
            this.txtInputColumns.Size = new System.Drawing.Size(50, 24);
            this.txtInputColumns.TabIndex = 0;
            this.txtInputColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInputColumns.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // lblInputRows
            // 
            this.lblInputRows.AutoSize = true;
            this.lblInputRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputRows.Location = new System.Drawing.Point(102, 0);
            this.lblInputRows.Name = "lblInputRows";
            this.lblInputRows.Size = new System.Drawing.Size(50, 27);
            //this.lblInputRows.TabIndex = 1;
            this.lblInputRows.Text = "Rows :";
            this.lblInputRows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInputRows
            // 
            this.txtInputRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputRows.Location = new System.Drawing.Point(153, 3);
            this.txtInputRows.Name = "txtInputRows";
            this.txtInputRows.Size = new System.Drawing.Size(50, 24);
            this.txtInputRows.TabIndex = 1;
            this.txtInputRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInputRows.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(127, 48);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(41, 27);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(174, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // HexMapCreationInputDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(243, 85);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tblLayout);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HexMapCreationInputDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Input Dialog";
            this.tblLayout.ResumeLayout(false);
            this.tblLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Label lblInputColumns;
        private System.Windows.Forms.TextBox txtInputColumns;
        private System.Windows.Forms.Label lblInputRows;
        private System.Windows.Forms.TextBox txtInputRows;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}