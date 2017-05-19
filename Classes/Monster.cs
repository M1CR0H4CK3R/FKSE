using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FKSE
{
    /*
     * Monster Flag Data Documentation (Upper nibble of first byte)
     * 
     * Currently, only two values are seen. 0xC and 0x4.
     * Almost always, the second bit is set (0100).
     * The first bit seems to determine if the monster is currently assignable (1000)
     * The second bit determines if you own the monster (0100)
     * The third bit is unknown.
     * The fourth bit is unknown.
     * 
     * If you don't own the monster, the normal value is 0. (The whole byte is normally 0x0A, where A = the 11th character slot, which doesn't exist)
     * 
     * The lower nibble of the first byte is reserved for determining what character slot the monster is in.
     */

    class Monster
    {
        public bool[] Flags; // Upper Nibble of first byte
        public byte Character_Slot; // Lower Nibble of first byte
        public byte Action_Points;
        public byte UNKNOWN; // Figure out what this is
        public uint Orb_RGB;
        public ushort Max_HP;
        public ushort Base_Attack;
        public ushort Base_Defense;
        public ushort EXP;
        public Item[] Items;

        private int Monster_Offset;
        private Save Save_File_Reference;

        public Monster()
        {
            Flags = new bool[8];
            Character_Slot = 0;
            Action_Points = 0;
            UNKNOWN = 0;
            Orb_RGB = 0x00FFFFFF;
            Max_HP = 0;
            Base_Attack = 0;
            Base_Attack = 0;
            EXP = 0;
            Items = new Item[3];
        }

        public Monster(int Offset, Save Save_File)
        {
            Save_File_Reference = Save_File;
            Monster_Offset = Offset;
            byte[] monsterData = Save_File.ReadByteArray(Offset, 0x14);
            //System.Windows.Forms.MessageBox.Show(string.Format("Upper Nibble is: 0x{0}", ((byte)((monsterData[0] & 0xF0) >> 4)).ToString("X")));
            byte[] Flag_Bits = Save.ToBits((byte)((monsterData[0] & 0xF0) >> 4)); // Get upper nibble of first byte for flags
            Flags = new bool[4];
            for (int i = 0; i < 4; i++)
                Flags[i] = Convert.ToBoolean(Flag_Bits[i]);
            Character_Slot = (byte)(monsterData[0] & 0xF); // Lower nibble is reserved for the character slot of the monster
            Action_Points = monsterData[1];
            UNKNOWN = monsterData[2];
            Orb_RGB = (uint)((monsterData[3] << 16) + (monsterData[4] << 8) + monsterData[5]);
            Max_HP = (ushort)((monsterData[6] << 8) + monsterData[7]);
            Base_Attack = (ushort)((monsterData[8] << 8) + monsterData[9]);
            Base_Defense = (ushort)((monsterData[0xA] << 8) + monsterData[0xB]);
            EXP = (ushort)((monsterData[0xC] << 8) + monsterData[0xD]);
            Items = new Item[3];
            for (int i = 0; i < 3; i++)
                Items[i] = new Item(monsterData[0xE + i * 2]);
        }

        public void Write()
        {
            byte Flag_Data = Character_Slot;
            for (int i = 0; i < 4; i++)
                Save.SetBit(ref Flag_Data, i + 4, Flags[i]);

            Save_File_Reference.Write(Monster_Offset, Flag_Data);
            Save_File_Reference.Write(Monster_Offset + 1, Action_Points);
            Save_File_Reference.Write(Monster_Offset + 2, UNKNOWN);
            Save_File_Reference.Write(Monster_Offset + 3, (byte)(Orb_RGB >> 16));
            Save_File_Reference.Write(Monster_Offset + 4, (byte)(Orb_RGB >> 8));
            Save_File_Reference.Write(Monster_Offset + 5, (byte)Orb_RGB);
            Save_File_Reference.Write(Monster_Offset + 6, Max_HP, true);
            Save_File_Reference.Write(Monster_Offset + 8, Base_Attack, true);
            Save_File_Reference.Write(Monster_Offset + 0xA, Base_Defense, true);
            Save_File_Reference.Write(Monster_Offset + 0xC, EXP, true);

            for (int i = 0; i < 3; i++)
                Save_File_Reference.Write(Monster_Offset + 0xE + i * 2, new byte[2] { Items[i].Item_ID, Items[i].Quantity });
        }
    }
}
