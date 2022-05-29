using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMF_Editor
{
    public partial class BonePartsWindow : Form
    {
        bool bFormatLTX = false;
        List<BoneParts> saved_parts;
        int tab_size = 16;   // 4 tabs
        string sTextFormatReader = "";
        string sTextFormatLTX = "";

        public BonePartsWindow(List<BoneParts> parts)
        {
            InitializeComponent();
            saved_parts = parts;
            PartsTextBox.Text = sTextFormatReader = WritePartsReader(saved_parts);
            sTextFormatLTX = WritePartsLTX(saved_parts);
            ViewModeTextLabel.Text = "Preview";
        }

        private int GetPartTextSize(List<BoneParts> parts)
        {
            string part_name = "partition_name";
            int cnt = part_name.Count() + 8;

            for (int i = 0; i < parts.Count; i++)
            {
                for (int ii = 0; ii < parts[i].bones.Count; ii++)
                {
                    if (cnt < parts[i].bones[ii].Name.Count() + 8)
                        cnt = parts[i].bones[ii].Name.Count() + 8;
                }
            }

            return cnt;
        }

        private string WritePartsReader(List<BoneParts> parts)
        {
            string str = "";
            for (int i = 0; i < parts.Count; i++)
            {
                str += $"[{parts[i].Name}]\n";

                for (int ii = 0; ii < parts[i].bones.Count; ii++)
                    str += parts[i].bones[ii].Name + "\n";

                str += "\n";
            }
            str = str.Remove(str.Count() - 2, 2);

            return str;
        }

        private string WritePartsLTX(List<BoneParts> parts)
        {
            string str = "";
            int needed_size = 0;
            string part_name = "partition_name";
            for (int i = 0; i < 4; i++)
            {
                str += $"[part_{i}]\n";

                if (i >= parts.Count)
                {
                    str += $"        {part_name}";
                    needed_size = GetPartTextSize(parts) + tab_size - part_name.Count() - 1;
                    for (int iii = 0; iii < needed_size; iii++)
                    {
                        str += " ";
                    }
                    str += "=\n\n";
                    continue;
                }

                for (int ii = 0; ii < parts[i].bones.Count; ii++)
                {
                    str += $"        {parts[i].bones[ii].Name}";
                    needed_size = GetPartTextSize(parts) + tab_size - parts[i].bones[ii].Name.Count() - 1;
                    for (int iii = 0; iii < needed_size; iii++)
                    {
                        str += " ";
                    }
                    str += "=\n";
                }

                str += $"        {part_name}";
                needed_size = GetPartTextSize(parts) + tab_size - part_name.Count() - 1;
                for (int iii = 0; iii < needed_size; iii++)
                {
                    str += " ";
                }
                str += $"= {parts[i].Name}\n\n";
            }
            str = str.Remove(str.Count() - 2, 2);

            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PartsTextBox.ResetText();
            bFormatLTX = !bFormatLTX;
            if (bFormatLTX)
            {
                PartsTextBox.Text = sTextFormatLTX;
                ViewModeTextLabel.Text = "Ltx";
            }
            else
            {
                PartsTextBox.Text = sTextFormatReader;
                ViewModeTextLabel.Text = "Preview";
            }
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(PartsTextBox.Text);
        }
    }
}
