using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OMF_Editor
{
    public class AnimationsContainer
    {
        public int SectionId;
        public uint SectionSize;

        public int SectionId2;
        public uint SectionSize2;

        public int AnimsCount;
        public short AnimsParamsCount;

        public string FileName;

        public List<AnimVector> Anims = new List<AnimVector>();
        public List<AnimationParams> AnimsParams = new List<AnimationParams>();

        public void RecalcSectionSize()
        {
            uint new_size = 0;
            foreach (AnimVector anim in Anims)
            {
                anim.RecalcSectionSize();
                new_size += anim.GetSize();
            }
            new_size += 12;
            SectionSize = new_size;

            // Recalc second section size
            new_size = 4;

            new_size += (uint)bone_cont.Size();

            new_size += 2;

            foreach (AnimationParams anim in AnimsParams)
            {
                new_size += (uint)anim.Name.Length + 1;
                new_size += 4;
                new_size += 2;
                new_size += 2;
                new_size += 4;
                new_size += 4;
                new_size += 4;
                new_size += 4;

                if (bone_cont.OGF_V >= 4)
                {
                    new_size += 4;

                    if (anim.m_marks != null && anim.m_marks.Count > 0)
                    {
                        foreach (MotionMark mark in anim.m_marks)
                        {
                            new_size += (uint)mark.Name.Length + 1;
                            new_size += 4;

                            foreach (MotionMarkParams param in mark.m_params)
                            {
                                new_size += 4;
                                new_size += 4;
                            }
                        }
                    }
                }
            }

            bone_cont.SectionSize = new_size;
        }

        public string GetFileName()
        {
            return Path.GetFileNameWithoutExtension(FileName);
        }

        public void RecalcAnimNum()
        {
            AnimsCount = AnimsParams.Count;
            AnimsParamsCount = (short)AnimsParams.Count;
        }

        public void RecalcAllAnimIndex()
        {
            short i = 0;
            foreach(AnimationParams anm in AnimsParams)
            {
                anm.MotionID = i;
                i++;
            }
            i = 1;
            foreach (AnimVector anm in Anims)
            {
                anm.SectionId = i;
                i++;
            }
        }

        public void GunslingerRepair()
        {
            short i = 0;
            foreach (AnimationParams anm in AnimsParams)
            {
                anm.MotionID = i;
                i++;
            }
            i = 1;
            foreach (AnimVector anm in Anims)
            {
                anm.Name = AnimsParams[i - 1].Name;
                anm.SectionId = i;
                i++;
            }
        }

        public BoneContainer bone_cont;

        public void AddAnim(AnimVector vector)
        {
            Anims.Add(vector);
        }

        public void AddAnimParams(AnimationParams param)
        {
            AnimsParams.Add(param);
        }
        
        public short GetMotionVersion()
        {
            return bone_cont.OGF_V;
        }

        public AnimationsContainer(BinaryReader reader, OMFEditor editor)
        {
            SectionId = reader.ReadInt32();
            SectionSize = reader.ReadUInt32();

            SectionId2 = reader.ReadInt32();
            SectionSize2 = reader.ReadUInt32();

            AnimsCount = reader.ReadInt32();

            int count = AnimsCount;

            for (int i = 0; i < count; i++)
            {
                AnimVector vector = new AnimVector
                {
                    SectionId = reader.ReadInt32(),
                    SectionSize = reader.ReadUInt32(),
                    Name = editor.ReadSuperString(reader)
                };

                int size = (int)vector.SectionSize - (vector.Name.Length + 1);

                vector.data = reader.ReadBytes(size);

                AddAnim(vector);
            }
        }

        public void WriteAnimationContainer(BinaryWriter writer, OMFEditor editor)
        {
            writer.Write(SectionId);
            writer.Write(SectionSize);

            writer.Write(SectionId2);
            writer.Write(SectionSize2);

            writer.Write(AnimsCount);

            foreach (AnimVector anim in Anims)
            {
                writer.Write(anim.SectionId);
                writer.Write(anim.SectionSize);
                editor.WriteSuperString(writer, anim.Name);
                writer.Write(anim.data);
            }
        }
    }

    public class AnimVector
    {
        public int    SectionId;
        public uint   SectionSize;
        public string Name;
        public byte[] data;
        public int GetNumKeys()
        {
            return BitConverter.ToInt32(data,0);
		}

        public uint GetSize()
        {
            return SectionSize + 8;
        }

        public void RecalcSectionSize()
        {
            SectionSize = (uint)(Name.Length + 1 + data.Length);
        }

        public string MotionName
        {
            get { return Name; }
        }
    }

    public class BoneParts
    {
        public string Name;
        public short Count;

        public List<BoneVector> bones = new List<BoneVector>();

        public int Size()
        {
            int new_size = 0;
            foreach(BoneVector bone in bones)
            {
                new_size += bone.Size();
            }

            return new_size + Name.Length + 3;
        }
    }

    public class BoneVector
    {
        public string Name;
        public uint ID;

        public int Size()
        {
            return Name.Length + 5;
        }
    }

    public class BoneContainer
    {
        public int SectionId;
        public uint SectionSize;
        public short OGF_V;
        public short Count;

        public int Size()
        {
            int new_size = 0;
            foreach (BoneParts bonesparts in parts)
            {
                new_size += bonesparts.Name.Length + 1;
                new_size += 2;

                foreach (BoneVector bone in bonesparts.bones)
                {
                    new_size += bone.Name.Length + 1;
                    new_size += 4;
                }
            }

            return new_size;
        }

        public List<BoneParts> parts = new List<BoneParts>();

        public BoneContainer(BinaryReader reader, OMFEditor editor)
        {
            SectionId = reader.ReadInt32();
            SectionSize = reader.ReadUInt32();
            OGF_V = reader.ReadInt16();
            Count = reader.ReadInt16();

            for (int i = 0; i < Count; i++)
            {
                BoneParts bonesparts = new BoneParts
                {
                    Name = editor.ReadSuperString(reader),
                    Count = reader.ReadInt16()
                };

                for (int n = 0; n < bonesparts.Count; n++)
                {
                    BoneVector sbone = new BoneVector
                    {
                        Name = editor.ReadSuperString(reader),
                        ID = reader.ReadUInt32()
                    };
                    bonesparts.bones.Add(sbone);
                }

                parts.Add(bonesparts);
            }
        }

        public void WriteBoneCont(BinaryWriter writer, OMFEditor editor)
        {
            writer.Write(SectionId);
            writer.Write(SectionSize);
            writer.Write(OGF_V);
            writer.Write(Count);

            foreach (BoneParts bone in parts)
            {
                editor.WriteSuperString(writer, bone.Name);
                writer.Write(bone.Count);

                foreach (BoneVector sbone in bone.bones)
                {
                    editor.WriteSuperString(writer, sbone.Name);
                    writer.Write(sbone.ID);
                }
            }
        }
    }

    public class MotionMark
    {
        public string Name;
        public int    Count;

        public List<MotionMarkParams> m_params = new List<MotionMarkParams>();

        public MotionMark()
        {
            
		}

        public MotionMark(BinaryReader reader, OMFEditor editor)
        {
            Name = editor.ReadMotionMarkString(reader);
            Count = reader.ReadInt32();

            for (int n = 0; n < Count; n++)
            {
                MotionMarkParams param = new MotionMarkParams(reader);
                m_params.Add(param);
            }
        }

        public void WriteMotionMark(BinaryWriter writer, OMFEditor editor)
        {
            editor.WriteMarkString(writer, Name);
            writer.Write(m_params!=null? m_params.Count : 0);

            if(m_params!= null)
            {
                foreach (MotionMarkParams param in m_params)
                {
                    writer.Write(param.t0);
                    writer.Write(param.t1);
                }
            }
        }
    }

    public class MotionMarkParams
    {
        public float t0;
        public float t1;
        public MotionMarkParams()
        {
            t0 = t1 = 0;
		}
        public MotionMarkParams(BinaryReader reader)
        {
            t0 = reader.ReadSingle();
            t1 = reader.ReadSingle();
        }
    }

    public class AnimationParams
    {
        public string Name { get; set; }
        public int Flags { get; set; }
        public short BoneOrPart { get; set; }
        public short MotionID { get; set; }
        public float Speed { get; set; }
        public float Power { get; set; }
        public float Accrue { get; set; }
        public float Falloff { get; set; }
        public int MarksCount { get; set; }

        public List<MotionMark> m_marks; // = new List<MotionMark>();

        public AnimationParams(BinaryReader reader, OMFEditor editor, short motion_version)
        {
            Name = editor.ReadSuperString(reader);
            Flags = reader.ReadInt32();
            BoneOrPart = reader.ReadInt16();
            MotionID = reader.ReadInt16();
            Speed = reader.ReadSingle();
            Power = reader.ReadSingle();
            Accrue = reader.ReadSingle();
            Falloff = reader.ReadSingle();
            MarksCount = 0;

            if (motion_version == 4)
            {
                MarksCount = reader.ReadInt32();

                if (MarksCount > 0)
                {
                    m_marks = new List<MotionMark>();

                    for (int i = 0; i < MarksCount; i++)
                    {
                        MotionMark newmark = new MotionMark(reader, editor);
                        m_marks.Add(newmark);
                    }
                }
            }
        }

        public AnimationParams(AnimationParams param)
        {
            Name = param.Name;
            Flags = param.Flags;
            BoneOrPart = param.BoneOrPart;
            MotionID = param.MotionID;
            Speed = param.Speed;
            Power = param.Power;
            Accrue = param.Accrue;
            Falloff = param.Falloff;
            MarksCount = param.MarksCount;
            m_marks = param.m_marks;
        }

        public void WriteAnimationParams(BinaryWriter writer, OMFEditor editor, short motion_version)
        {
            editor.WriteSuperString(writer, Name);
            writer.Write(Flags);
            writer.Write(BoneOrPart);
            writer.Write(MotionID);
            writer.Write(Speed);
            writer.Write(Power);
            writer.Write(Accrue);
            writer.Write(Falloff);

            if (motion_version != 4) return;

            writer.Write(m_marks != null ? m_marks.Count : 0);

            if(m_marks != null)
            {
                foreach (MotionMark mark in m_marks)
                    mark.WriteMotionMark(writer, editor);
            }
        }
    }
}
