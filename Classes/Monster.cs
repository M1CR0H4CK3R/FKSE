using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKSE
{
    class Monster
    {
        public bool[] Flags;
        public byte Action_Points;
        public byte UNKNOWN; // Figure out what this is
        public uint Orb_RGB;
        public ushort Max_HP;
        public ushort Base_Attack;
        public ushort Base_Defense;
        public ushort EXP;
        public Item[] Items;

        public Monster()
        {
            Flags = new bool[8];
            Action_Points = 0;
            UNKNOWN = 0;
            Orb_RGB = 0x00FFFFFF;
            Max_HP = 0;
            Base_Attack = 0;
            Base_Attack = 0;
            EXP = 0;
            Items = new Item[3];
        }

        public Monster(byte[] monsterData)
        {
            byte[] Flag_Bits = Save.ToBits(monsterData[0]);

            Flags = new bool[8];
            for (int i = 0; i < 8; i++)
                Flags[i] = Convert.ToBoolean(Flag_Bits[i]);
            Action_Points = monsterData[1];
            UNKNOWN = monsterData[2];
            Orb_RGB = (uint)((monsterData[3] << 16) + (monsterData[4] << 8) + monsterData[5]);
            Max_HP = (ushort)((monsterData[6] << 8) + monsterData[7]);
            Base_Attack = (ushort)(monsterData[8] << 8 + monsterData[9]);
            Base_Defense = (ushort)((monsterData[0xA] << 8) + monsterData[0xB]);
            EXP = (ushort)((monsterData[0xC] << 8) + monsterData[0xD]);
            Items = new Item[3];
            for (int i = 0; i < 3; i++)
                Items[i] = new Item(monsterData[0xE + i * 2]);
        }
    }
}
