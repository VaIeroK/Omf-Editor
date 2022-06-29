using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace OMF_Editor
{
    public class OMFEditor
    {
        public void CopyAnims(AnimationsContainer omf_1, AnimationsContainer omf_2, bool ask_rewrite)
        {
            omf_1.RecalcAnimNum();

            bool Checked = false;
            bool OverWrite = false;

            for (int i = 0; i < omf_1.Anims.Count; i++)
            {
                for (int a = 0; a < omf_2.Anims.Count; a++)
                {
                    if (omf_1.Anims[i].Name == omf_2.Anims[a].Name)
                    {
                        if (!ask_rewrite)
                        {
                            if (!Checked)
                            {
                                OverWrite = MessageBox.Show("Overwrite existing anims?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
                                Checked = true;
                            }
                        }
                        else
                        {
                            OverWrite = MessageBox.Show($"Overwrite [{omf_1.Anims[i].Name}] anim?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
                        }

                        if (OverWrite)
                        {
                            omf_1.Anims.RemoveAt(i);
                            omf_1.AnimsParams.RemoveAt(i);
                        }
                        else
                        {
                            omf_2.Anims.RemoveAt(a);
                            omf_2.AnimsParams.RemoveAt(a);
                        }
                        break;
                    }
                }
            }

            omf_1.RecalcAnimNum();

            short m_index = 0;

            //animSort
            for (int i = 0; i < omf_1.Anims.Count; i++)
            {
                omf_1.AnimsParams[i].MotionID = m_index++;
            }


            for (int i = 0; i < omf_2.Anims.Count; i++)
            {
                omf_1.AddAnim(omf_2.Anims[i]);

                var pipka           = omf_2.AnimsParams[i];
                pipka.MotionID      = (short)omf_1.AnimsParams.Count;
                omf_1.AnimsParams.Add(omf_2.AnimsParams[i]);
            }

            omf_1.RecalcAnimNum();
            omf_1.RecalcAllAnimIndex();
        }

        public void CopyAnims(AnimationsContainer omf_1, AnimationsContainer omf_2, List<string> list, bool ask_rewrite)
        {
            omf_1.RecalcAnimNum();

            bool Checked = false;
            bool OverWrite = false;

            for (int j = 0; j < list.Count; j++)
            {
                for (int i = 0; i < omf_1.Anims.Count; i++)
                {
                    for (int a = 0; a < omf_2.Anims.Count; a++)
                    {
                        if (omf_1.Anims[i].Name == omf_2.Anims[a].Name && omf_1.Anims[i].Name == list[j])
                        {
                            if (!ask_rewrite)
                            {
                                if (!Checked)
                                {
                                    OverWrite = MessageBox.Show("Overwrite existing anims?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
                                    Checked = true;
                                }
                            }
                            else
                            {
                                OverWrite = MessageBox.Show($"Overwrite [{omf_1.Anims[i].Name}] anim?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
                            }

                            if (OverWrite)
                            {
                                omf_1.Anims.RemoveAt(i);
                                omf_1.AnimsParams.RemoveAt(i);
                            }
                            else
                            {
                                omf_2.Anims.RemoveAt(a);
                                omf_2.AnimsParams.RemoveAt(a);
                            }
                            break;
                        }
                    }
                }
            }

            omf_1.RecalcAnimNum();

            short new_count = (short)omf_1.AnimsCount;

            for (int i = 0; i < omf_2.Anims.Count; i++)
            {
                AnimVector anim = omf_2.Anims[i];

                for (int ii = 0; ii < list.Count; ii++)
                {
                    if (anim.MotionName == list[ii])
                    {
                        omf_1.AddAnim(anim);

                        AnimationParams anim_param = omf_2.AnimsParams[i];

                        anim_param.MotionID = new_count;

                        if ((omf_1.bone_cont.OGF_V != omf_2.bone_cont.OGF_V) && omf_1.bone_cont.OGF_V == 3)
                        {
                            anim_param.MarksCount = 0;
                            anim_param.m_marks = null;
                        }

                        omf_1.AddAnimParams(anim_param);
                        new_count++;
                    }
                }
            }

            omf_1.RecalcAnimNum();
            omf_1.RecalcAllAnimIndex();    
        }

        public void WriteOMF(BinaryWriter writer, AnimationsContainer omf_file)
        {
            omf_file.RecalcSectionSize();

            omf_file.WriteAnimationContainer(writer, this);

            omf_file.bone_cont.WriteBoneCont(writer, this);

            writer.Write(omf_file.AnimsParamsCount);

            foreach (AnimationParams anim_param in omf_file.AnimsParams)
                anim_param.WriteAnimationParams(writer, this, omf_file.bone_cont.OGF_V);
        }

        public AnimationsContainer OpenOMF(string filename)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                AnimationsContainer omf_file = new AnimationsContainer(reader, this);
                //Загрузка костей
                omf_file.bone_cont = new BoneContainer(reader, this);
                //Загрузка параметров анимаций
                omf_file.AnimsParamsCount = reader.ReadInt16();

                //Проверка
                if (omf_file.AnimsCount != omf_file.AnimsParamsCount) return null;

                for(int i = 0; i < omf_file.AnimsParamsCount; i++)
                {
                    AnimationParams anm_p = new AnimationParams(reader, this, omf_file.bone_cont.OGF_V);
                    omf_file.AddAnimParams(anm_p);
                }

                return omf_file;
            }
        }

        public bool CompareOMF(AnimationsContainer omf_1, AnimationsContainer omf_2)
        {
            if (omf_1.bone_cont.Count != omf_2.bone_cont.Count)
            {
                if (MessageBox.Show($"Motion skeletons are different - Current: {omf_1.bone_cont.Count}, New: {omf_2.bone_cont.Count}. Continue?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }
            else
            {
                for (int i = 0; i < omf_1.bone_cont.Count; i++)
                {
                    if (omf_1.bone_cont.parts[i].Count != omf_2.bone_cont.parts[i].Count)
                    {
                        MessageBox.Show($"Bones count in partitions are different - Current: {omf_1.bone_cont.parts[i].Count}, New: {omf_2.bone_cont.parts[i].Count}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        for (int b = 0; b < omf_1.bone_cont.parts[i].Count; b++)
                        {
                            if (omf_1.bone_cont.parts[i].bones[b].Name != omf_2.bone_cont.parts[i].bones[b].Name)
                            {
                                MessageBox.Show($"Bone names in partitions are different - Current: {omf_1.bone_cont.parts[i].bones[b].Name}, New: {omf_2.bone_cont.parts[i].bones[b].Name}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                    }
                }
            }

            if (omf_1.bone_cont.OGF_V != omf_2.bone_cont.OGF_V)
            {
                MessageBox.Show($"OMF versions are different - Current: {omf_1.bone_cont.OGF_V}, New: {omf_2.bone_cont.OGF_V}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return true;
        }

        public string ReadSuperString(BinaryReader reader)
        {
            string str = "";

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                byte[] one = { reader.ReadByte() };
                if (one[0] != 0)
                {
                    str += Encoding.Default.GetString(one);
                }
                else
                {
                    break;
                }
            }
            return str;
        }

        public string ReadMotionMarkString(BinaryReader reader)
        {
            string str = "";

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                byte[] one = { reader.ReadByte() };
                if (one[0] != 0xA)
                {
                    str += Encoding.Default.GetString(one);
                }
                else
                {
                    break;
                }
            }
            return str;
        }

        public void WriteSuperString(BinaryWriter writer, string text)
        {
            List<byte> temp = new List<byte>();

            temp.AddRange(Encoding.Default.GetBytes(text));
            temp.Add(0);

            writer.Write(temp.ToArray());
        }

        public void WriteMarkString(BinaryWriter writer, string text)
        {
            List<byte> temp = new List<byte>();

            temp.AddRange(Encoding.Default.GetBytes(text));
            temp.Add((byte)0xA);

            writer.Write(temp.ToArray());
        }
    }
}
