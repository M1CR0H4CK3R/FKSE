﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKSE
{
    class Item
    {
        public byte Item_ID;
        public byte Quantity; // 0 if not consumable
        public bool Is_Simple;

        public Item()
        {
            Item_ID = 0;
            Quantity = 0;
        }

        public Item(byte itemId, byte quantity, bool simple = false)
        {
            Item_ID = itemId;
            Quantity = quantity;
            Is_Simple = simple;
        }


        public Item(byte itemId)
        {
            Item_ID = itemId;
            Quantity = 0;
        }

        public Item(ushort item)
        {
            Item_ID = (byte)(item >> 4);
            Quantity = (byte)item;
        }
    }
}
