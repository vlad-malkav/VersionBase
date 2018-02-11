namespace VersionBase.Forms
{
    partial class CommunityCreationInputDialog
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
            this.LabelInputName = new System.Windows.Forms.Label();
            this.LabelInputType = new System.Windows.Forms.Label();
            this.LabelInputSize = new System.Windows.Forms.Label();
            this.LabelInputInhabitants = new System.Windows.Forms.Label();
            this.LabelInputDescription = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.TextBoxType = new System.Windows.Forms.TextBox();
            this.TextBoxSize = new System.Windows.Forms.TextBox();
            this.TextBoxInhabitants = new System.Windows.Forms.TextBox();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelInputName
            // 
            this.LabelInputName.AutoSize = true;
            this.LabelInputName.Location = new System.Drawing.Point(12, 9);
            this.LabelInputName.Name = "LabelInputName";
            this.LabelInputName.Size = new System.Drawing.Size(45, 17);
            this.LabelInputName.TabIndex = 0;
            this.LabelInputName.Text = "Name";
            // 
            // LabelInputType
            // 
            this.LabelInputType.AutoSize = true;
            this.LabelInputType.Location = new System.Drawing.Point(12, 37);
            this.LabelInputType.Name = "LabelInputType";
            this.LabelInputType.Size = new System.Drawing.Size(40, 17);
            this.LabelInputType.TabIndex = 1;
            this.LabelInputType.Text = "Type";
            // 
            // LabelInputSize
            // 
            this.LabelInputSize.AutoSize = true;
            this.LabelInputSize.Location = new System.Drawing.Point(12, 65);
            this.LabelInputSize.Name = "LabelInputSize";
            this.LabelInputSize.Size = new System.Drawing.Size(35, 17);
            this.LabelInputSize.TabIndex = 2;
            this.LabelInputSize.Text = "Size";
            // 
            // LabelInputInhabitants
            // 
            this.LabelInputInhabitants.AutoSize = true;
            this.LabelInputInhabitants.Location = new System.Drawing.Point(12, 93);
            this.LabelInputInhabitants.Name = "LabelInputInhabitants";
            this.LabelInputInhabitants.Size = new System.Drawing.Size(77, 17);
            this.LabelInputInhabitants.TabIndex = 3;
            this.LabelInputInhabitants.Text = "Inhabitants";
            // 
            // LabelInputDescription
            // 
            this.LabelInputDescription.AutoSize = true;
            this.LabelInputDescription.Location = new System.Drawing.Point(12, 121);
            this.LabelInputDescription.Name = "LabelInputDescription";
            this.LabelInputDescription.Size = new System.Drawing.Size(79, 17);
            this.LabelInputDescription.TabIndex = 4;
            this.LabelInputDescription.Text = "Description";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(101, 6);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(257, 22);
            this.TextBoxName.TabIndex = 5;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // TextBoxType
            // 
            this.TextBoxType.Location = new System.Drawing.Point(101, 34);
            this.TextBoxType.Name = "TextBoxType";
            this.TextBoxType.Size = new System.Drawing.Size(257, 22);
            this.TextBoxType.TabIndex = 5;
            // 
            // TextBoxSize
            // 
            this.TextBoxSize.Location = new System.Drawing.Point(101, 62);
            this.TextBoxSize.Name = "TextBoxSize";
            this.TextBoxSize.Size = new System.Drawing.Size(257, 22);
            this.TextBoxSize.TabIndex = 5;
            // 
            // TextBoxInhabitants
            // 
            this.TextBoxInhabitants.Location = new System.Drawing.Point(101, 90);
            this.TextBoxInhabitants.Name = "TextBoxInhabitants";
            this.TextBoxInhabitants.Size = new System.Drawing.Size(257, 22);
            this.TextBoxInhabitants.TabIndex = 5;
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Location = new System.Drawing.Point(101, 118);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(257, 22);
            this.TextBoxDescription.TabIndex = 5;
            // 
            // AddButton
            // 
            this.AddButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddButton.Location = new System.Drawing.Point(59, 167);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(229, 167);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CommunityCreationInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 202);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.TextBoxInhabitants);
            this.Controls.Add(this.TextBoxSize);
            this.Controls.Add(this.TextBoxType);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.LabelInputDescription);
            this.Controls.Add(this.LabelInputInhabitants);
            this.Controls.Add(this.LabelInputSize);
            this.Controls.Add(this.LabelInputType);
            this.Controls.Add(this.LabelInputName);
            this.Name = "CommunityCreationInputDialog";
            this.Text = "CommunityCreationInputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelInputName;
        private System.Windows.Forms.Label LabelInputType;
        private System.Windows.Forms.Label LabelInputSize;
        private System.Windows.Forms.Label LabelInputInhabitants;
        private System.Windows.Forms.Label LabelInputDescription;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.TextBox TextBoxType;
        private System.Windows.Forms.TextBox TextBoxSize;
        private System.Windows.Forms.TextBox TextBoxInhabitants;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
    }
}