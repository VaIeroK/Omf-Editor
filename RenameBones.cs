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
    public partial class RenameBones : Form
    {
		BoneContainer container;
		public RenameBones(BoneContainer cont)
        {
            InitializeComponent();

			container = cont;

			int bone_cnt = 0;

            for (int i = 0; i < cont.parts.Count; i++)
            {
                for (int j = 0; j < cont.parts[i].bones.Count; j++)
                {
                    CreateBoneGroupBox(bone_cnt, i, j, cont.parts[i].bones[j].Name);
					bone_cnt++;
				}
            }
        }

		private void CreateBoneGroupBox(int idx, int part_id, int bone_part_id, string bone_name)
		{
			var GroupBox = new GroupBox();
			GroupBox.Location = new System.Drawing.Point(3, 3 + 45 * idx);
			GroupBox.Size = new System.Drawing.Size(366, 43);
			GroupBox.Text = "Bone id: [" + idx + "]";
			GroupBox.Name = "BoneGrpBox_" + idx;

			CreateBoneTextBox(idx, part_id, bone_part_id, GroupBox, bone_name);
			this.Controls.Add(GroupBox);
		}

		private void CreateBoneTextBox(int idx, int part_id, int bone_part_id, GroupBox box, string bone_name)
		{
			var BoneNameTextBox = new TextBox();
			BoneNameTextBox.Name = "boneBox_" + idx + "-" + bone_part_id;
			BoneNameTextBox.Size = new System.Drawing.Size(275, 58);
			BoneNameTextBox.Location = new System.Drawing.Point(86, 18);
			BoneNameTextBox.Text = bone_name;
			BoneNameTextBox.Tag = part_id;
			BoneNameTextBox.TextChanged += new System.EventHandler(this.TextBoxFilter);

			var BoneNameLabel = new Label();
			BoneNameLabel.Name = "boneLabel_" + idx;
			BoneNameLabel.Size = new System.Drawing.Size(100, 20);
			BoneNameLabel.Location = new System.Drawing.Point(6, 20);
			BoneNameLabel.Text = "Bone Name:";

			box.Controls.Add(BoneNameTextBox);

			box.Controls.Add(BoneNameLabel);
		}

		private void TextBoxFilter(object sender, EventArgs e)
		{
			TextBox curBox = sender as TextBox;

			string currentField = curBox.Name.ToString().Split('_')[0];
			int bone_part_id = Convert.ToInt32(curBox.Name.ToString().Split('-')[1]);

			switch (currentField)
			{
				case "boneBox":
					{
						for (int i = 0; i < container.parts.Count; i++)
						{
							for (int j = 0; j < container.parts[i].bones.Count; j++)
							{
								if (Convert.ToInt32(curBox.Tag) == i && bone_part_id == j)
                                    container.parts[i].bones[j].Name = curBox.Text;
							}
						}
					}
					break;
			}
		}
	}
}
