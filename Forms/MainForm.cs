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
using System.Globalization;
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
        private ComboBox[] Item_ComboBoxes = new ComboBox[64];
        private ComboBox[] Monster_Item_ComboBoxes = new ComboBox[3];
        private TextBox[] Monster_Item_TextBoxes = new TextBox[3];
        private PictureBox[] Monster_PictureBoxes = new PictureBox[12];
        private int Item_ComboBox_Count = 64;
        private int Monster_PictureBox_Count = 12;
        private int Item_Page = 1;
        private int Monster_Page = 1;
        private Monster Current_Monster;
        private PictureBox Last_Monster_Portrait;
        private Image Monster_BG = Properties.Resources.Monster_BG;
        #endregion Variables

        public static DateTime DateFromTimestamp(long timestamp)
        {
            return _unixEpoch.AddSeconds(timestamp);
        }

        public MainForm()
        {
            InitializeComponent();
            Generate_Item_ComboBoxes();
            Generate_Monster_PictureBoxes();
            Monster_Item_ComboBoxes = new ComboBox[3] { monsterItem1, monsterItem2, monsterItem3 };
            Monster_Item_TextBoxes = new TextBox[3] { monsterItemQuantity1, monsterItemQuantity2, monsterItemQuantity3 };

            for (int i = 0; i < 3; i++)
            {
                Monster_Item_ComboBoxes[i].Items.AddRange(Item_Database);
                Monster_Item_ComboBoxes[i].SelectedIndexChanged += new EventHandler(Monster_Item_Selected_Index_Changed);
                Monster_Item_TextBoxes[i].TextChanged += new EventHandler(Monster_Item_Quantity_Text_Changed);
            }
        }

        private Image Get_Monster_Icon(int Monster_Index)
        {
            try
            {
                return Image.FromFile(Assembly_Location + "\\Resources\\Monster Portraits\\" + Monster_Index.ToString() + ".png");
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            return null;
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

        private void Monster_Mouse_Move(object sender, MouseEventArgs e)
        {
            
        }

        private void Generate_Monster_PictureBoxes()
        {
            for (int i = 0; i < Monster_PictureBox_Count; i++)
            {
                PictureBox Monster_Box = new PictureBox
                {
                    Size = new Size(96, 96),
                    Location = new Point((i % 3) * 96, (i / 3) * 96)
                };
                Monster_Box.Click += new EventHandler(Monster_Click);
                Monster_Box.Image = Get_Monster_Icon(i);
                monstersTab.Controls.Add(Monster_Box);
                Monster_PictureBoxes[i] = Monster_Box;
            }
        }

        private void Set_Selected_Monster_BG()
        {
            if (Current_Monster != null)
            {
                int Monster_Idx = Array.IndexOf(Monsters, Current_Monster);
                int Box_Position = Monster_Idx % Monster_PictureBox_Count;
                int Lower_Bound = (Monster_Page - 1) * Monster_PictureBox_Count;
                int Upper_Bound = Lower_Bound + Monster_PictureBox_Count;
                if (Monster_Idx >= Lower_Bound && Monster_Idx < Upper_Bound)
                {
                    if (Last_Monster_Portrait != null)
                        Last_Monster_Portrait.BackgroundImage = null;
                    Last_Monster_Portrait = Monster_PictureBoxes[Box_Position];
                    Last_Monster_Portrait.BackgroundImage = Monster_BG;
                }
                else
                    if (Last_Monster_Portrait != null)
                    Last_Monster_Portrait.BackgroundImage = null;
            }
        }

        private void Monster_Item_Selected_Index_Changed(object sender, EventArgs e)
        {
            ComboBox Item_Box = sender as ComboBox;
            if (Save_File != null && Current_Monster != null && Item_Box.SelectedIndex > -1)
            {
                int Item_Idx = Array.IndexOf(Monster_Item_ComboBoxes, Item_Box);
                Current_Monster.Items[Item_Idx].Item_ID = Item_Box.SelectedIndex == 0x3A ? (byte)0xFF : (byte)Item_Box.SelectedIndex;
            }
        }

        private void Monster_Item_Quantity_Text_Changed(object sender, EventArgs e)
        {
            TextBox Item_Box = sender as TextBox;
            int Item_Idx = Array.IndexOf(Monster_Item_TextBoxes, Item_Box);
            if (Save_File != null && Current_Monster != null && byte.TryParse(Item_Box.Text, out byte New_Quantity))
            {
                Current_Monster.Items[Item_Idx].Quantity = New_Quantity;
            }
            else if (Current_Monster != null && !string.IsNullOrEmpty(Item_Box.Text))
            {
                Item_Box.Text = Current_Monster.Items[Item_Idx].Quantity.ToString();
            }
        }

        private void Monster_Click(object sender, EventArgs e)
        {
            if (Save_File != null)
            {
                int Monster_Idx = (Monster_Page - 1) * Monster_PictureBox_Count + Array.IndexOf(Monster_PictureBoxes, sender);
                Monster Clicked_Monster = Monsters[Monster_Idx];
                Current_Monster = Clicked_Monster;
                Set_Selected_Monster_BG();
                selectedMonster.Text = Monster_Database[Monster_Idx];
                monsterActionPoints.Value = Clicked_Monster.Action_Points;
                monsterHP.Text = Clicked_Monster.Max_HP.ToString();
                monsterAttack.Text = Clicked_Monster.Base_Attack.ToString();
                monsterDefence.Text = Clicked_Monster.Base_Defense.ToString();
                monsterEXP.Text = Clicked_Monster.EXP.ToString();
                monsterOwned.Checked = Clicked_Monster.Flags[2];
                monsterAssignable.Checked = Clicked_Monster.Flags[3];

                for (int i = 0; i < 3; i++)
                {
                    Monster_Item_ComboBoxes[i].SelectedIndex = Clicked_Monster.Items[i].Item_ID == 0xFF ? 0x3A : Clicked_Monster.Items[i].Item_ID;
                    Monster_Item_TextBoxes[i].Text = Clicked_Monster.Items[i].Quantity.ToString();
                }

            }
        }

        private void Update_Item_ComboBoxes(int page)
        {
            int start_Index = (page - 1) * Item_ComboBox_Count;
            for (int i = 0; i < Item_ComboBox_Count; i++)
                Item_ComboBoxes[i].SelectedIndex = Items[start_Index + i].Item_ID == 0xFF ? 0x3A : Items[start_Index + i].Item_ID;
            itemPageLabel.Text = string.Format("Page {0}/8", page);
        }

        private void Update_Monster_PictureBoxes(int page)
        {
            int start_Index = (page - 1) * Monster_PictureBox_Count;
            for (int i = 0; i < Monster_PictureBox_Count; i++)
            {
                var Old_Image = Monster_PictureBoxes[i].Image;
                if (start_Index + i < 177)
                    Monster_PictureBoxes[i].Image = Get_Monster_Icon(start_Index + i);
                else
                    Monster_PictureBoxes[i].Image = null;
                if (Old_Image != null)
                    Old_Image.Dispose();
            }
            monsterPageLabel.Text = string.Format("Page {0}/15", page);
            Set_Selected_Monster_BG();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save_File = new Save(openFileDialog1.FileName);
                Current_Monster = null;

                if (Last_Monster_Portrait != null)
                {
                    Last_Monster_Portrait.BackgroundImage = null;
                    Last_Monster_Portrait = null;
                }

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

        private void monsterNext_Click(object sender, EventArgs e)
        {
            if (Monster_Page > 14)
                Monster_Page = 1;
            else
                Monster_Page++;
            Update_Monster_PictureBoxes(Monster_Page);
        }

        private void monsterBack_Click(object sender, EventArgs e)
        {
            if (Monster_Page < 2)
                Monster_Page = 15;
            else
                Monster_Page--;
            Update_Monster_PictureBoxes(Monster_Page);
        }

        private void monsterActionPoints_Scroll(object sender, EventArgs e)
        {
            if (Save_File != null && Current_Monster != null && monsterActionPoints.Value > 0 && monsterActionPoints.Value < 13)
            {
                Current_Monster.Action_Points = (byte)monsterActionPoints.Value;
            }
        }

        private void monsterHP_TextChanged(object sender, EventArgs e)
        {
            if (Current_Monster != null)
            {
                if (ushort.TryParse(monsterHP.Text, out ushort New_HP))
                {
                    Current_Monster.Max_HP = New_HP;
                }
                else if (!string.IsNullOrEmpty((sender as TextBox).Text))
                {
                    monsterHP.Text = Current_Monster.Max_HP.ToString();
                }
            }
        }

        private void monsterAttack_TextChanged(object sender, EventArgs e)
        {
            if (Current_Monster != null)
            {
                if (ushort.TryParse(monsterAttack.Text, out ushort New_Attack))
                {
                    Current_Monster.Base_Attack = New_Attack;
                }
                else if (!string.IsNullOrEmpty((sender as TextBox).Text))
                {
                    monsterAttack.Text = Current_Monster.Base_Attack.ToString();
                }
            }
        }

        private void monsterDefence_TextChanged(object sender, EventArgs e)
        {
            if (Current_Monster != null)
            {
                if (ushort.TryParse(monsterDefence.Text, out ushort New_Defense))
                {
                    Current_Monster.Base_Defense = New_Defense;
                }
                else if (!string.IsNullOrEmpty((sender as TextBox).Text))
                {
                    monsterDefence.Text = Current_Monster.Base_Defense.ToString();
                }
            }
        }

        private void monsterEXP_TextChanged(object sender, EventArgs e)
        {
            if (Current_Monster != null)
            {
                if (ushort.TryParse(monsterEXP.Text, out ushort New_EXP))
                {
                    Current_Monster.EXP = New_EXP;
                }
                else if (!string.IsNullOrEmpty((sender as TextBox).Text))
                {
                    monsterEXP.Text = Current_Monster.EXP.ToString();
                }
            }
        }

        private void monsterOwned_CheckedChanged(object sender, EventArgs e)
        {
            if (Current_Monster != null)
                Current_Monster.Flags[2] = monsterOwned.Checked;
        }

        private void monsterAssignable_CheckedChanged(object sender, EventArgs e)
        {
            if (Current_Monster != null)
                Current_Monster.Flags[3] = monsterAssignable.Checked;
        }
    }
}