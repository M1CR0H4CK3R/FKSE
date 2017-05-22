using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKSE
{
    class Character
    {
        public bool[] Flags;
        public byte Character_Slot;
        public byte Battle_Points;
        public byte Life_Points;
        public byte Action_Points;
        public uint Orb_RGB_Color;
        public ushort EXP;

        private int Character_Offset;
        private Save Save_File_Reference;

        public Character()
        {
            Flags = new bool[4];
            Character_Slot = 0;
            Battle_Points = 0;
            Life_Points = 0;
            Action_Points = 0;
            Orb_RGB_Color = 0;
            EXP = 0;
        }

        public Character(Save Save_File, int Offset)
        {
            Character_Offset = Offset;
            Save_File_Reference = Save_File;
            byte[] Character_Data = Save_File.ReadByteArray(Offset, 8);
            byte[] Flag_Bits = Save.ToBits((byte)((Character_Data[0] & 0xF0) >> 4));
            Flags = new bool[4];
            for (int i = 0; i < 4; i++)
                Flags[i] = Convert.ToBoolean(Flag_Bits[i]);
            Character_Slot = (byte)(Character_Data[0] & 0xF);
            Battle_Points = Character_Data[1];
            Life_Points = (byte)((Character_Data[2] & 0xF0) >> 4);
            Action_Points = (byte)(Character_Data[2] & 0xF);
            Orb_RGB_Color = (uint)((Character_Data[3] << 16) + (Character_Data[4] << 8) + Character_Data[5]);
            EXP = (ushort)((Character_Data[6] << 8) + Character_Data[7]);
        }

        public bool IsAvailable()
        {
            return Flags[2];
        }

        public bool IsAssignable()
        {
            return Flags[3];
        }

        public void Write()
        {
            byte Flag_Data = Character_Slot;
            for (int i = 0; i < 4; i++)
                Save.SetBit(ref Flag_Data, i + 4, Flags[i]);

            Save_File_Reference.Write(Character_Offset, Flag_Data);
            Save_File_Reference.Write(Character_Offset + 1, Battle_Points);
            Save_File_Reference.Write(Character_Offset + 2, (byte)(((Life_Points & 0xF) << 4) + Action_Points & 0xF));
            Save_File_Reference.Write(Character_Offset + 3, (byte)(Orb_RGB_Color >> 16));
            Save_File_Reference.Write(Character_Offset + 4, (byte)(Orb_RGB_Color >> 8));
            Save_File_Reference.Write(Character_Offset + 5, (byte)Orb_RGB_Color);
            Save_File_Reference.Write(Character_Offset + 6, EXP, true);
        }
    }
}
