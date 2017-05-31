using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TranslationTool
{
    /*
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_EXPORT_DIRECTORY
    {
        public UInt32 Characteristics;
        public UInt32 TimeDateStamp;
        public UInt16 MajorVersion;
        public UInt16 MinorVersion;
        public UInt32 Name;
        public UInt32 Base;
        public UInt32 NumberOfFunctions;
        public UInt32 NumberOfNames;
        public UInt32 AddressOfFunctions;
        public UInt32 AddressOfNames;
        public UInt32 AddressOfNameOrdinals;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_IMPORT_BY_NAME
    {
        public short Hint;
        public byte Name;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORYMODULE
    {
        public IMAGE_NT_HEADERS headers;
        public IntPtr codeBase;
        public IntPtr modules;
        public int numModules;
        public int initialized;

    }
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_BASE_RELOCATION
    {
        public uint VirtualAddress;
        public uint SizeOfBlock;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_IMPORT_DESCRIPTOR
    {
        public uint CharacteristicsOrOriginalFirstThunk;
        public uint TimeDateStamp;
        public uint ForwarderChain;
        public uint Name;
        public uint FirstThunk;
    }*/

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IMAGE_SECTION_HEADER
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Name;
        public uint VirtualSize;
        public uint VirtualAddress;
        public uint SizeOfRawData;
        public uint PointerToRawData;
        public uint PointerToRelocations;
        public uint PointerToLinenumbers;
        public short NumberOfRelocations;
        public short NumberOfLinenumbers;
        public DataSectionFlags Characteristics;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct IMAGE_DOS_HEADER
    {
        public UInt16 e_magic;
        public UInt16 e_cblp;
        public UInt16 e_cp;
        public UInt16 e_crlc;
        public UInt16 e_cparhdr;
        public UInt16 e_minalloc;
        public UInt16 e_maxalloc;
        public UInt16 e_ss;
        public UInt16 e_sp;
        public UInt16 e_csum;
        public UInt16 e_ip;
        public UInt16 e_cs;
        public UInt16 e_lfarlc;
        public UInt16 e_ovno;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt16[] e_res1;
        public UInt16 e_oemid;
        public UInt16 e_oeminfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public UInt16[] e_res2;
        public Int32 e_lfanew;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IMAGE_DATA_DIRECTORY
    {
        public UInt32 VirtualAddress;
        public UInt32 Size;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IMAGE_OPTIONAL_HEADER32
    {
        public UInt16 Magic;
        public Byte MajorLinkerVersion;
        public Byte MinorLinkerVersion;
        public UInt32 SizeOfCode;
        public UInt32 SizeOfInitializedData;
        public UInt32 SizeOfUninitializedData;
        public UInt32 AddressOfEntryPoint;
        public UInt32 BaseOfCode;
        public UInt32 BaseOfData;
        public UInt32 ImageBase;
        public UInt32 SectionAlignment;
        public UInt32 FileAlignment;
        public UInt16 MajorOperatingSystemVersion;
        public UInt16 MinorOperatingSystemVersion;
        public UInt16 MajorImageVersion;
        public UInt16 MinorImageVersion;
        public UInt16 MajorSubsystemVersion;
        public UInt16 MinorSubsystemVersion;
        public UInt32 Win32VersionValue;
        public UInt32 SizeOfImage;
        public UInt32 SizeOfHeaders;
        public UInt32 CheckSum;
        public UInt16 Subsystem;
        public UInt16 DllCharacteristics;
        public UInt32 SizeOfStackReserve;
        public UInt32 SizeOfStackCommit;
        public UInt32 SizeOfHeapReserve;
        public UInt32 SizeOfHeapCommit;
        public UInt32 LoaderFlags;
        public UInt32 NumberOfRvaAndSizes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public IMAGE_DATA_DIRECTORY[] DataDirectory;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IMAGE_FILE_HEADER
    {
        public UInt16 Machine;
        public UInt16 NumberOfSections;
        public UInt32 TimeDateStamp;
        public UInt32 PointerToSymbolTable;
        public UInt32 NumberOfSymbols;
        public UInt16 SizeOfOptionalHeader;
        public UInt16 Characteristics;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_NT_HEADERS
    {
        public UInt32 Signature;
        public IMAGE_FILE_HEADER FileHeader;
        public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
    }

    [Flags]
    public enum DataSectionFlags : uint
    {
        TypeReg = 0x00000000,
        TypeDsect = 0x00000001,
        TypeNoLoad = 0x00000002,
        TypeGroup = 0x00000004,
        IMAGE_SCN_TYPE_NO_PAD = 0x00000008,
        TypeCopy = 0x00000010,
        IMAGE_SCN_CNT_CODE = 0x00000020,
        IMAGE_SCN_CNT_INITIALIZED_DATA = 0x00000040,
        IMAGE_SCN_CNT_UNINITIALIZED_DATA = 0x00000080,
        IMAGE_SCN_LNK_OTHER = 0x00000100,
        LinkInfo = 0x00000200,
        TypeOver = 0x00000400,
        IMAGE_SCN_LNK_REMOVE = 0x00000800,
        IMAGE_SCN_LNK_COMDAT = 0x00001000,
        IMAGE_SCN_NO_DEFER_SPEC_EXC = 0x00004000,
        IMAGE_SCN_GPREL = 0x00008000,
        IMAGE_SCN_MEM_LOCKED = 0x00040000,
        MemoryPreload = 0x00080000,
        IMAGE_SCN_ALIGN_1BYTES = 0x00100000,
        IMAGE_SCN_ALIGN_2BYTES = 0x00200000,
        IMAGE_SCN_ALIGN_4BYTES = 0x00300000,
        IMAGE_SCN_ALIGN_8BYTES = 0x00400000,
        IMAGE_SCN_ALIGN_16BYTES = 0x00500000,
        IMAGE_SCN_ALIGN_32BYTES = 0x00600000,
        IMAGE_SCN_ALIGN_64BYTES = 0x00700000,
        IMAGE_SCN_ALIGN_128BYTES = 0x00800000,
        IMAGE_SCN_ALIGN_256BYTES = 0x00900000,
        IMAGE_SCN_ALIGN_512BYTES = 0x00A00000,
        IMAGE_SCN_ALIGN_1024BYTES = 0x00B00000,
        IMAGE_SCN_ALIGN_2048BYTES = 0x00C00000,
        IMAGE_SCN_ALIGN_4096BYTES = 0x00D00000,
        IMAGE_SCN_ALIGN_8192BYTES = 0x00E00000,
        IMAGE_SCN_LNK_NRELOC_OVFL = 0x01000000,
        IMAGE_SCN_MEM_DISCARDABLE = 0x02000000,
        IMAGE_SCN_MEM_NOT_CACHED = 0x04000000,
        IMAGE_SCN_MEM_NOT_PAGED = 0x08000000,
        IMAGE_SCN_MEM_SHARED = 0x10000000,
        IMAGE_SCN_MEM_EXECUTE = 0x20000000,
        IMAGE_SCN_MEM_READ = 0x40000000,
        IMAGE_SCN_MEM_WRITE = 0x80000000
    }

    public class CPE32
    {
        public byte[] FileBinary;
        public long dwFileLen;
        public ulong dwImageBase;
        string m_FilePath;
        public bool isCalled = false;

        public IMAGE_DOS_HEADER DosHeader = new IMAGE_DOS_HEADER();
        public IMAGE_NT_HEADERS NtHeader = new IMAGE_NT_HEADERS();
        IMAGE_SECTION_HEADER[] SecHeader;

        void BytesToStructure<T>(ref T obj, int plus)
        {
            int len = Marshal.SizeOf(obj);
            IntPtr i = Marshal.AllocHGlobal(len);
            Marshal.Copy(FileBinary, plus, i, len);
            obj = (T)Marshal.PtrToStructure(i, typeof(T));
            Marshal.FreeHGlobal(i);
        }
        void StructureToBytes(int pos, object obj)
        {
            int len = Marshal.SizeOf(obj);
            IntPtr ptr = Marshal.AllocHGlobal(len);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, FileBinary, pos, len);
            Marshal.FreeHGlobal(ptr);
        }
        //SaveBinary 도 그렇고 이런식으로 하면댐
        public bool ReadBinary(string szFilePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(szFilePath, FileMode.Open, FileAccess.Read);
                dwFileLen = fs.Length;
                FileBinary = new byte[dwFileLen];
                using (BinaryReader br = new BinaryReader(fs))
                {
                    fs = null;
                    FileBinary = br.ReadBytes((int)dwFileLen);
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
            
           
            m_FilePath = szFilePath;

            // PE 읽기
            BytesToStructure(ref DosHeader, 0);          
            BytesToStructure(ref NtHeader, DosHeader.e_lfanew);


            ReadSection();
            
            dwImageBase = NtHeader.OptionalHeader.ImageBase;
            isCalled = true;
            if (CheckPE())
                return true;
            return false;
        }

        public void Close()
        {
            isCalled = false;
        }
        public void ReadSection()
        {
            ushort NumberOfSections = NtHeader.FileHeader.NumberOfSections;
            SecHeader = new IMAGE_SECTION_HEADER[NumberOfSections];
            for (ushort i = 0; i < NumberOfSections; i++)
                BytesToStructure(ref SecHeader[i], DosHeader.e_lfanew + 248 + 40 * i);
        }
        public byte[] BinaryCopy(ulong dwStart, ulong dwEnd)
        {
            if (dwEnd > (ulong)dwFileLen)
                dwEnd = (ulong)dwFileLen - 1;
            byte[] Arr = new byte[dwEnd - dwStart + 1];
            Buffer.BlockCopy(FileBinary, (int)dwStart, Arr, 0, (int)(dwEnd - dwStart + 1));
            return Arr;
        }
        public byte[] ANSIBinaryCopy(ulong dwStart)
        {
            ulong dwEnd = 0;
            dwEnd = dwStart;
            while (dwEnd+1 < (ulong)dwFileLen)
            {
                if (FileBinary[dwEnd+1] == 0)
                    break;
                dwEnd++;
            }
            return BinaryCopy(dwStart, dwEnd);
        }
        public byte[] UnicodeBinaryCopy(ulong dwStart)
        {
            ulong dwEnd = 0;
            dwEnd = dwStart;
            while (dwEnd+1 < (ulong)dwFileLen)
            {
                if (FileBinary[dwEnd] == 0 && FileBinary[dwEnd+1] == 0) 
                    break;
                dwEnd+=2;
            }
            return BinaryCopy(dwStart, dwEnd-1);
        }


        public ulong GetFirstRVA() => (SecHeader[0].VirtualAddress);
        public ulong GetFirstSize() => (SecHeader[0].SizeOfRawData);

        public ulong RVA2RAW<T>(T RVA)
        {
            ulong dwRVA = (ulong)Convert.ToInt32(RVA);
            ulong i = 0;

            for (i = 0; i < NtHeader.FileHeader.NumberOfSections - (ulong)1; i++)
            {
                if ((dwRVA >= SecHeader[i].VirtualAddress) && (dwRVA < SecHeader[i + 1].VirtualAddress))
                    return (dwRVA - SecHeader[i].VirtualAddress) + SecHeader[i].PointerToRawData;
            }
            if (dwRVA < SecHeader[i].VirtualAddress + NtHeader.OptionalHeader.SectionAlignment)
                return dwRVA - SecHeader[i].VirtualAddress + SecHeader[i].PointerToRawData;
            
            return 0;
        }
        public ulong RAW2RVA(ulong dwRAW)
        {

            ulong i = 0;
            for (i = 0; i < NtHeader.FileHeader.NumberOfSections; i++)
            {
                if ((dwRAW >= SecHeader[i].PointerToRawData) && (dwRAW < (SecHeader[i].PointerToRawData + SecHeader[i].SizeOfRawData)))
                    return (dwRAW - SecHeader[i].PointerToRawData) + SecHeader[i].VirtualAddress;
            }
            return 0;
        }
        public ulong VA2RAW(ulong VirtualAddress)
        {
            if (VirtualAddress < dwImageBase) return 0;
            if (VirtualAddress > 0xffffffff) return 0;
            ulong RAW = RVA2RAW(VirtualAddress - dwImageBase);
            if (RAW > (ulong)dwFileLen) return 0;
            return RAW;
        }

        ulong VirtualAlign(ulong Value)
        {
            if (NtHeader.OptionalHeader.SectionAlignment != 0)
                if ((Value % NtHeader.OptionalHeader.SectionAlignment) != 0)
                {
                    return (Value + NtHeader.OptionalHeader.SectionAlignment) - (Value % NtHeader.OptionalHeader.SectionAlignment);
                }
            return Value;
        }
        private ulong RawAlign(ulong Value)
        {
            if ((NtHeader.OptionalHeader.FileAlignment != 0) && ((Value % (NtHeader.OptionalHeader.FileAlignment)) != 0))
            {
                return ((Value + NtHeader.OptionalHeader.FileAlignment) - (Value % (NtHeader.OptionalHeader.FileAlignment)));
            }
            return Value;
        }
        public string Left(string sString, int nLength)
        {
            string sReturn;
            if (nLength > sString.Length)
                nLength = sString.Length;
            sReturn = sString.Substring(0, nLength);
            return sReturn;
        }

        public ulong AddString(ulong RAW , string str , bool isUnicode = false)
        {
            byte[] StrBytes;
            ulong Result;

            if (isUnicode)
            {
                StrBytes = Encoding.Unicode.GetBytes(str);
                Result = (ulong)(StrBytes.Length + 2);
            }
            else
            {
                StrBytes = Encoding.Default.GetBytes(str);
                Result = (ulong)(StrBytes.Length + 1);
            }
            Buffer.BlockCopy(StrBytes, 0, FileBinary, (int)RAW, StrBytes.Length);

            return Result;
        }
        public IMAGE_SECTION_HEADER AddSection(string szSectionName, ulong uSize, DataSectionFlags Flag)
        {
            // 섹션을 한칸 늘리고 SizeOfImage 를 추가함 다시 읽어옴
            NtHeader.FileHeader.NumberOfSections++;
            NtHeader.OptionalHeader.SizeOfImage += (uint)VirtualAlign(uSize);

            /*
            #define IMAGE_DIRECTORY_ENTRY_EXPORT          0   // Export Directory
            #define IMAGE_DIRECTORY_ENTRY_IMPORT          1   // Import Directory
            #define IMAGE_DIRECTORY_ENTRY_RESOURCE        2   // Resource Directory
            #define IMAGE_DIRECTORY_ENTRY_EXCEPTION       3   // Exception Directory
            #define IMAGE_DIRECTORY_ENTRY_SECURITY        4   // Security Directory
            #define IMAGE_DIRECTORY_ENTRY_BASERELOC       5   // Base Relocation Table
            #define IMAGE_DIRECTORY_ENTRY_DEBUG           6   // Debug Directory
            #define IMAGE_DIRECTORY_ENTRY_ARCHITECTURE    7   // Architecture Specific Data
            #define IMAGE_DIRECTORY_ENTRY_GLOBALPTR       8   // RVA of GP
            #define IMAGE_DIRECTORY_ENTRY_TLS             9   // TLS Directory
            #define IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG    10   // Load Configuration Directory
            #define IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT   11   // Bound Import Directory in headers
            #define IMAGE_DIRECTORY_ENTRY_IAT            12   // Import Address Table
            #define IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT   13   // Delay Load Import Descriptors
            #define IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR 14   // COM Runtime descriptor
            #define IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR 14   // COM Runtime descriptor
            */

            // 그냥 샘.
            NtHeader.OptionalHeader.DataDirectory[11].VirtualAddress = 0;
            NtHeader.OptionalHeader.DataDirectory[11].Size = 0;
            
            StructureToBytes(DosHeader.e_lfanew, NtHeader);
            ReadSection();

            // 섹션을 작성함
            ulong LastSection = (ulong)NtHeader.FileHeader.NumberOfSections - 1;
            byte[] tmpSecName = Encoding.ASCII.GetBytes(szSectionName);
            byte[] StrByte = new byte[8];
            Buffer.BlockCopy(tmpSecName, 0, StrByte, 0, tmpSecName.Length);

            SecHeader[LastSection].Name = StrByte;
            SecHeader[LastSection].VirtualAddress = (uint)VirtualAlign(SecHeader[LastSection - 1].VirtualAddress + SecHeader[LastSection - 1].VirtualSize);
            SecHeader[LastSection].VirtualSize = (uint)VirtualAlign(uSize);
            SecHeader[LastSection].PointerToRawData = (uint)RawAlign(SecHeader[LastSection - 1].PointerToRawData + SecHeader[LastSection - 1].SizeOfRawData);
            SecHeader[LastSection].SizeOfRawData = (uint)RawAlign(uSize);
            SecHeader[LastSection].Characteristics = Flag;
            StructureToBytes(DosHeader.e_lfanew + 248 + 40 * (int)LastSection, SecHeader[LastSection]);

            // 바이너리 추가 (realloc)
            byte[] temp = new byte[FileBinary.Length + (uint)RawAlign(uSize)];
            FileBinary.CopyTo(temp, 0);
            FileBinary = new byte[temp.Length];
            temp.CopyTo(FileBinary, 0);
            return SecHeader[LastSection];
        }

        public bool SaveBinary()
        {
            SaveBinary(m_FilePath);
            return true;
        }

        public bool SaveBinary(string szFilePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(szFilePath, FileMode.Create, FileAccess.Write);
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    fs = null;
                    bw.Write(FileBinary);
                }
            }
            finally
            {
                if(fs != null)
                    fs.Dispose();
            }
            return true;
        }
        public bool CheckPE()
        {
            if(DosHeader.e_magic != 0x5A4D) // IMAGE_DOS_SIGNATURE
            {
                MessageBox.Show("해당 파일은 지원하지 않는 파일입니다. (코드:00000000)", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(DosHeader.e_lfanew > dwFileLen)
            {
                MessageBox.Show("해당 파일은 지원하지 않는 파일입니다. (코드:00000001)", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(NtHeader.Signature != 0x4550)
            {
                MessageBox.Show("해당 파일은 지원하지 않는 파일입니다. (코드:00000002)", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (NtHeader.FileHeader.Machine != 0x14C) //MachineType.I386
            {
                MessageBox.Show("해당 파일은 32비트 프로그램이 아닙니다. (코드:00000003)", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(NtHeader.OptionalHeader.DataDirectory[14].Size != 0)
            {
                MessageBox.Show("해당 파일은 지원하지 않는 형태의 파일입니다. (코드:00000004)", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }

}
