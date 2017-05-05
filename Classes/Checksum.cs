using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FKSE
{
    public static class Checksum
    {
        public static ushort Calculate_Checksum(byte[] Save_Buffer)
        {
            if (Save_Buffer.Length == 0x1160)
            {
                ushort Checksum = 0;
                ushort Last_WORD = 0;

                for (int i = 0; i < 0x8B0; i++)
                {
                    if (i > 0)
                        Checksum ^= Last_WORD;
                    Last_WORD = (ushort)((Save_Buffer[i * 2] << 8) + Save_Buffer[i * 2 + 1]);
                }
                Checksum ^= Last_WORD;
                return (ushort)(Checksum ^ 0x4C6B); //0x4C6B is the XOR key used for obfuscation
            }
            throw (new ArgumentException(string.Format("Checksum Calculator was passed a byte array with an invalid Length. Expected a length of 0x1160, but got length: 0x{0}", Save_Buffer.Length.ToString("X"))));
        }

        public static bool Verify_Checksum(Save Save_File)
        {
            return (Save_File.ReadUInt16(Save_File.Save_Data_Start_Offset + 0x4240, true) == Calculate_Checksum(Save_File.ReadByteArray(Save_File.Save_Data_Start_Offset + 0x4440, 0x1160)));
        }

        public static void Update_Checksum(Save Save_File)
        {
            Save_File.Write(Save_File.Save_Data_Start_Offset + 0x4240, Calculate_Checksum(Save_File.ReadByteArray(Save_File.Save_Data_Start_Offset + 0x4440, 0x1160)), true);
        }
    }
}
