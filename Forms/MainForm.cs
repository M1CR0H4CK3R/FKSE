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
        public static byte[] saveBuffer = new byte[0x4440];

        #region Offsets
        public static int DataStart_Offset = 0x4440;
        public static int ItemData_Offset = 0x50;
        public static int ItemData_Size = 0x200;
        public static int Money_Offset = 0x250;
        public static int Money_Size = 0x4;
        public static int StoryData_Offset = 0x254;
        public static int StoryData_Size = 0xC;
        public static int MonsterData_Offset = 0x260;
        public static int MonsterData_Size = 0xDD4;
        public static int CharacterData_Offset = 0x1034;
        public static int CharacterData_Size = 0x118;
        #endregion Offsets

        #region Variables
        public static readonly string Assembly_Location = Directory.GetCurrentDirectory();
        static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //static readonly int Date_Offset = 946684799; //Date at 12/31/1999 @ 11:59:59PM
        private FileStream fs;
        private BinaryReader reader;
        private BinaryWriter writer;
        public static string fileName;
        private ItemEditor itemEditorForm;
        private MonsterEditor monsterEditorForm;
        private CharacterEditor characterEditorForm;
        private CharacterMonsterEditor charMonsterEditorForm;
        private CancelEventHandler importHandler;
        public static byte[] SaveBuffer { get { return saveBuffer; } }
        #endregion Variables

        public static DateTime DateFromTimestamp(long timestamp)
        {
            return _unixEpoch.AddSeconds(timestamp);
        }

        private byte[] GetSaveData(int offset, int size)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            return reader.ReadBytes(size);
        }

        private void SaveData()
        {
            Checksum.Update(saveBuffer);
            fs = new FileStream(fileName, FileMode.Open);
            writer = new BinaryWriter(fs);
            writer.Seek(Data_Start_Offset, SeekOrigin.Begin);
            writer.Write(saveBuffer);
            writer.Close();
            fs.Close();
        }


        public MainForm()
        {
            InitializeComponent();
            ItemData.SetupItemDictionary();
            MonsterData.SetupMonsterDictionary();
            CharacterData.SetupCharacterDictionary();
        }
    }
}