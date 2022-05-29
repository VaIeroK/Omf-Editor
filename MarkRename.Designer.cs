namespace OMF_Editor
{
    partial class MarkRename
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ButtonLeftRename = new System.Windows.Forms.Button();
            this.ButtonLeft2Rename = new System.Windows.Forms.Button();
            this.ButtonRightRename = new System.Windows.Forms.Button();
            this.ButtonRight2Rename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Yes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "No";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // ButtonLeftRename
            // 
            this.ButtonLeftRename.Location = new System.Drawing.Point(13, 39);
            this.ButtonLeftRename.Name = "ButtonLeftRename";
            this.ButtonLeftRename.Size = new System.Drawing.Size(105, 23);
            this.ButtonLeftRename.TabIndex = 3;
            this.ButtonLeftRename.Tag = "Left";
            this.ButtonLeftRename.Text = "Left";
            this.ButtonLeftRename.UseVisualStyleBackColor = true;
            this.ButtonLeftRename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // ButtonLeft2Rename
            // 
            this.ButtonLeft2Rename.Location = new System.Drawing.Point(124, 38);
            this.ButtonLeft2Rename.Name = "ButtonLeft2Rename";
            this.ButtonLeft2Rename.Size = new System.Drawing.Size(100, 23);
            this.ButtonLeft2Rename.TabIndex = 4;
            this.ButtonLeft2Rename.Tag = "Left2";
            this.ButtonLeft2Rename.Text = "Left2";
            this.ButtonLeft2Rename.UseVisualStyleBackColor = true;
            this.ButtonLeft2Rename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // ButtonRightRename
            // 
            this.ButtonRightRename.Location = new System.Drawing.Point(13, 69);
            this.ButtonRightRename.Name = "ButtonRightRename";
            this.ButtonRightRename.Size = new System.Drawing.Size(105, 23);
            this.ButtonRightRename.TabIndex = 5;
            this.ButtonRightRename.Tag = "Right";
            this.ButtonRightRename.Text = "Right";
            this.ButtonRightRename.UseVisualStyleBackColor = true;
            this.ButtonRightRename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // ButtonRight2Rename
            // 
            this.ButtonRight2Rename.Location = new System.Drawing.Point(124, 69);
            this.ButtonRight2Rename.Name = "ButtonRight2Rename";
            this.ButtonRight2Rename.Size = new System.Drawing.Size(98, 23);
            this.ButtonRight2Rename.TabIndex = 6;
            this.ButtonRight2Rename.Tag = "Right2";
            this.ButtonRight2Rename.Text = "Right2";
            this.ButtonRight2Rename.UseVisualStyleBackColor = true;
            this.ButtonRight2Rename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // MarkRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 142);
            this.Controls.Add(this.ButtonRight2Rename);
            this.Controls.Add(this.ButtonRightRename);
            this.Controls.Add(this.ButtonLeft2Rename);
            this.Controls.Add(this.ButtonLeftRename);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MarkRename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename mark";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ButtonLeftRename;
        private System.Windows.Forms.Button ButtonLeft2Rename;
        private System.Windows.Forms.Button ButtonRightRename;
        private System.Windows.Forms.Button ButtonRight2Rename;
    }
}