namespace OMF_Editor
{
    partial class OMF_Editor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OMF_Editor));
            this.lbxMotions = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupMotionParams = new System.Windows.Forms.GroupBox();
            this.groupMotionTimeFormat = new System.Windows.Forms.GroupBox();
            this.radioButtonKeys = new System.Windows.Forms.RadioButton();
            this.LabelMotionTimeFormat = new System.Windows.Forms.Label();
            this.radioButtonSeconds = new System.Windows.Forms.RadioButton();
            this.tbxMotLength = new System.Windows.Forms.TextBox();
            this.chbxHasMotionMarks = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chbxUseWeaponBone = new System.Windows.Forms.CheckBox();
            this.chbxIdle = new System.Windows.Forms.CheckBox();
            this.chbxMoveXForm = new System.Windows.Forms.CheckBox();
            this.chbxUseFootSteps = new System.Windows.Forms.CheckBox();
            this.chbxSyncPart = new System.Windows.Forms.CheckBox();
            this.chbxNoMix = new System.Windows.Forms.CheckBox();
            this.chbxStopAtEnd = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxMotFall = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxMotAcc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMotPower = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxMotSpeed = new System.Windows.Forms.TextBox();
            this.tbxMotName = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupMotionMarks = new System.Windows.Forms.GroupBox();
            this.btnDelMark = new System.Windows.Forms.Button();
            this.btnAddMark = new System.Windows.Forms.Button();
            this.btnDelMarkGroup = new System.Windows.Forms.Button();
            this.btnAddMarkGroup = new System.Windows.Forms.Button();
            this.listMotionMarksParams = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listMotionMarksGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.boxEndMotionMark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxStartMotionMark = new System.Windows.Forms.TextBox();
            this.Anim_timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAnimsFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tryRepairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapAnimsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelStatusFileText = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelStatusFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupProgramParams = new System.Windows.Forms.GroupBox();
            this.chbxAskForOverwrite = new System.Windows.Forms.CheckBox();
            this.chbxRealTimeLength = new System.Windows.Forms.CheckBox();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.showBonePartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupMotionParams.SuspendLayout();
            this.groupMotionTimeFormat.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupMotionMarks.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupProgramParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxMotions
            // 
            resources.ApplyResources(this.lbxMotions, "lbxMotions");
            this.lbxMotions.FormattingEnabled = true;
            this.lbxMotions.Name = "lbxMotions";
            this.lbxMotions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxMotions.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.lbxMotions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            this.lbxMotions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupMotionParams
            // 
            this.groupMotionParams.Controls.Add(this.groupMotionTimeFormat);
            this.groupMotionParams.Controls.Add(this.tbxMotLength);
            this.groupMotionParams.Controls.Add(this.chbxHasMotionMarks);
            this.groupMotionParams.Controls.Add(this.label9);
            this.groupMotionParams.Controls.Add(this.chbxUseWeaponBone);
            this.groupMotionParams.Controls.Add(this.chbxIdle);
            this.groupMotionParams.Controls.Add(this.chbxMoveXForm);
            this.groupMotionParams.Controls.Add(this.chbxUseFootSteps);
            this.groupMotionParams.Controls.Add(this.chbxSyncPart);
            this.groupMotionParams.Controls.Add(this.chbxNoMix);
            this.groupMotionParams.Controls.Add(this.chbxStopAtEnd);
            this.groupMotionParams.Controls.Add(this.label6);
            this.groupMotionParams.Controls.Add(this.tbxMotFall);
            this.groupMotionParams.Controls.Add(this.label5);
            this.groupMotionParams.Controls.Add(this.tbxMotAcc);
            this.groupMotionParams.Controls.Add(this.label4);
            this.groupMotionParams.Controls.Add(this.tbxMotPower);
            this.groupMotionParams.Controls.Add(this.label3);
            this.groupMotionParams.Controls.Add(this.tbxMotSpeed);
            this.groupMotionParams.Controls.Add(this.label1);
            this.groupMotionParams.Controls.Add(this.tbxMotName);
            resources.ApplyResources(this.groupMotionParams, "groupMotionParams");
            this.groupMotionParams.Name = "groupMotionParams";
            this.groupMotionParams.TabStop = false;
            // 
            // groupMotionTimeFormat
            // 
            this.groupMotionTimeFormat.Controls.Add(this.radioButtonKeys);
            this.groupMotionTimeFormat.Controls.Add(this.LabelMotionTimeFormat);
            this.groupMotionTimeFormat.Controls.Add(this.radioButtonSeconds);
            resources.ApplyResources(this.groupMotionTimeFormat, "groupMotionTimeFormat");
            this.groupMotionTimeFormat.Name = "groupMotionTimeFormat";
            this.groupMotionTimeFormat.TabStop = false;
            // 
            // radioButtonKeys
            // 
            resources.ApplyResources(this.radioButtonKeys, "radioButtonKeys");
            this.radioButtonKeys.Name = "radioButtonKeys";
            this.radioButtonKeys.UseVisualStyleBackColor = true;
            this.radioButtonKeys.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // LabelMotionTimeFormat
            // 
            resources.ApplyResources(this.LabelMotionTimeFormat, "LabelMotionTimeFormat");
            this.LabelMotionTimeFormat.Name = "LabelMotionTimeFormat";
            // 
            // radioButtonSeconds
            // 
            resources.ApplyResources(this.radioButtonSeconds, "radioButtonSeconds");
            this.radioButtonSeconds.Checked = true;
            this.radioButtonSeconds.Name = "radioButtonSeconds";
            this.radioButtonSeconds.TabStop = true;
            this.radioButtonSeconds.UseVisualStyleBackColor = true;
            this.radioButtonSeconds.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tbxMotLength
            // 
            resources.ApplyResources(this.tbxMotLength, "tbxMotLength");
            this.tbxMotLength.Name = "tbxMotLength";
            this.tbxMotLength.ReadOnly = true;
            this.tbxMotLength.Tag = "Length";
            // 
            // chbxHasMotionMarks
            // 
            this.chbxHasMotionMarks.AutoCheck = false;
            resources.ApplyResources(this.chbxHasMotionMarks, "chbxHasMotionMarks");
            this.chbxHasMotionMarks.Name = "chbxHasMotionMarks";
            this.chbxHasMotionMarks.Tag = "";
            this.chbxHasMotionMarks.UseVisualStyleBackColor = true;
            this.chbxHasMotionMarks.Click += new System.EventHandler(this.chbxHasMotionMarks_Click);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // chbxUseWeaponBone
            // 
            resources.ApplyResources(this.chbxUseWeaponBone, "chbxUseWeaponBone");
            this.chbxUseWeaponBone.Name = "chbxUseWeaponBone";
            this.chbxUseWeaponBone.Tag = "UseWeaponBone";
            this.chbxUseWeaponBone.UseVisualStyleBackColor = true;
            this.chbxUseWeaponBone.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chbxIdle
            // 
            resources.ApplyResources(this.chbxIdle, "chbxIdle");
            this.chbxIdle.Name = "chbxIdle";
            this.chbxIdle.Tag = "Idle";
            this.chbxIdle.UseVisualStyleBackColor = true;
            this.chbxIdle.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chbxMoveXForm
            // 
            resources.ApplyResources(this.chbxMoveXForm, "chbxMoveXForm");
            this.chbxMoveXForm.Name = "chbxMoveXForm";
            this.chbxMoveXForm.Tag = "Move XForm";
            this.chbxMoveXForm.UseVisualStyleBackColor = true;
            this.chbxMoveXForm.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chbxUseFootSteps
            // 
            resources.ApplyResources(this.chbxUseFootSteps, "chbxUseFootSteps");
            this.chbxUseFootSteps.Name = "chbxUseFootSteps";
            this.chbxUseFootSteps.Tag = "UseFootSteps";
            this.chbxUseFootSteps.UseVisualStyleBackColor = true;
            this.chbxUseFootSteps.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chbxSyncPart
            // 
            resources.ApplyResources(this.chbxSyncPart, "chbxSyncPart");
            this.chbxSyncPart.Name = "chbxSyncPart";
            this.chbxSyncPart.Tag = "Sync Part";
            this.chbxSyncPart.UseVisualStyleBackColor = true;
            this.chbxSyncPart.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chbxNoMix
            // 
            resources.ApplyResources(this.chbxNoMix, "chbxNoMix");
            this.chbxNoMix.Name = "chbxNoMix";
            this.chbxNoMix.Tag = "No Mix";
            this.chbxNoMix.UseVisualStyleBackColor = true;
            this.chbxNoMix.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chbxStopAtEnd
            // 
            resources.ApplyResources(this.chbxStopAtEnd, "chbxStopAtEnd");
            this.chbxStopAtEnd.Name = "chbxStopAtEnd";
            this.chbxStopAtEnd.Tag = "Stop At End";
            this.chbxStopAtEnd.UseVisualStyleBackColor = true;
            this.chbxStopAtEnd.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tbxMotFall
            // 
            resources.ApplyResources(this.tbxMotFall, "tbxMotFall");
            this.tbxMotFall.Name = "tbxMotFall";
            this.tbxMotFall.Tag = "Falloff";
            this.tbxMotFall.TextChanged += new System.EventHandler(this.TextBoxFilter);
            this.tbxMotFall.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tbxMotAcc
            // 
            resources.ApplyResources(this.tbxMotAcc, "tbxMotAcc");
            this.tbxMotAcc.Name = "tbxMotAcc";
            this.tbxMotAcc.Tag = "Accrue";
            this.tbxMotAcc.TextChanged += new System.EventHandler(this.TextBoxFilter);
            this.tbxMotAcc.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tbxMotPower
            // 
            resources.ApplyResources(this.tbxMotPower, "tbxMotPower");
            this.tbxMotPower.Name = "tbxMotPower";
            this.tbxMotPower.Tag = "Power";
            this.tbxMotPower.TextChanged += new System.EventHandler(this.TextBoxFilter);
            this.tbxMotPower.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbxMotSpeed
            // 
            resources.ApplyResources(this.tbxMotSpeed, "tbxMotSpeed");
            this.tbxMotSpeed.Name = "tbxMotSpeed";
            this.tbxMotSpeed.Tag = "Speed";
            this.tbxMotSpeed.TextChanged += new System.EventHandler(this.TextBoxFilter);
            this.tbxMotSpeed.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // tbxMotName
            // 
            resources.ApplyResources(this.tbxMotName, "tbxMotName");
            this.tbxMotName.Name = "tbxMotName";
            this.tbxMotName.Tag = "MotionName";
            this.tbxMotName.TextChanged += new System.EventHandler(this.TextBoxFilter);
            this.tbxMotName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cloneToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.saveAsSelectedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            resources.ApplyResources(this.cloneToolStripMenuItem, "cloneToolStripMenuItem");
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // saveAsSelectedToolStripMenuItem
            // 
            this.saveAsSelectedToolStripMenuItem.Name = "saveAsSelectedToolStripMenuItem";
            resources.ApplyResources(this.saveAsSelectedToolStripMenuItem, "saveAsSelectedToolStripMenuItem");
            this.saveAsSelectedToolStripMenuItem.Click += new System.EventHandler(this.saveAsSelectedToolStripMenuItem_Click);
            // 
            // groupMotionMarks
            // 
            this.groupMotionMarks.Controls.Add(this.btnDelMark);
            this.groupMotionMarks.Controls.Add(this.btnAddMark);
            this.groupMotionMarks.Controls.Add(this.btnDelMarkGroup);
            this.groupMotionMarks.Controls.Add(this.btnAddMarkGroup);
            this.groupMotionMarks.Controls.Add(this.listMotionMarksParams);
            this.groupMotionMarks.Controls.Add(this.listMotionMarksGroup);
            this.groupMotionMarks.Controls.Add(this.label7);
            this.groupMotionMarks.Controls.Add(this.boxEndMotionMark);
            this.groupMotionMarks.Controls.Add(this.label8);
            this.groupMotionMarks.Controls.Add(this.boxStartMotionMark);
            resources.ApplyResources(this.groupMotionMarks, "groupMotionMarks");
            this.groupMotionMarks.Name = "groupMotionMarks";
            this.groupMotionMarks.TabStop = false;
            // 
            // btnDelMark
            // 
            resources.ApplyResources(this.btnDelMark, "btnDelMark");
            this.btnDelMark.Name = "btnDelMark";
            this.btnDelMark.UseVisualStyleBackColor = true;
            this.btnDelMark.Click += new System.EventHandler(this.btnDelMark_Click);
            // 
            // btnAddMark
            // 
            resources.ApplyResources(this.btnAddMark, "btnAddMark");
            this.btnAddMark.Name = "btnAddMark";
            this.btnAddMark.UseVisualStyleBackColor = true;
            this.btnAddMark.Click += new System.EventHandler(this.btnAddMark_Click);
            // 
            // btnDelMarkGroup
            // 
            resources.ApplyResources(this.btnDelMarkGroup, "btnDelMarkGroup");
            this.btnDelMarkGroup.Name = "btnDelMarkGroup";
            this.btnDelMarkGroup.UseVisualStyleBackColor = true;
            this.btnDelMarkGroup.Click += new System.EventHandler(this.btnDelMarkGroup_Click);
            // 
            // btnAddMarkGroup
            // 
            resources.ApplyResources(this.btnAddMarkGroup, "btnAddMarkGroup");
            this.btnAddMarkGroup.Name = "btnAddMarkGroup";
            this.btnAddMarkGroup.UseVisualStyleBackColor = true;
            this.btnAddMarkGroup.Click += new System.EventHandler(this.btnAddMarkGroup_Click);
            // 
            // listMotionMarksParams
            // 
            resources.ApplyResources(this.listMotionMarksParams, "listMotionMarksParams");
            this.listMotionMarksParams.AutoArrange = false;
            this.listMotionMarksParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listMotionMarksParams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listMotionMarksParams.HideSelection = false;
            this.listMotionMarksParams.MultiSelect = false;
            this.listMotionMarksParams.Name = "listMotionMarksParams";
            this.listMotionMarksParams.ShowGroups = false;
            this.listMotionMarksParams.UseCompatibleStateImageBehavior = false;
            this.listMotionMarksParams.View = System.Windows.Forms.View.Details;
            this.listMotionMarksParams.SelectedIndexChanged += new System.EventHandler(this.listMotionMarksParams_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // listMotionMarksGroup
            // 
            resources.ApplyResources(this.listMotionMarksGroup, "listMotionMarksGroup");
            this.listMotionMarksGroup.AutoArrange = false;
            this.listMotionMarksGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listMotionMarksGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listMotionMarksGroup.HideSelection = false;
            this.listMotionMarksGroup.MultiSelect = false;
            this.listMotionMarksGroup.Name = "listMotionMarksGroup";
            this.listMotionMarksGroup.ShowGroups = false;
            this.listMotionMarksGroup.UseCompatibleStateImageBehavior = false;
            this.listMotionMarksGroup.View = System.Windows.Forms.View.Details;
            this.listMotionMarksGroup.SelectedIndexChanged += new System.EventHandler(this.listMotionMarksGroup_SelectedIndexChanged);
            this.listMotionMarksGroup.DoubleClick += new System.EventHandler(this.listMotionMarksGroup_DoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // boxEndMotionMark
            // 
            resources.ApplyResources(this.boxEndMotionMark, "boxEndMotionMark");
            this.boxEndMotionMark.Name = "boxEndMotionMark";
            this.boxEndMotionMark.Tag = "Power";
            this.boxEndMotionMark.TextChanged += new System.EventHandler(this.boxMotionMark_TextChanged);
            this.boxEndMotionMark.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // boxStartMotionMark
            // 
            resources.ApplyResources(this.boxStartMotionMark, "boxStartMotionMark");
            this.boxStartMotionMark.Name = "boxStartMotionMark";
            this.boxStartMotionMark.Tag = "Speed";
            this.boxStartMotionMark.TextChanged += new System.EventHandler(this.boxMotionMark_TextChanged);
            this.boxStartMotionMark.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // Anim_timer1
            // 
            this.Anim_timer1.Enabled = true;
            this.Anim_timer1.Interval = 20;
            this.Anim_timer1.Tick += new System.EventHandler(this.Anim_timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.showBonePartsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loasToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // loasToolStripMenuItem
            // 
            this.loasToolStripMenuItem.Name = "loasToolStripMenuItem";
            resources.ApplyResources(this.loasToolStripMenuItem, "loasToolStripMenuItem");
            this.loasToolStripMenuItem.Click += new System.EventHandler(this.loasToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergeWithToolStripMenuItem,
            this.addAnimsFromToolStripMenuItem,
            this.tryRepairToolStripMenuItem,
            this.swapAnimsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // mergeWithToolStripMenuItem
            // 
            this.mergeWithToolStripMenuItem.Name = "mergeWithToolStripMenuItem";
            resources.ApplyResources(this.mergeWithToolStripMenuItem, "mergeWithToolStripMenuItem");
            this.mergeWithToolStripMenuItem.Click += new System.EventHandler(this.buttonMerge_Click);
            // 
            // addAnimsFromToolStripMenuItem
            // 
            this.addAnimsFromToolStripMenuItem.Name = "addAnimsFromToolStripMenuItem";
            resources.ApplyResources(this.addAnimsFromToolStripMenuItem, "addAnimsFromToolStripMenuItem");
            this.addAnimsFromToolStripMenuItem.Click += new System.EventHandler(this.buttonAddAnims_Click);
            // 
            // tryRepairToolStripMenuItem
            // 
            this.tryRepairToolStripMenuItem.Name = "tryRepairToolStripMenuItem";
            resources.ApplyResources(this.tryRepairToolStripMenuItem, "tryRepairToolStripMenuItem");
            this.tryRepairToolStripMenuItem.Click += new System.EventHandler(this.buttonRepair_Click);
            // 
            // swapAnimsToolStripMenuItem
            // 
            this.swapAnimsToolStripMenuItem.Name = "swapAnimsToolStripMenuItem";
            resources.ApplyResources(this.swapAnimsToolStripMenuItem, "swapAnimsToolStripMenuItem");
            this.swapAnimsToolStripMenuItem.Click += new System.EventHandler(this.swapAnimsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSourceCodeToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // openSourceCodeToolStripMenuItem
            // 
            this.openSourceCodeToolStripMenuItem.Name = "openSourceCodeToolStripMenuItem";
            resources.ApplyResources(this.openSourceCodeToolStripMenuItem, "openSourceCodeToolStripMenuItem");
            this.openSourceCodeToolStripMenuItem.Click += new System.EventHandler(this.linkLabel1_LinkClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatusFileText,
            this.LabelStatusFile});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // LabelStatusFileText
            // 
            this.LabelStatusFileText.Name = "LabelStatusFileText";
            resources.ApplyResources(this.LabelStatusFileText, "LabelStatusFileText");
            // 
            // LabelStatusFile
            // 
            this.LabelStatusFile.Name = "LabelStatusFile";
            resources.ApplyResources(this.LabelStatusFile, "LabelStatusFile");
            // 
            // groupProgramParams
            // 
            this.groupProgramParams.Controls.Add(this.chbxAskForOverwrite);
            this.groupProgramParams.Controls.Add(this.chbxRealTimeLength);
            resources.ApplyResources(this.groupProgramParams, "groupProgramParams");
            this.groupProgramParams.Name = "groupProgramParams";
            this.groupProgramParams.TabStop = false;
            // 
            // chbxAskForOverwrite
            // 
            resources.ApplyResources(this.chbxAskForOverwrite, "chbxAskForOverwrite");
            this.chbxAskForOverwrite.Name = "chbxAskForOverwrite";
            this.chbxAskForOverwrite.Tag = "Ask for overwrite";
            this.chbxAskForOverwrite.UseVisualStyleBackColor = true;
            // 
            // chbxRealTimeLength
            // 
            resources.ApplyResources(this.chbxRealTimeLength, "chbxRealTimeLength");
            this.chbxRealTimeLength.Name = "chbxRealTimeLength";
            this.chbxRealTimeLength.Tag = "Real time length";
            this.chbxRealTimeLength.UseVisualStyleBackColor = true;
            this.chbxRealTimeLength.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
            // 
            // showBonePartsToolStripMenuItem
            // 
            this.showBonePartsToolStripMenuItem.Name = "showBonePartsToolStripMenuItem";
            resources.ApplyResources(this.showBonePartsToolStripMenuItem, "showBonePartsToolStripMenuItem");
            this.showBonePartsToolStripMenuItem.Click += new System.EventHandler(this.showBonePartsToolStripMenuItem_Click);
            // 
            // OMF_Editor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupProgramParams);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupMotionMarks);
            this.Controls.Add(this.lbxMotions);
            this.Controls.Add(this.groupMotionParams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "OMF_Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupMotionParams.ResumeLayout(false);
            this.groupMotionParams.PerformLayout();
            this.groupMotionTimeFormat.ResumeLayout(false);
            this.groupMotionTimeFormat.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupMotionMarks.ResumeLayout(false);
            this.groupMotionMarks.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupProgramParams.ResumeLayout(false);
            this.groupProgramParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMotions;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupMotionParams;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxMotFall;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxMotAcc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMotPower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMotSpeed;
        private System.Windows.Forms.TextBox tbxMotName;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.CheckBox chbxUseWeaponBone;
        private System.Windows.Forms.CheckBox chbxIdle;
        private System.Windows.Forms.CheckBox chbxMoveXForm;
        private System.Windows.Forms.CheckBox chbxUseFootSteps;
        private System.Windows.Forms.CheckBox chbxSyncPart;
        private System.Windows.Forms.CheckBox chbxNoMix;
        private System.Windows.Forms.CheckBox chbxStopAtEnd;
		private System.Windows.Forms.CheckBox chbxHasMotionMarks;
		private System.Windows.Forms.GroupBox groupMotionMarks;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox boxEndMotionMark;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox boxStartMotionMark;
		private System.Windows.Forms.ListView listMotionMarksGroup;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listMotionMarksParams;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnDelMark;
		private System.Windows.Forms.Button btnAddMark;
		private System.Windows.Forms.Button btnAddMarkGroup;
		private System.Windows.Forms.Button btnDelMarkGroup;
		private System.Windows.Forms.GroupBox groupMotionTimeFormat;
		private System.Windows.Forms.RadioButton radioButtonKeys;
		private System.Windows.Forms.Label LabelMotionTimeFormat;
		private System.Windows.Forms.RadioButton radioButtonSeconds;
		private System.Windows.Forms.TextBox tbxMotLength;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer Anim_timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeWithToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAnimsFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tryRepairToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatusFileText;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatusFile;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSourceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swapAnimsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupProgramParams;
        private System.Windows.Forms.CheckBox chbxRealTimeLength;
        private System.Windows.Forms.CheckBox chbxAskForOverwrite;
        private System.Windows.Forms.ToolStripMenuItem saveAsSelectedToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem showBonePartsToolStripMenuItem;
    }
}

