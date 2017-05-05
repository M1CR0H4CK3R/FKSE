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
                ushort Checksum = 0; // Checksum = Z (r0)
                ushort Counter = 0; // C (r5)
                ushort X = 0, Y = 0;

                for (int i = 0; i < Save_Buffer.Length; i += 16) //Address = r9
                {
                    for (int sub = 0; sub < 8; sub++)
                    {
                        int Sub_Offset = i + sub * 2; //Address + 2
                        ushort Current_WORD = (ushort)((Save_Buffer[Sub_Offset] << 8) + Save_Buffer[Sub_Offset + 1]); //GC Has Reverse Endianness (Big Endian)
                        if (sub == 0)
                        {
                            //Step 3
                            Y = Current_WORD;
                            Counter += 8; //Step 4
                        }
                        else if (sub % 2 == 1)
                        {
                            //Steps 5 -> 6, 9 -> 10, 13 -> 14, 17 -> 18
                            X = Current_WORD;
                            Checksum ^= Y;
                        }
                        else
                        {
                            //Steps 7 -> 8, 11 -> 12, 15 -> 16
                            Y = Current_WORD;
                            Checksum ^= X;
                        }
                    }
                    Checksum ^= X; //Step 20
                                   //Checksum &= 0xFFFF; // This is implied when it overflows
                    if (Counter > 0x08A8) //Step 21
                        break;
                }
                return (ushort)(Checksum ^ 0x4C6B);
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
