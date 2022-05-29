using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace OMF_Editor
{
    public partial class OMF_Editor : Form
    {
        OMFEditor editor = new OMFEditor();

        AnimationsContainer Main_OMF;

        BindingSource bs = new BindingSource();

        string number_mask = "";

        //int StopAtEnd = 1 << 1;
        //int NoMix = 1 << 2;
        //int SyncPart = 1 << 3;
        //int UseFootSteps = 1 << 4;
        //int MoveXForm = 1 << 5;
        //int Idle = 1 << 6;
        //int UseWeaponBone = 1 << 7;

        bool bKeyIsDown = false;
        bool bTextBoxEnabled = false;
        bool bMotMarkPanel = false;

        List<CheckBox> Boxes = new List<CheckBox>();
        List<TextBox> textBoxes = new List<TextBox>();

        ResourceManager rm = new ResourceManager(typeof(OMF_Editor));

        public OMF_Editor()
        {
            InitializeComponent();

            number_mask = @"^[0-9.]*$";
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            InitButtons();

            this.Opacity = 0;

            // Very dirty hack
            if (Environment.GetCommandLineArgs().Length > 1) OpenFile(Environment.GetCommandLineArgs()[1]);

        }

        [DllImport("converter.dll")]
        private static extern int CSharpStartAgent(string path, string out_path, int mode, int convert_to_mode, string motion_list);

        private int RunConverter(string path, string out_path, int mode, int convert_to_mode, string motion_list)
        {
            string dll_path = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\')) + "\\converter.dll";
            if (File.Exists(dll_path))
                return CSharpStartAgent(path, out_path, mode, convert_to_mode, motion_list);
            else
            {
                MessageBox.Show("Can't find converter.dll", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void InitButtons()
        {
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            toolsToolStripMenuItem.Enabled = false;
            showBonePartsToolStripMenuItem.Enabled = false;

            openFileDialog1.Filter = "OMF file|*.omf";
            saveFileDialog1.Filter = saveFileDialog2.Filter = "OMF file|*.omf|Skls file|*.skls|Skl file|*.skl";

            this.Text = "OMF editor " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " [modified version]";

            cloneToolStripMenuItem.Enabled = false;

            Boxes.Add(chbxStopAtEnd);
            Boxes.Add(chbxNoMix);
            Boxes.Add(chbxSyncPart);
            Boxes.Add(chbxUseFootSteps);
            Boxes.Add(chbxMoveXForm);
            Boxes.Add(chbxIdle);
            Boxes.Add(chbxUseWeaponBone);
            Boxes.Add(chbxHasMotionMarks);

            textBoxes.Add(tbxMotName);
            textBoxes.Add(tbxMotSpeed);
            textBoxes.Add(tbxMotPower);
            textBoxes.Add(tbxMotAcc);
            textBoxes.Add(tbxMotFall);
            textBoxes.Add(tbxMotLength);

            DisableInput();
        }

        private void OpenFile(string filename)
        {
            Main_OMF = editor.OpenOMF(filename);

            if (Main_OMF != null)
            {
                bs.DataSource = Main_OMF.AnimsParams;
                lbxMotions.DataSource = bs;
                lbxMotions.DisplayMember = "Name";
                Main_OMF.FileName = filename;

                LabelStatusFile.Text = filename.Substring(filename.LastIndexOf('\\') + 1);
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                toolsToolStripMenuItem.Enabled = true;
                showBonePartsToolStripMenuItem.Enabled = true;
            }
        }

        AnimationsContainer OpenSecondOMF(string filename)
        {
            if (Main_OMF == null) return null;

            AnimationsContainer new_omf = editor.OpenOMF(filename);

            if (new_omf == null) return new_omf;

            if (!editor.CompareOMF(Main_OMF, new_omf))
                return null;
            else
                return new_omf;
        }

        private void UpdateList(bool save_pos = false)
        {
            int pos = lbxMotions.SelectedIndex;
            bs.ResetBindings(false);
            if (save_pos) lbxMotions.SelectedIndex = pos;
            MotionParamsUpdate();
        }

        private void AppendFile(string filename, List<string> list)
        {
            AnimationsContainer new_omf = OpenSecondOMF(filename);
            if (new_omf == null) return;
            editor.CopyAnims(Main_OMF, new_omf, list, chbxAskForOverwrite.Checked);
            UpdateList();
        }

        private void AppendFile(string filename)
        {
            AnimationsContainer new_omf = OpenSecondOMF(filename);
            if (new_omf == null) return;
            editor.CopyAnims(Main_OMF, new_omf, chbxAskForOverwrite.Checked);
            UpdateList();
        }

        private void SwapMarks(string filename, object sender, EventArgs e)
        {
            AnimationsContainer old_omf = Main_OMF;

            try
            {
                OpenFile(openFileDialog1.FileName);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            bool Checked = false;
            bool OverWrite = false;

            for (int i = 0; i < old_omf.Anims.Count; i++) // Проходимся по старому омф
            {
                if (old_omf.AnimsParams[i].MarksCount > 0)     // Если есть моушн марка тогда
                {
                    for (int a = 0; a < Main_OMF.Anims.Count; a++) // Проходимся по текущему
                    {
                        if (old_omf.Anims[i].Name == Main_OMF.Anims[a].Name)
                        {
                            if (!Checked)
                            {
                                OverWrite = MessageBox.Show("Overwrite existing motion marks?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
                                Checked = true;
                            }

                            if (!PodgotovkaIfNotExist(a, sender, e, OverWrite))       // Ставим флаг на марки
                                continue;

                            GetCurrentMotion().m_marks = old_omf.AnimsParams[i].m_marks;
                            GetCurrentMotion().MarksCount = old_omf.AnimsParams[i].MarksCount;

                            MotionMarksGroupUpdate(true);
                        }
                    }
                }
            }
        }

        private void SaveOMF(AnimationsContainer omf_file, string file_name)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(file_name)))
            {
                editor.WriteOMF(writer, omf_file);
            }
        }

        private void SetT0(float t0)
        {
            GetCurrentMotion().m_marks[listMotionMarksGroup.SelectedIndices[0]].m_params[listMotionMarksParams.SelectedIndices[0]].t0 = t0;
        }

        private void SetT1(float t1)
        {
            GetCurrentMotion().m_marks[listMotionMarksGroup.SelectedIndices[0]].m_params[listMotionMarksParams.SelectedIndices[0]].t1 = t1;
        }

        private AnimationParams GetCurrentMotion()
        {
            if (lbxMotions.SelectedIndex != -1)
                return lbxMotions.SelectedItem as AnimationParams;
            else
                return null;
        }

        private AnimVector GetCurrentAnimVector()
        {
            if (lbxMotions.SelectedIndex != -1)
                return Main_OMF.Anims[lbxMotions.SelectedIndex];
            else
                return null;
        }

        private void MotionParamsUpdate(bool dont_reset_pos = false)
        {
            if (GetCurrentMotion() == null) return;

            if (!bTextBoxEnabled) EnableInput();

            tbxMotName.Text = GetCurrentMotion().Name;
            tbxMotSpeed.Text = GetCurrentMotion().Speed.ToString();
            tbxMotPower.Text = GetCurrentMotion().Power.ToString();
            tbxMotAcc.Text = GetCurrentMotion().Accrue.ToString();
            tbxMotFall.Text = GetCurrentMotion().Falloff.ToString();

            float speed = chbxRealTimeLength.Checked ? GetCurrentMotion().Speed : 1.0f;
            float keys_lenght = GetCurrentAnimVector().GetNumKeys() / (radioButtonSeconds.Checked ? 30.0f : 1.0f);
            keys_lenght /= speed;

            if (!radioButtonSeconds.Checked)
                keys_lenght = ((float)Math.Round(keys_lenght, MidpointRounding.AwayFromZero));

            tbxMotLength.Text = keys_lenght.ToString();
            FillFlagsStates();

            CheckMotionMarksAvaiableAndUpdate(dont_reset_pos);
        }

        private void listMotionMarksGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bMotionMarksGroupSelected())
                MotionMarksParamUpdate(listMotionMarksGroup.SelectedIndices[0]);
            else
                MotionMarksParamUpdate(-1);
        }

        private void listMotionMarksParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bMotionMarksGroupSelected() && bMotionMarkSelected())
                MotionMarksParamValuesUpdate(listMotionMarksGroup.SelectedIndices[0], listMotionMarksParams.SelectedIndices[0]);
            else
                MotionMarksParamValuesUpdate(-1, -1);
        }

        private void MotionMarksParamValuesUpdate(int index, int index2)
        {
            if (index != -1 && index2 != -1)
            {
                var currentAnimParams = GetCurrentMotion().m_marks[index].m_params[index2];
                float speed = chbxRealTimeLength.Checked ? GetCurrentMotion().Speed : 1.0f;
                ChangeMarksParamsEditState(true);
                boxStartMotionMark.Text = ((currentAnimParams.t0 * (radioButtonSeconds.Checked ? 1 : 30.0f)) / speed).ToString();
                boxEndMotionMark.Text = ((currentAnimParams.t1 * (radioButtonSeconds.Checked ? 1 : 30.0f)) / speed).ToString();
            }
            else
            {
                ChangeMarksParamsEditState(false);
            }
        }

        private void CheckMotionMarksAvaiableAndUpdate(bool dont_reset_pos = false)
        {
            if (!bMotMarkPanel && chbxHasMotionMarks.Checked)
                ChangeMotionMarksPanelState(true);
            else if (bMotMarkPanel && !chbxHasMotionMarks.Checked)
                ChangeMotionMarksPanelState(false);

            if (!dont_reset_pos) MotionMarkPanelReset();

            MotionMarksGroupUpdate(dont_reset_pos);
        }

        private void MotionMarksGroupUpdate(bool save_pos = false)
        {
            int pos = bMotionMarksGroupSelected() && save_pos ? listMotionMarksGroup.SelectedIndices[0] : 0;

            listMotionMarksGroup.Items.Clear();

            if (GetCurrentMotion().m_marks != null)
            {
                foreach (var mot in GetCurrentMotion().m_marks)
                    listMotionMarksGroup.Items.Add(mot.Name);

                if (listMotionMarksGroup.Items.Count <= pos)
                    pos = 0;

                if (listMotionMarksGroup.Items.Count > 0)
                    listMotionMarksGroup.Items[pos].Selected = true;
            }
        }

        private void MotionMarksParamUpdate(int index, bool save_pos = false)
        {
            int pos = bMotionMarkSelected() && save_pos ? listMotionMarksParams.SelectedIndices[0] : 0;

            listMotionMarksParams.Items.Clear();

            if (index != -1)
            {
                ChangeMarksParamsPanelState(true);

                var currentAnimParams = GetCurrentMotion().m_marks[index].m_params;

                for (int i = 0; i < currentAnimParams.Count; i++)
                {
                    listMotionMarksParams.Items.Add(index + "_mark" + i);
                }

                if (listMotionMarksParams.Items.Count > 0)
                    listMotionMarksParams.Items[pos].Selected = true;
            }
            else
            {
                ChangeMarksParamsPanelState(false);
                listMotionMarksParams_SelectedIndexChanged(null, null);
            }
        }

        private void FillFlagsStates()
        {
            if (Main_OMF == null) return;

            int Flags = GetCurrentMotion().Flags;

            for (int i = 1; i < 8; i++)
            {
                Boxes[i - 1].Checked = (Flags & (1 << i)) == (1 << i);
            }

            chbxHasMotionMarks.Checked = (Main_OMF.GetMotionVersion() == 4 && GetCurrentMotion().m_marks != null);
        }

        private void WriteAllFlags()
        {
            if (Main_OMF == null || !bTextBoxEnabled) return;

            for (int i = 1; i < 8; i++)
            {
                GetCurrentMotion().Flags = BitSet(GetCurrentMotion().Flags, (1 << i), Boxes[i - 1].Checked);
            }
        }

        //Events
        private void TextBoxFilter(object sender, EventArgs e)
        {
            if (Main_OMF == null || !bTextBoxEnabled) return;

            TextBox current = sender as TextBox;

            if (bKeyIsDown)
            {
                if (current.Text.Length == 0)
                    return;

                switch (current.Tag.ToString())
                {
                    case "Speed":
                    case "Power":
                    case "Accrue":
                    case "Falloff":
                        {
                            while (current.Text.Length >= 8)
                            {
                                if (current.SelectionStart < 1)
                                    current.SelectionStart = current.Text.Length;

                                int temp = current.SelectionStart;
                                current.Text = current.Text.Remove(current.Text.Length - 1, 1);
                                current.SelectionStart = temp;
                            }
                        }
                        break;
                    default: break;
                }

                string mask = current.Tag.ToString() == "MotionName" ? @"^[A-Za-z0-9_$]*$" : number_mask;
                Match match = Regex.Match(current.Text, mask);
                if (!match.Success)
                {
                    if (current.SelectionStart < 1)
                        current.SelectionStart = current.Text.Length;

                    int temp = current.SelectionStart;
                    current.Text = current.Text.Remove(current.SelectionStart - 1, 1);
                    current.SelectionStart = temp - 1;
                }
            }

            bKeyIsDown = false;

            int OldSelect = current.SelectionStart;

            try
            {
               Convert.ToSingle(current.Text);
            }
            catch(Exception)
            {
                switch (current.Tag.ToString())
                {
                    case "Speed": current.Text = GetCurrentMotion().Speed.ToString(); current.SelectionStart = current.Text.Length; break;
                    case "Power": current.Text = GetCurrentMotion().Power.ToString(); current.SelectionStart = current.Text.Length; break;
                    case "Accrue": current.Text = GetCurrentMotion().Accrue.ToString(); current.SelectionStart = current.Text.Length; break;
                    case "Falloff": current.Text = GetCurrentMotion().Falloff.ToString(); current.SelectionStart = current.Text.Length; break;
                    default: break;
                }
            }

            switch (current.Tag.ToString())
            {
                case "Speed": GetCurrentMotion().Speed = Convert.ToSingle(current.Text); checkBox1_CheckedChanged_2(sender, e); break;
                case "Power": GetCurrentMotion().Power = Convert.ToSingle(current.Text); break;
                case "Accrue": GetCurrentMotion().Accrue = Convert.ToSingle(current.Text); break;
                case "Falloff": GetCurrentMotion().Falloff = Convert.ToSingle(current.Text); break;
                case "MotionName":
                    {
                        if (GetCurrentMotion().Name == current.Text) return;
                        GetCurrentMotion().Name = current.Text;
                        int index = GetCurrentMotion().MotionID;
                        Main_OMF.Anims[index].Name = current.Text;
                        UpdateList(true);
                    }
                    break;
                default: break;
            }

            if (current.Text.Length > 2)
            {
                if (current.Text[current.Text.Length - 2] != '.' && current.Text[current.Text.Length - 1] != '0')
                    MotionParamsUpdate(true);
            }
            else
            {
                if (current.Text[current.Text.Length - 1] != '.')
                    MotionParamsUpdate(true);
            }

            current.SelectionStart = OldSelect;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string format = Path.GetExtension((sender as SaveFileDialog).FileName);

            if (format == ".omf")
                SaveOMF(Main_OMF, (sender as SaveFileDialog).FileName);
            else if (format == ".skls" || format == ".skl")
            {
                string temp_omf_name = Main_OMF.FileName.Substring(0, Main_OMF.FileName.LastIndexOf('.')) + "_temptemp176.omf";

                AnimationsContainer TempOMF = editor.OpenOMF(Main_OMF.FileName);

                if (File.Exists(temp_omf_name))
                {
                    FileInfo backup_file = new FileInfo(temp_omf_name);
                    backup_file.Delete();
                }

                TempOMF.GunslingerRepair();
                SaveOMF(TempOMF, temp_omf_name);

                RunConverter(temp_omf_name, (sender as SaveFileDialog).FileName, 1, (format == ".skl" ? 0 : 1), "");

                if (File.Exists(temp_omf_name))
                {
                    FileInfo backup_file = new FileInfo(temp_omf_name);
                    backup_file.Delete();
                }
            }
        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string format = Path.GetExtension((sender as SaveFileDialog).FileName);

            AnimationsContainer SelectedAnims = editor.OpenOMF(Main_OMF.FileName);
            AnimationsContainer TempOMF = editor.OpenOMF(Main_OMF.FileName);
            TempOMF.GunslingerRepair();
            SelectedAnims.GunslingerRepair();
            SelectedAnims.Anims.Clear();
            SelectedAnims.AnimsParams.Clear();

            ListBox.SelectedIndexCollection _list = lbxMotions.SelectedIndices;
            int count = _list.Count;

            for (int i = 0; i < count; i++)
            {
                int idx = _list[i];
                SelectedAnims.Anims.Add(TempOMF.Anims[idx]);
                SelectedAnims.AnimsParams.Add(TempOMF.AnimsParams[idx]);
            }

            SelectedAnims.RecalcAllAnimIndex();
            SelectedAnims.RecalcAnimNum();

            if (format == ".omf")
                SaveOMF(SelectedAnims, (sender as SaveFileDialog).FileName);
            else if (format == ".skls" || format == ".skl")
            {
                string temp_omf_name = Main_OMF.FileName.Substring(0, Main_OMF.FileName.LastIndexOf('.')) + "_temptemp176.omf";
                string motion_list = "";

                for (int i = 0; i < count; i++)
                {
                    int idx = _list[i];
                    motion_list += TempOMF.Anims[idx].Name + ",";
                }

                if (File.Exists(temp_omf_name))
                {
                    FileInfo backup_file = new FileInfo(temp_omf_name);
                    backup_file.Delete();
                }

                SaveOMF(SelectedAnims, temp_omf_name);

                RunConverter(temp_omf_name, (sender as SaveFileDialog).FileName, 1, (format == ".skl" ? 0 : 1), motion_list);

                if (File.Exists(temp_omf_name))
                {
                    FileInfo backup_file = new FileInfo(temp_omf_name);
                    backup_file.Delete();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMotions.SelectedIndex == -1) return;

            ListBox.SelectedIndexCollection _list = lbxMotions.SelectedIndices;
            int count = _list.Count;

            while (count > 0)
            {
                int i = _list[count - 1];
                Main_OMF.Anims.RemoveAt(i);
                Main_OMF.AnimsParams.RemoveAt(i);
                --count;
            }

            Main_OMF.RecalcAllAnimIndex();
            Main_OMF.RecalcAnimNum();
            UpdateList();
        }

        private void saveAsSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMotions.SelectedIndex == -1) return;

            saveFileDialog2.FileName = "";
            saveFileDialog2.ShowDialog();
        }

        private int GetAnimNamesCount(string sname)
        {
            int count = 0;
            for (int i = 0; i < Main_OMF.Anims.Count; i++)
            {
                if (Main_OMF.Anims[i].Name == sname)
                    count++;
            }
            return count;
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbxMotions.SelectedIndex == -1) return;

            ListBox.SelectedIndexCollection _list = lbxMotions.SelectedIndices;
            int count = _list.Count;

            while (count > 0)
            {
                int i = _list[count - 1];
                AnimationParams anim_params = new AnimationParams(Main_OMF.AnimsParams[i]);

                AnimVector anim = new AnimVector
                {
                    SectionId = Main_OMF.Anims[i].SectionId,
                    SectionSize = Main_OMF.Anims[i].SectionSize,
                    Name = Main_OMF.Anims[i].Name
                };

                anim.data = Main_OMF.Anims[i].data;
                anim.Name += "_copy";
                anim_params.Name += "_copy";
                string tmp_name = anim.Name;
                int counter = 1;

                if (GetAnimNamesCount(anim.Name) > 0)
                {
                    while (true)
                    {
                        if (GetAnimNamesCount(anim.Name) > 0)
                            tmp_name += counter.ToString();

                        if (GetAnimNamesCount(tmp_name) == 0)
                            break;

                        tmp_name = anim.Name;
                        counter++;
                    }
                    anim.Name += counter.ToString();
                    anim_params.Name += counter.ToString();
                }

                Main_OMF.AddAnim(anim);
                Main_OMF.AddAnimParams(anim_params);
                --count;
            }

            Main_OMF.RecalcAllAnimIndex();
            Main_OMF.RecalcAnimNum();
            UpdateList();
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var index = lbxMotions.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && lbxMotions.SelectedIndices.Contains(index))
            {
                contextMenuStrip1.Show(Cursor.Position);
                deleteToolStripMenuItem.Enabled = lbxMotions.Items.Count > 1;
                cloneToolStripMenuItem.Enabled = lbxMotions.Items.Count > 0;
                contextMenuStrip1.Visible = true;
            }
            else
            {
                contextMenuStrip1.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Main_OMF == null) return;

            WriteAllFlags();

            CheckBox current = sender as CheckBox;
            if (current.Tag.ToString() == "60FPS")
            {
                checkBox1_CheckedChanged_2(sender, e);
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (Main_OMF.Anims.Count > 1)
                    deleteToolStripMenuItem_Click(sender, e);
            }
        }

        private void buttonAddAnims_Click(object sender, EventArgs e)
        {
            AddAnims form = new AddAnims();
            form.Owner = this;
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.Cancel) form.Dispose();
            if (result == DialogResult.OK)
            {
                if (form.richTextBox1.Text == "") return;

                List<string> list = form.richTextBox1.Text.Split('\n').ToList();
                form.Dispose();

                openFileDialog1.FileName = "";
                DialogResult res = openFileDialog1.ShowDialog();

                if (res == DialogResult.OK)
                {
                    try
                    {
                        AppendFile(openFileDialog1.FileName, list);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.ToString());
                    }
                }
            }
        }

        private void buttonRepair_Click(object sender, EventArgs e)
        {
            if (Main_OMF == null) return;

            Main_OMF.GunslingerRepair();
            SaveOMF(Main_OMF, Main_OMF.FileName);
            AutoClosingMessageBox.Show("Repaired and saved!", "", 500, MessageBoxIcon.Information);
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            bKeyIsDown = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                buttonSave_Click(null, null);

            switch (e.KeyData)
            {
                case Keys.F4: loasToolStripMenuItem_Click(null, null); break;
                case Keys.F5: buttonSave_Click(null, null); break;
                case Keys.F6: buttonSaveAs_Click(null, null); break;
            }

            if (e.Control && e.KeyCode == Keys.C && lbxMotions.Focused)
            {
                var selected_indices = lbxMotions.SelectedIndices;

                if (selected_indices.Count == 0) return;

                string clipb = "";

                foreach (int i in selected_indices)
                {
                    clipb += Main_OMF.AnimsParams[i].Name + "\n";
                }

                AutoClosingMessageBox.Show("The animations are copied to the clipboard", "", 1000, MessageBoxIcon.Information);
                Clipboard.SetText(clipb);
            }
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                try
                {
                    AppendFile(openFileDialog1.FileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }

            }
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            if (Main_OMF != null)
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.ShowDialog();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Main_OMF != null)
            {
                SaveOMF(Main_OMF, Main_OMF.FileName);
                AutoClosingMessageBox.Show("Saved!", "", 500, MessageBoxIcon.Information);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bTextBoxEnabled && (lbxMotions.SelectedItems.Count > 1 || Main_OMF == null))
                DisableInput();
            else if (lbxMotions.SelectedItems.Count == 1)
                MotionParamsUpdate();
        }

        private void btnAddMarkGroup_Click(object sender, EventArgs e)
        {
            MotionMark motionMark = new MotionMark();
            motionMark.Name = "NewGroup" + GetCurrentMotion().m_marks.Count;
            motionMark.m_params = new List<MotionMarkParams>();

            MarkRename markRename = new MarkRename(motionMark.Name);
            markRename.ShowDialog();
            if (markRename.res)
                motionMark.Name = markRename.content;

            GetCurrentMotion().m_marks.Add(motionMark);
            GetCurrentMotion().MarksCount += 1;

            MotionMarksGroupUpdate(true);
        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            MotionMarkParams motionMarkParams = new MotionMarkParams();
            motionMarkParams.t1 = (GetCurrentAnimVector().GetNumKeys() / (30.0f));
            GetCurrentMotion().m_marks[listMotionMarksGroup.SelectedIndices[0]].m_params.Add(motionMarkParams);
            GetCurrentMotion().m_marks[listMotionMarksGroup.SelectedIndices[0]].Count += 1;
            MotionMarksParamUpdate(listMotionMarksGroup.SelectedIndices[0], true);
        }

        private void btnDelMarkGroup_Click(object sender, EventArgs e)
        {
            if (!bMotionMarksGroupSelected()) return;

            GetCurrentMotion().m_marks.RemoveAt(listMotionMarksGroup.SelectedIndices[0]);
            GetCurrentMotion().MarksCount -= 1;
            MotionMarksGroupUpdate();

            listMotionMarksGroup_SelectedIndexChanged(null, null);
        }

        private void btnDelMark_Click(object sender, EventArgs e)
        {
            if (!bMotionMarkSelected()) return;

            GetCurrentMotion().m_marks[listMotionMarksGroup.SelectedIndices[0]].m_params.RemoveAt(listMotionMarksParams.SelectedIndices[0]);
            GetCurrentMotion().m_marks[listMotionMarksGroup.SelectedIndices[0]].Count -= 1;
            MotionMarksParamUpdate(listMotionMarksGroup.SelectedIndices[0]);

            listMotionMarksParams_SelectedIndexChanged(null, null);
        }

        private void chbxHasMotionMarks_Click(object sender, EventArgs e)
        {
            if (!chbxHasMotionMarks.Checked)
            {
                if (Main_OMF.GetMotionVersion() != 4)
                {
                    DialogResult result = MessageBox.Show("This operation will update OMF version from v3 to v4", "Upgrade.", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                        Main_OMF.bone_cont.OGF_V = 4;
                    else
                        return;
                }

                chbxHasMotionMarks.Checked = true;
                GetCurrentMotion().m_marks = new List<MotionMark>();

                CheckMotionMarksAvaiableAndUpdate();
            }
            else
            {
                DialogResult result = MessageBox.Show("This operation will delete all existing motion marks. Are you sure?", "Warning!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    chbxHasMotionMarks.Checked = false;
                    GetCurrentMotion().MarksCount = 0;
                    GetCurrentMotion().m_marks = null;

                    CheckMotionMarksAvaiableAndUpdate();
                }
            }
        }

        private void boxMotionMark_TextChanged(object sender, EventArgs e)
        {
            if (Main_OMF == null || !(sender as Control).Enabled) return;

            if (!bMotionMarksGroupSelected() || !bMotionMarkSelected()) return;

            TextBox current = sender as TextBox;

            if (bKeyIsDown)
            {
                Match match = Regex.Match(current.Text, number_mask);
                if (!match.Success)
                {
                    int temp = current.SelectionStart;
                    current.Text = current.Text.Remove(current.SelectionStart - 1, 1);
                    current.SelectionStart = temp - 1;
                }

                float speed = chbxRealTimeLength.Checked ? GetCurrentMotion().Speed : 1.0f;
                float t = radioButtonSeconds.Checked ? 1.0f : 30.0f;

                float ck = 0.0f;

                if (!float.TryParse(boxStartMotionMark.Text, out ck) || !float.TryParse(boxEndMotionMark.Text, out ck))
                {
                    return;
                }

                if (current == boxStartMotionMark)
                    SetT0((Convert.ToSingle(boxStartMotionMark.Text) / t) * speed);
                else
                    SetT1((Convert.ToSingle(boxEndMotionMark.Text) / t) * speed);
            }

            bKeyIsDown = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MotionParamsUpdate(true);
        }

        private void Anim_timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;

            if (this.Opacity >= 1) Anim_timer1.Enabled = false;
        }

        private bool PodgotovkaIfNotExist(int i, object sender, EventArgs e, bool Overwrite)
        {
            lbxMotions.ClearSelected();
            lbxMotions.SelectedIndex = i;

            if (GetCurrentMotion().MarksCount > 0 && !Overwrite)
                return false;

            listMotionMarksParams.Items.Clear();
            if (!chbxHasMotionMarks.Checked) chbxHasMotionMarks_Click(sender, e);

            GetCurrentMotion().m_marks.Clear();
            GetCurrentMotion().MarksCount -= 1;
            MotionMarksGroupUpdate();

            listMotionMarksGroup_SelectedIndexChanged(null, null);

            return true;
        }

        private void listMotionMarksGroup_DoubleClick(object sender, EventArgs e)
        {
            if (listMotionMarksGroup.SelectedItems.Count != 0)
            {
                MarkRename markRename = new MarkRename(listMotionMarksGroup.SelectedItems[0].Text);
                markRename.ShowDialog();
                if (markRename.res == false) return;

                listMotionMarksGroup.SelectedItems[0].Text = markRename.content;

                GetCurrentMotion().m_marks[listMotionMarksGroup.SelectedItems[0].Index].Name = markRename.content;
            }
        }

        private void loasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                try
                {
                    OpenFile(openFileDialog1.FileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "OMF Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void linkLabel1_LinkClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/VaIeroK/Omf-Editor");
        }

        private void swapAnimsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                try
                {
                    SwapMarks(openFileDialog1.FileName, sender, e);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
            }
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (bTextBoxEnabled)
            {
                MotionParamsUpdate(true);
                listMotionMarksParams_SelectedIndexChanged(null, null);
            }
        }

        private void showBonePartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Main_OMF != null)
            {
                BonePartsWindow window = new BonePartsWindow(Main_OMF.bone_cont.parts);
                window.ShowDialog();
            }
        }
    }
}
