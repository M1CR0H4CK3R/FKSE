using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace FKSE
{
    public enum SaveType
    {
        Unknown,
        TFK_USA,
        TFK_JPN,
        TFK_PAL
    }

    public struct Offsets
    {
        public int ItemData;
        public int ItemDataSize;
        public int Money;
        public int MoneySize;
        public int StoryData;
        public int StoryDataSize;
        public int MonsterData;
        public int MonsterDataSize;
        public int CharacterData;
        public int CharacterDataSize;
    }

    // These are offsets to the beginning of the save data. When you jump to the offset for each type, it should be the same data point
    public enum SaveFileDataOffset
    {
        gyfegci = 0,
        gyfegcs = 0x110,
        gyfpgci = 0,
        gyfpgcs = 0x110,
        gyfjgci = 0,    //GYFJ Offsets are unconfirmed
        gyfjgcs = 0x110
    }

    public static class SaveDataManager
    {

        public static SaveType GetSaveType(byte[] Save_Data)
        {
            if (Save_Data.Length == 0x6040 || Save_Data.Length == 0x6150)
            {
                string Game_ID = Encoding.ASCII.GetString(Save_Data, Save_Data.Length == 0x6150 ? 0x110 : 0, 4);
                if (Game_ID == "GYFE")
                    return SaveType.TFK_USA;
                else if (Game_ID == "GYFJ")
                    return SaveType.TFK_JPN;
                else if (Game_ID == "GYFP")
                    return SaveType.TFK_PAL;
            }
            return SaveType.Unknown;
        }


        public static int GetSaveDataOffset(string Game_ID, string Extension)
        {
            SaveFileDataOffset Extension_Enum;
            if (Enum.TryParse(Game_ID + Extension, out Extension_Enum))
                return (int)Extension_Enum;
            return 0;
        }

        public static string GetGameID(SaveType Save_Type)
        {
            switch (Save_Type)
            {
                case SaveType.TFK_USA:
                    return "GYFE";
                case SaveType.TFK_JPN:
                    return "GYFJ";
                case SaveType.TFK_PAL:
                    return "GYFP";
                default:
                    return "Unknown";
            }
        }
    }

    public class Save
    {
        public SaveType Save_Type;
        public byte[] Original_Save_Data;
        public byte[] Working_Save_Data;
        public int[] Save_Offsets;
        public int Save_Data_Start_Offset;
        public string Save_Path;
        public string Save_Name;
        public string Save_Extension;
        public string Save_ID;
        public bool Is_Big_Endian = true;
        private FileStream Save_File;
        private BinaryReader Save_Reader;
        private BinaryWriter Save_Writer;

        public Save(string File_Path)
        {
            if (File.Exists(File_Path))
            {
                if (Save_File != null)
                {
                    Save_Reader.Close();
                    Save_File.Close();
                }
                Save_File = new FileStream(File_Path, FileMode.Open);
                if (!Save_File.CanWrite)
                {
                    MessageBox.Show(string.Format("Error: File {0} is being used by another process. Please close any process using it before editing!",
                        Path.GetFileName(File_Path)), "File Opening Error");
                    try { Save_File.Close(); }
                    catch { };
                    return;
                }

                Save_Reader = new BinaryReader(Save_File);

                Original_Save_Data = Save_Reader.ReadBytes((int)Save_File.Length);
                Working_Save_Data = new byte[Original_Save_Data.Length];
                Buffer.BlockCopy(Original_Save_Data, 0, Working_Save_Data, 0, Original_Save_Data.Length);

                Save_Type = SaveDataManager.GetSaveType(Working_Save_Data);
                Save_Name = Path.GetFileNameWithoutExtension(File_Path);
                Save_Path = Path.GetDirectoryName(File_Path) + Path.DirectorySeparatorChar;
                Save_Extension = Path.GetExtension(File_Path);
                Save_ID = SaveDataManager.GetGameID(Save_Type);
                Save_Data_Start_Offset = SaveDataManager.GetSaveDataOffset(Save_ID.ToLower(), Save_Extension.Replace(".", "").ToLower());

                Save_Reader.Close();
                Save_File.Close();
            }
        }
        public void Flush()
        {
            string Full_Save_Name = Save_Path + Path.DirectorySeparatorChar + Save_Name + Save_Extension;
            Save_File = new FileStream(Full_Save_Name, FileMode.OpenOrCreate);
            Save_Writer = new BinaryWriter(Save_File);

            Save_Writer.Write(Working_Save_Data);
            Save_Writer.Flush();
            Save_File.Flush();

            Save_Writer.Close();
            Save_File.Close();
        }

        public void Write(int offset, dynamic data, bool reversed = false)
        {
            Type Data_Type = data.GetType();
            if (!Data_Type.IsArray)
            {
                if (Data_Type == typeof(byte))
                    Working_Save_Data[offset] = (byte)data;
                else
                {
                    byte[] Byte_Array = BitConverter.GetBytes(data);
                    if (reversed)
                        Array.Reverse(Byte_Array);
                    Buffer.BlockCopy(Byte_Array, 0, Working_Save_Data, offset, Byte_Array.Length);
                }
            }
            else
            {
                if (Data_Type == typeof(byte[]))
                    for (int i = 0; i < data.Length; i++)
                        Working_Save_Data[offset + i] = data[i];
                else
                {
                    int Data_Size = Marshal.SizeOf(data[0]);
                    for (int i = 0; i < data.Length; i++)
                    {
                        byte[] Byte_Array = BitConverter.GetBytes(data[i]);
                        if (reversed)
                            Array.Reverse(Byte_Array);
                        Byte_Array.CopyTo(Working_Save_Data, offset + i * Data_Size);
                    }
                }
            }
        }

        public byte ReadByte(int offset)
        {
            return Working_Save_Data[offset];
        }

        public byte[] ReadByteArray(int offset, int count, bool reversed = false)
        {
            byte[] Data = new byte[count];
            Buffer.BlockCopy(Working_Save_Data, offset, Data, 0, count);
            if (reversed)
                Array.Reverse(Data);
            return Data;
        }

        public ushort ReadUInt16(int offset, bool reversed = false)
        {
            return BitConverter.ToUInt16(ReadByteArray(offset, 2, reversed), 0);
        }

        public ushort[] ReadUInt16Array(int offset, int count, bool reversed = false)
        {
            ushort[] Returned_Values = new ushort[count];
            for (int i = 0; i < count; i++)
                Returned_Values[i] = ReadUInt16(offset + i * 2, reversed);
            return Returned_Values;
        }

        public uint ReadUInt32(int offset, bool reversed = false)
        {
            return BitConverter.ToUInt32(ReadByteArray(offset, 4, reversed), 0);
        }

        public uint[] ReadUInt32Array(int offset, int count, bool reversed = false)
        {
            uint[] Returned_Values = new uint[count];
            for (int i = 0; i < count; i++)
                Returned_Values[i] = ReadUInt32(offset + i * 4, reversed);
            return Returned_Values;
        }

        // Static Objects Below
        public static Dictionary<Type, Delegate> typeMap = new Dictionary<Type, Delegate>
        {
            {typeof(byte[]), new Func<byte[], byte>
                (b => {
                    return ConvertByte(new BitArray(b));
                })
            },
            {typeof(BitArray), new Func<BitArray, byte>
                (b => {
                    return ConvertByte(b);
                })
            },
            {typeof(bool[]), new Func<bool[], byte>
                (b => {
                    byte[] Bit_Array = new byte[8];
                    for (int i = 0; i < 4; i++)
                        Bit_Array[i] = Convert.ToByte(b[i]);
                    return ConvertByte(new BitArray(Bit_Array));
                })
            }
        };

        public static byte[] ToBits(byte Byte, bool Reverse = false)
        {
            byte[] Bits = new byte[8];
            BitArray Bit_Array = new BitArray(new byte[] { Byte });
            for (int x = 0; x < Bit_Array.Length; x++)
                Bits[Reverse ? 7 - x : x] = Convert.ToByte(Bit_Array[x]);
            return Bits;
        }

        public static byte ToBit(byte Bit_Byte, int Bit_Index, bool Reverse = false)
        {
            return (byte)((Reverse ? Bit_Byte >> (7 - Bit_Index) : Bit_Byte >> Bit_Index) & 1);
        }

        public static void SetBit(ref byte Bit_Byte, int Bit_Index, bool Set, bool Reverse = false)
        {
            int Mask = 1 << (Reverse ? 7 - Bit_Index : Bit_Index);
            if (Set)
                Bit_Byte = Bit_Byte |= (byte)Mask;
            else
                Bit_Byte = Bit_Byte &= (byte)~Mask;
        }

        public static byte ToByte(object Variant)
        {
            return (byte)typeMap[Variant.GetType()].DynamicInvoke(Variant);
        }

        private static byte ConvertByte(BitArray b)
        {
            byte value = 0;
            for (byte i = 0; i < b.Count; i++)
                if (b[i])
                    value |= (byte)(1 << i);
            return value;
        }

        public static List<string> LoadItemDatabase(string Language = "en")
        {
            StreamReader Contents = null;
            string DB_Location = MainForm.Assembly_Location + string.Format("\\Resources\\Items_{0}.txt", Language);
            try { Contents = File.OpenText(DB_Location); }
            catch { }
            List<string> Items_List = new List<string>();
            string Line;
            while ((Line = Contents.ReadLine()) != null)
            {
                if (Line.Contains("0x"))
                {
                    Items_List.Add(Line.Substring(6));
                }
            }
            return Items_List;
        }

        public static List<string> LoadMonsterDatabase(string Language = "en")
        {
            StreamReader Contents = null;
            string DB_Location = MainForm.Assembly_Location + string.Format("\\Resources\\Monsters_{0}.txt", Language);
            try { Contents = File.OpenText(DB_Location); }
            catch { }
            List<string> Monsters_List = new List<string>();
            string Line;
            while ((Line = Contents.ReadLine()) != null)
            {
                if (Line.Contains("0x"))
                {
                    Monsters_List.Add(Line.Substring(7));
                }
            }
            return Monsters_List;
        }
    }
}
