namespace OMF_Editor
{
    partial class BonePartsWindow
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
            this.PartsTextBox = new System.Windows.Forms.RichTextBox();
            this.ButtonFormat = new System.Windows.Forms.Button();
            this.ButtonCopy = new System.Windows.Forms.Button();
            this.ViewModeLabel = new System.Windows.Forms.Label();
            this.ViewModeTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PartsTextBox
            // 
            this.PartsTextBox.Location = new System.Drawing.Point(12, 24);
            this.PartsTextBox.Name = "PartsTextBox";
            this.PartsTextBox.ReadOnly = true;
            this.PartsTextBox.Size = new System.Drawing.Size(280, 432);
            this.PartsTextBox.TabIndex = 0;
            this.PartsTextBox.Text = "";
            // 
            // ButtonFormat
            // 
            this.ButtonFormat.Location = new System.Drawing.Point(13, 463);
            this.ButtonFormat.Name = "ButtonFormat";
            this.ButtonFormat.Size = new System.Drawing.Size(134, 28);
            this.ButtonFormat.TabIndex = 1;
            this.ButtonFormat.Text = "Change Format";
            this.ButtonFormat.UseVisualStyleBackColor = true;
            this.ButtonFormat.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonCopy
            // 
            this.ButtonCopy.Location = new System.Drawing.Point(158, 462);
            this.ButtonCopy.Name = "ButtonCopy";
            this.ButtonCopy.Size = new System.Drawing.Size(134, 28);
            this.ButtonCopy.TabIndex = 2;
            this.ButtonCopy.Text = "Copy";
            this.ButtonCopy.UseVisualStyleBackColor = true;
            this.ButtonCopy.Click += new System.EventHandler(this.ButtonCopy_Click);
            // 
            // ViewModeLabel
            // 
            this.ViewModeLabel.AutoSize = true;
            this.ViewModeLabel.Location = new System.Drawing.Point(12, 5);
            this.ViewModeLabel.Name = "ViewModeLabel";
            this.ViewModeLabel.Size = new System.Drawing.Size(65, 13);
            this.ViewModeLabel.TabIndex = 3;
            this.ViewModeLabel.Text = "View mode: ";
            // 
            // ViewModeTextLabel
            // 
            this.ViewModeTextLabel.AutoSize = true;
            this.ViewModeTextLabel.Location = new System.Drawing.Point(72, 5);
            this.ViewModeTextLabel.Name = "ViewModeTextLabel";
            this.ViewModeTextLabel.Size = new System.Drawing.Size(10, 13);
            this.ViewModeTextLabel.TabIndex = 4;
            this.ViewModeTextLabel.Text = "-";
            // 
            // BonePartsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 503);
            this.Controls.Add(this.ViewModeTextLabel);
            this.Controls.Add(this.ViewModeLabel);
            this.Controls.Add(this.ButtonCopy);
            this.Controls.Add(this.ButtonFormat);
            this.Controls.Add(this.PartsTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BonePartsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bone Parts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox PartsTextBox;
        private System.Windows.Forms.Button ButtonFormat;
        private System.Windows.Forms.Button ButtonCopy;
        private System.Windows.Forms.Label ViewModeLabel;
        private System.Windows.Forms.Label ViewModeTextLabel;
    }
}