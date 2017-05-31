using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TranslationTool
{
    [Flags]
    enum IsTextUnicodeFlags : int
    {
        IS_TEXT_UNICODE_ASCII16 = 0x0001,
        IS_TEXT_UNICODE_REVERSE_ASCII16 = 0x0010,

        IS_TEXT_UNICODE_STATISTICS = 0x0002,
        IS_TEXT_UNICODE_REVERSE_STATISTICS = 0x0020,

        IS_TEXT_UNICODE_CONTROLS = 0x0004,
        IS_TEXT_UNICODE_REVERSE_CONTROLS = 0x0040,

        IS_TEXT_UNICODE_SIGNATURE = 0x0008,
        IS_TEXT_UNICODE_REVERSE_SIGNATURE = 0x0080,

        IS_TEXT_UNICODE_ILLEGAL_CHARS = 0x0100,
        IS_TEXT_UNICODE_ODD_LENGTH = 0x0200,
        IS_TEXT_UNICODE_DBCS_LEADBYTE = 0x0400,
        IS_TEXT_UNICODE_NULL_BYTES = 0x1000,

        IS_TEXT_UNICODE_UNICODE_MASK = 0x000F,
        IS_TEXT_UNICODE_REVERSE_MASK = 0x00F0,
        IS_TEXT_UNICODE_NOT_UNICODE_MASK = 0x0F00,
        IS_TEXT_UNICODE_NOT_ASCII_MASK = 0xF000
    }
    [SuppressUnmanagedCodeSecurity]
    class SafeNativeMethods
    {
        [DllImport("Advapi32", SetLastError = false)]
        internal static extern bool IsTextUnicode(byte[] buf, int len, ref IsTextUnicodeFlags opt);
    }
    public partial class Form1
    {

        public static bool isHex(string bString)
        {
            if (bString == "") return false;
            for (int i = 0; i < bString.Length; i++)
                if (!((bString[i] >= '0' && bString[i] <= '9') || (bString[i] >= 'a' && bString[i] <= 'f') || (bString[i] >= 'A' && bString[i] <= 'F')))
                    return false;
            return true;
        }



    }
}

