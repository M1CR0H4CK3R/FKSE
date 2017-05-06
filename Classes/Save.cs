using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FKSE
{
    public enum SaveType
    {
        Unknown,
        TFK_USA
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
        gyfegcs = 0x110
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
                default:
                    return "Unknown";
            }
        }
    }

    //Note 1
    //Note 2

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

                Working_Save_Data = new byte[Save_File.Length];

                Save_Type = SaveDataManager.GetSaveType(Working_Save_Data);
                Save_Name = Path.GetFileNameWithoutExtension(File_Path);
                Save_Path = Path.GetDirectoryName(File_Path) + Path.DirectorySeparatorChar;
                Save_Extension = Path.GetExtension(File_Path);
                Save_ID = SaveDataManager.GetGameID(Save_Type);
                Save_Data_Start_Offset = SaveDataManager.GetSaveDataOffset(Save_ID.ToLower(), Save_Extension.Replace(".", "").ToLower());

                Original_Save_Data = Save_Reader.ReadBytes((int)Save_File.Length);
                Working_Save_Data = new byte[Original_Save_Data.Length];
                Buffer.BlockCopy(Original_Save_Data, 0, Working_Save_Data, 0, Original_Save_Data.Length);

                //FUNCTIONAL TEST OF CHECKSUM CALCULATOR (Remove at a later date)
                ushort Saved_Checksum = ReadUInt16(Save_Data_Start_Offset + 0x4240, true);
                ushort Calculated_Checksum = Checksum.Calculate_Checksum(Working_Save_Data.Skip(Save_Data_Start_Offset + 0x4440).Take(0x1160).ToArray());
                if (Checksum.Verify_Checksum(this))
                    MessageBox.Show("Checksum was valid!");
                else
                    MessageBox.Show("Checksum was invalid!");
                MessageBox.Show(string.Format("Saved Checksum: {0} | Calculated Checksum: {1}", Saved_Checksum.ToString("X4"), Calculated_Checksum.ToString("X4")));
                //END OF FUNCTIONAL TEST

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

        public void Write(int offset, object data, bool reversed = false)
        {
            Type Data_Type = data.GetType();
            if (!Data_Type.IsArray)
            {
                if (Data_Type == typeof(byte))
                    Working_Save_Data[offset] = (byte)data;
                else
                {
                    byte[] Byte_Array = BitConverter.GetBytes((dynamic)data);
                    if (reversed)
                        Array.Reverse(Byte_Array);
                    Buffer.BlockCopy(Byte_Array, 0, Working_Save_Data, offset, Byte_Array.Length);
                }
            }
            else
            {
                dynamic Data_Array = (dynamic)data;
                if (Data_Type == typeof(byte[]))
                    for (int i = 0; i < Data_Array.Length; i++)
                        Working_Save_Data[offset + i] = Data_Array[i];
                else
                {
                    int Data_Size = Marshal.SizeOf(Data_Array[0]);
                    for (int i = 0; i < Data_Array.Length; i++)
                    {
                        byte[] Byte_Array = BitConverter.GetBytes(Data_Array[i]);
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
    }
}
