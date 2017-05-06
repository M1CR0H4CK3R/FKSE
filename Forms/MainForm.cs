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
        public static int ItemData_Offset = 0x250;
        public static int ItemData_Size = 0x400;
        public static int Money_Offset = 0x4690;
        public static int StoryData_Offset = 0x454;
        public static int StoryData_Size = 0xC;
        public static int MonsterData_Offset = 0x460;
        public static int MonsterData_Size = 0xDD4;
        public static int CharacterData_Offset = 0x1234;
        public static int CharacterData_Size = 0x118;
        #endregion Offsets

        #region Variables
        public static readonly string Assembly_Location = Directory.GetCurrentDirectory();
        static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //static readonly int Date_Offset = 946684799; //Date at 12/31/1999 @ 11:59:59PM
        //private ItemEditor itemEditorForm;
        //private MonsterEditor monsterEditorForm;
        //private CharacterEditor characterEditorForm;
        //private CharacterMonsterEditor charMonsterEditorForm;
        //private CancelEventHandler importHandler;
        private Save Save_File;
        #endregion Variables

        public static DateTime DateFromTimestamp(long timestamp)
        {
            return _unixEpoch.AddSeconds(timestamp);
        }

        public MainForm()
        {
            InitializeComponent();
            //ItemData.SetupItemDictionary();
            //MonsterData.SetupMonsterDictionary();
            //CharacterData.SetupCharacterDictionary();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save_File = new Save(openFileDialog1.FileName);
                //TODO: Implement reading method more elegantly
                goldTextBox.Text = Save_File.ReadUInt32(Save_File.Save_Data_Start_Offset + Money_Offset, true).ToString();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save_File != null)
            {
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
    }
}