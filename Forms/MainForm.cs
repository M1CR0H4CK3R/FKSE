using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace FKSE
{
    public partial class MainForm : Form
    {
        #region Offsets
        //TODO: Move this code out of this form and into its own class. (Also updated the rest to correct values)
        public static int ItemData_Offset = 0x4490;
        public static int ItemData_Size = 0x400;
        public static int Money_Offset = 0x4690;
        public static int StoryData_Offset = 0x469C;
        public static int StoryData_Size = 0xC;
        public static int MonsterData_Offset = 0x46A0;
        public static int MonsterData_Size = 0xDD4;
        public static int CharacterData_Offset = 0x5474;
        public static int CharacterData_Size = 0x118;
        #endregion Offsets

        #region Variables
        public static readonly string Assembly_Location = Directory.GetCurrentDirectory();
        static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //static readonly int Date_Offset = 946684799; //Date at 12/31/1999 @ 11:59:59PM
        private Save Save_File;
        private Item[] Items = new Item[512];
        private Monster[] Monsters = new Monster[177];
        private string[] Item_Database = Save.LoadItemDatabase().ToArray();
        private string[] Monster_Database = Save.LoadMonsterDatabase().ToArray();
        private ComboBox[] Item_ComboBoxes = new ComboBox[512];
        private int Item_ComboBox_Count = 64;
        private int Item_Page = 1;
        #endregion Variables

        public static DateTime DateFromTimestamp(long timestamp)
        {
            return _unixEpoch.AddSeconds(timestamp);
        }

        public MainForm()
        {
            InitializeComponent();
            Generate_Item_ComboBoxes();
        }

        private void Update_Item(object sender, EventArgs e)
        {
            ComboBox Item_Box = sender as ComboBox;
            int ComboBox_Idx = Array.IndexOf(Item_ComboBoxes, sender);
            if (ComboBox_Idx > -1 && Item_Box.SelectedIndex > -1)
            {
                int Item_Idx = (Item_Page - 1) * Item_ComboBox_Count + ComboBox_Idx;
                Items[Item_Idx].Item_ID = Item_Box.SelectedIndex == 0x3A ? (byte)0xFF : (byte)Item_Box.SelectedIndex;
            }
        }

        private void Generate_Item_ComboBoxes()
        {
            for (int i = 0; i < Item_ComboBox_Count; i++)
            {
                ComboBox Item_Box = new ComboBox
                {
                    Size = new Size(120, 22),
                    Location = new Point((i % 4) * 125, (i / 4) * 24),
                };
                Item_Box.SelectedIndexChanged += new EventHandler(Update_Item);
                Item_Box.BeginUpdate();
                Item_Box.Items.AddRange(Item_Database);
                Item_Box.SelectedIndex = 0x39;
                itemsPanel.Controls.Add(Item_Box);
                Item_ComboBoxes[i] = Item_Box;
                Item_Box.EndUpdate();
            }
        }

        private void Update_Item_ComboBoxes(int page)
        {
            int start_Index = (page - 1) * Item_ComboBox_Count;
            for (int i = 0; i < Item_ComboBox_Count; i++)
                Item_ComboBoxes[i].SelectedIndex = Items[start_Index + i].Item_ID == 0xFF ? 0x3A : Items[start_Index + i].Item_ID;
            itemPageLabel.Text = string.Format("Page {0}/8", page);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save_File = new Save(openFileDialog1.FileName);
                Text = "FKSE - " + Save_File.Save_Name + string.Format(" - [{0}]", Save_File.Save_Type == SaveType.Unknown ? "Unknown" : Save_File.Save_Type.ToString().Substring(4));
                //TODO: Implement reading method more elegantly
                goldTextBox.Text = Save_File.ReadUInt32(Save_File.Save_Data_Start_Offset + Money_Offset, true).ToString();

                // Item Loading
                for (int i = 0; i < 512; i++)
                    Items[i] = new Item(Save_File.ReadByte(Save_File.Save_Data_Start_Offset + ItemData_Offset + i), 0, true);
                Update_Item_ComboBoxes(1);

                // Monster Loading
                for (int i = 0; i < 177; i++)
                    Monsters[i] = new Monster(Save_File.Save_Data_Start_Offset + MonsterData_Offset + i * 0x14, Save_File);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save_File != null)
            {
                foreach (Monster Monster in Monsters)
                    Monster.Write();
                for (int i = 0; i < 512; i++)
                    Save_File.Write(Save_File.Save_Data_Start_Offset + ItemData_Offset + i, Items[i].Item_ID);
                Checksum.Update_Checksum(Save_File);
                Save_File.Flush();
            }
        }

        private void goldTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Save_File != null && uint.TryParse(goldTextBox.Text, out uint New_Gold_Value))
            {
                Save_File.Write(Save_File.Save_Data_Start_Offset + Money_Offset, New_Gold_Value, true); //TODO: Change this to use the out of form gold offset
            }
        }

        private void itemsNext_Click(object sender, EventArgs e)
        {
            if (Item_Page > 7)
                Item_Page = 1;
            else
                Item_Page++;
            Update_Item_ComboBoxes(Item_Page);
        }

        private void itemsBack_Click(object sender, EventArgs e)
        {
            if (Item_Page < 2)
                Item_Page = 8;
            else
                Item_Page--;
            Update_Item_ComboBoxes(Item_Page);
        }
    }
}