using System;
using System.Text;
using System.Windows.Forms;
using SharpDisasm;
using SharpDisasm.Udis86;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;

/*

    [나쯔]
프로그램을 번역해보신 분들은 알겠지만,
 프로그램 내부에서 동적으로 설정하는 문자들은 리소스 수정으로는 번역이 불가능합니다. 
 이것들을 헥스 에디터에서 수정하게 되면 뒤에 남는 자리가 없거나 바이트를 밀거나 하지 않는이상은 
 원본 바이트 보다 큰 문자열로는 수정이 불가능합니다. 
 이것 때문에 보통 하드 코딩된 문자열들을 수정할 때는 Radialix 와 RDMAP(IDA 5.x 플러그인)을 사용하지만 
 RDMAP 같은 경우는 중국어(ANSI, CP936) 쪽에서 감지가 불안정합니다.
 그래서 이 단점을 해결하기위해 저와 지인이 제작한 [TranslationTool] 입니다. 

 이 프로그램은, 바이너리에 저장되어있는 값(PUSH, MOV...)들을 감지하여 리스트에 추가하며 더블클릭하면 수정할 수 있습니다.
 현재 버전에서는 한국어, 중국어(간, 번체), 유니코드, 영어를 지원하며, 
 얀덱스 번역 API를 연동하여 API Key를 설정하시면 클릭 한 번으로 번역이 가능 합니다. 
 아직 초기 버전이다 보니, 버그가 많을 수도 있습니다. 
 그러니 아직 큰 번역 프로젝트에는 사용하는 것을 권장 드리지 않습니다. 
 소소하게 테스트해보고 혹시 버그가 있으면 해당 파일과 스크린샷 을 쪽지나 메일 등으로 보내주시면 감사하겠습니다.

 네이버 : ~~
 메신저 : ~~


   [오이콩]
프로그램을 번역해보신 분들은 알겠지만,
프로그램 내부에서 하드코딩된 값들은 리소스 수정으로는 번역이 불가능합니다.
이것들을 헥스 에디터에서 수정하게 되면 원본 바이트 보다 큰 문자열로는 수정이 불가능합니다.
이것 때문에 보통 하드 코딩된 문자열들을 수정할 때는 Radialix 와 RDMAP(IDA 5.x 플러그인)을 이용합니다.
그러나 이 RDMAP 플러그인을 이용하면 영어는 매우 잘 감지하나 중국어(ANSI, CP936) 같은 경우 에는 거의 감지가 불가능합니다.
그러나 저와 지인이 이번에 만든 TranslationTool 을 사용하게 되면 이런 문제가 해결됩니다.
내부적으로 하드 코딩된 값들을(PUSH, MOV...) 추출-감지하여 리스트에 추가 하고 리스트를 더블클릭하면 수정할 수 있습니다.
현재 버전에서는 한국어, 중국어(간, 번체), 유니코드, 영어를 지원하며, 
얀덱스 번역 API를 연동하여 API Key를 설정하시면 클릭 한 번으로 번역이 가능 합니다.
아직 초기 버전이다 보니, 버그가 많을 수도 있습니다. 그러니 아직 큰 번역 프로젝트에는 사용하는 것을 권장 드리지 않습니다.
소소하게 테스트해보고 혹시 버그가 있으면 해당 파일과 스크린숏 을 쪽지나 메일 등으로 보내주시면 감사하겠습니다.

    Form2 마무리좀

 */
namespace TranslationTool
{

    public struct StringControl
    {
        public ulong uOperand_RAW;  // PUSH "AAAA" 의 "AAAA" 자리의 포인터 주소
        public ulong uString_RAW;   // 문자열 주소   
        public string szString;     // 문자열
        public bool isUnicode;      // 쓸 문자열이 유니코드인가?
    }


    public partial class Form1 : Form
    {
        // APP 정보
        public string APP_NAME = "Translation";
        public string APP_VERSION = "0.2 Beta";
        public string APP_REG = "S_Translation";

        // 주소 상수
        const ulong ADDRESS_TYPE_RAW = 0;
        const ulong ADDRESS_TYPE_RVA = 1;
        const ulong ADDRESS_TYPE_VA = 2;

        // 레지
        const ulong REG_OK = 1;
        const ulong REG_NO = 0;

        // 파일정보
        public CPE32 PE = new CPE32();

        // 번역정보
        public string YandexKey = null;

        // 전역 버퍼
        public ListView.SelectedListViewItemCollection items;
        public ListViewItem lvItem;
        
        // 문자열 작업 구조체
        public List<StringControl> StringCon = new List<StringControl>();
        //문자열 리스트들..

        public List<string> LAddr = new List<string>();
        public List<string> LDis = new List<string>();
        public List<string> LStrA = new List<string>();
        public List<string> LStrU = new List<string>();


        int LngNum = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void ErrorInvalidValue()
        {
            MessageBox.Show("잘못된 값이 있습니다.");
        }

        private void SetMenuDetectString(object sender,int iCodePage)
        {
            ToolStripMenuItem ThisMenuItem = (ToolStripMenuItem)sender;
            if (!ThisMenuItem.Checked)
            {
                // 체크가 되어있지 않다면...
                MenuItem자동감지.Checked = false;
                MenuItem한국어.Checked = false;
                MenuItem중국어간체.Checked = false;
                MenuItem중국어번체.Checked = false;
                MenuItem일본어.Checked = false;
                MenuItem유니코드.Checked = false;
                MenuItem영어.Checked = false;
                ThisMenuItem.Checked = true;

                LngNum = iCodePage;
                Status.Text = ThisMenuItem.Tag.ToString();
            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = APP_NAME + " " +  APP_VERSION;

            // 메뉴 이벤트 핸들러 설정
            MenuItem자동감지.Click += (object a, EventArgs a1) => SetMenuDetectString(a, 0);
            MenuItem한국어.Click += (object a, EventArgs a1) => SetMenuDetectString(a, 949);
            MenuItem중국어간체.Click += (object a, EventArgs a1) => SetMenuDetectString(a, 936);
            MenuItem중국어번체.Click += (object a, EventArgs a1) => SetMenuDetectString(a, 950);
            MenuItem일본어.Click += (object a, EventArgs a1) => SetMenuDetectString(a, 932);
            MenuItem영어.Click += (object a, EventArgs a1) => SetMenuDetectString(a, 1252);
            MenuItem유니코드.Click += (object a, EventArgs a1) => SetMenuDetectString(a, 0);


            // 얀덱스 키를 불러옴
            RegistryKey Reg = Registry.LocalMachine.CreateSubKey("Software").CreateSubKey(APP_REG);
            object objValue = Reg.GetValue("YandexKey");
            if (objValue != null && objValue.GetType() == typeof(string))
                YandexKey = objValue.ToString();
            
            Reg.Close();
        }
        public static string ToHexString(ulong ouid) =>
            $"{ouid:X8}".ToUpper().Replace("0X", "0x");

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("제작자" + Environment.NewLine +
                            "나쯔(mp662002@naver.com)" + Environment.NewLine +
                            "오이콩(cha5126568@naver.com)\n\n" +
                            "버전 : 0.2 [베타버전]"
                , "TranslationTool", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //LEA 지원은 일단 버림.


        private void AddList(ulong dwStr2, string Address, string ASM)
        {
            if (MenuItem자동감지.Checked)
            {
                byte[] bString = PE.ANSIBinaryCopy(dwStr2);
                byte[] bString2 = PE.UnicodeBinaryCopy(dwStr2);
                string szString = null;

                if(CodePage.IsAscii(bString))
                    szString = Encoding.Default.GetString(bString);
                else if (CodePage.isCP949_asc(bString))
                    szString = Encoding.GetEncoding(949).GetString(bString);
                else if (CodePage.isCP936_asc(bString))
                    szString = Encoding.GetEncoding(936).GetString(bString);

                IsTextUnicodeFlags tmpU = IsTextUnicodeFlags.IS_TEXT_UNICODE_STATISTICS
                    | IsTextUnicodeFlags.IS_TEXT_UNICODE_ASCII16
                    | IsTextUnicodeFlags.IS_TEXT_UNICODE_CONTROLS;

                //높은 확률로 (바이트 배열로 10바이트 정도만 넘어가면 거의 100%) 유니코드면 여기 걸리나
                //안걸리수도 있다.
                if (SafeNativeMethods.IsTextUnicode(bString2, bString2.Length, ref tmpU))
                {
                    LAddr.Add(Address);
                    LDis.Add(ASM);
                    LStrA.Add(Encoding.Default.GetString(bString));
                    LStrU.Add(Encoding.Unicode.GetString(bString2));
                }
                else //유니코드가 아닐 가능성이 매우 높을때?
                {
                    //if (bString.Length <= 1) return;
                    if (szString == null && bString.Length > 9)
                    {
                        return;
                    }
                    if (CodePage.IsPrintAbleStr(bString) == false) return;
                    LAddr.Add(Address);
                    LDis.Add(ASM);
                    LStrA.Add(szString);
                    LStrU.Add("");
                }

            }
            else if(MenuItem영어.Checked)
            {
                byte[] bString = PE.ANSIBinaryCopy(dwStr2);
                string szString = Encoding.Default.GetString(bString);

                if (CodePage.IsAscii(bString) == false) return;
                if (bString.Length == 1) return;
                
                LAddr.Add(Address);
                LDis.Add(ASM);
                LStrA.Add(szString);
                LStrU.Add("");
            }
            else if(MenuItem유니코드.Checked)
            {
                byte[] bString2 = PE.UnicodeBinaryCopy (dwStr2);
                LAddr.Add(Address);
                LDis.Add(ASM);
                LStrA.Add("");
                LStrU.Add(Encoding.Unicode.GetString(bString2));
            }
            else
            {
                byte[] bString = PE.ANSIBinaryCopy(dwStr2);
                string szString = Encoding.GetEncoding(LngNum).GetString(bString);
                if (bString.Length == 1) return;
                if (CodePage.IsPrintAbleStr(bString) == false) return;
                LAddr.Add(Address);
                LDis.Add(ASM);
                LStrA.Add(szString);
                LStrU.Add("");
            }


        }
        private uint GetAsmByte(ulong RAW)
        {
            //비트로 하면 간단한데 비트 접근이 웰케 귀찮을까
            if (PE.FileBinary[RAW] == 0x68) //PUSH
                return 5;
            else if (PE.FileBinary[RAW] >= 0xB8 && PE.FileBinary[RAW] <= 0xBF)
                return 5;
            else if (PE.FileBinary[RAW] == 0xC7 && PE.FileBinary[RAW+1] >= 0x00 && PE.FileBinary[RAW + 1] <= 0x07)
                return 6;
            else if (PE.FileBinary[RAW] == 0xC7 && PE.FileBinary[RAW + 1] >= 0x40 && PE.FileBinary[RAW + 1] <= 0x47)
                return 7;
            else if (PE.FileBinary[RAW] == 0xC7 && PE.FileBinary[RAW + 1] >= 0x80 && PE.FileBinary[RAW + 1] <= 0x87)
                return 10;
            return 0;
        }
        private uint UpdateList(byte[] AsmArr,ulong BaseAddr)
        {
            ArchitectureMode architecture = ArchitectureMode.x86_32;
            Disassembler.Translator.IncludeAddress = false;
            Disassembler.Translator.IncludeBinary = false;
            Disassembler disassembler = new Disassembler(AsmArr, architecture, BaseAddr, true, Vendor.Any);
            uint num = 0;
            try
            {
                foreach (Instruction instruction in disassembler.Disassemble())
                {
                    num += (uint)instruction.Length;
                    if (((instruction.Mnemonic == ud_mnemonic_code.UD_Ipush) &&
                        (instruction.Operands[0].Type == ud_type.UD_OP_IMM)) &&
                       (instruction.itab_entry.Operand2.size != ud_operand_size.SZ_B))
                    {
                        string address = ToHexString(instruction.Offset);
                        string ASM = instruction.ToString().ToUpper().Replace("0X", "0x");
                        ulong RAW = PE.VA2RAW((ulong)instruction.Operands[0].Value);
                        if (RAW != 0)
                        {
                            if (PE.FileBinary[RAW] != 0)
                                AddList(RAW, address, ASM);
                        }
                    }
                    if (((instruction.Mnemonic == ud_mnemonic_code.UD_Imov) &&
                       (instruction.Operands[1].Type == ud_type.UD_OP_IMM)) &&
                       (instruction.itab_entry.Operand2.size != ud_operand_size.SZ_B))
                    {


                        string address2 = ToHexString(instruction.Offset);
                        string ASM2 = instruction.ToString().ToUpper().Replace("0X", "0x");
                        ulong RAW2 = PE.VA2RAW((ulong)instruction.Operands[1].Value);
                        if ((RAW2 != 0) && (PE.FileBinary[RAW2] != 0))
                        {
                            AddList(RAW2, address2, ASM2);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return num;
            }
            return 0;
        }
        private void GoForm3(ListView List)
        {
            Form2 _Form2 = new Form2(this);
            items = List.SelectedItems;
            lvItem = items[0];

            

            string[] words = lvItem.SubItems[1].Text.Split(' ');
            ulong var = (uint)Convert.ToInt32(words[words.Length - 1], 16);
            ulong dwStr = PE.VA2RAW(var);

            ulong uOperandRAW = PE.VA2RAW((ulong)Convert.ToInt32(List.FocusedItem.Text, 16));


            if (dwStr != 0)
            {
                byte[] bString = PE.ANSIBinaryCopy(dwStr);
                byte[] bString2 = PE.UnicodeBinaryCopy(dwStr);

                _Form2.textBox7.Text = lvItem.SubItems[2].Text;
                _Form2.dstAddr = dwStr;
                _Form2.uOperandRAW = uOperandRAW;

                _Form2.NowCount = (ulong)List.SelectedItems[0].Index;
                _Form2.OrgAutoString = lvItem.SubItems[2].Text;
                _Form2.textBox10.Text = Encoding.Default.GetString(bString);
                _Form2.textBox11.Text = Encoding.GetEncoding(1252).GetString(bString);
                _Form2.textBox12.Text = Encoding.Unicode.GetString(bString2);
                _Form2.textBox8.Text = Encoding.GetEncoding(936).GetString(bString);
                _Form2.textBox9.Text = Encoding.GetEncoding(950).GetString(bString);
                _Form2.ShowDialog();
            }

        }
        public static string toHex(ulong i)
        {
            string hex = i.ToString("x"); // 대문자 X일 경우 결과 hex값이 대문자로 나온다.
            if (hex.Length % 2 != 0)
            {
                hex = "0" + hex;
            }
            if (hex.Substring(0, 1) == "0")
                hex = hex.Substring(1);
            return hex;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (PE.isCalled)
            {
                // 불러오기 버튼
                listView1.Items.Clear();
                listView2.Items.Clear();

                if (!isHex(textBox3.Text) || !isHex(textBox4.Text) || textBox3.Text.Length > 8 || textBox4.Text.Length > 8)
                {
                    ErrorInvalidValue();
                    return;
                }
                ulong BaseAddrVA = (ulong)(Convert.ToInt32(textBox3.Text, 16));
                ulong StartRAW = PE.VA2RAW(BaseAddrVA);
                ulong EndRAW = PE.VA2RAW((ulong)Convert.ToInt32(textBox4.Text, 16));
                if(StartRAW > EndRAW)
                {
                    ErrorInvalidValue();
                    return;
                }

                byte[] AsmArr = PE.BinaryCopy(StartRAW, EndRAW);

                
                uint UpdateRet = UpdateList(AsmArr, BaseAddrVA);
                uint StartError = UpdateRet + (uint)StartRAW + 1;
                while (UpdateRet != 0)
                {
                    
                    AsmArr = PE.BinaryCopy(StartError, EndRAW);
                    UpdateRet = UpdateList(AsmArr, BaseAddrVA + StartError - StartRAW);
                    StartError += UpdateRet + 1;
                    GC.Collect(); //메모리 덕분에 강제로 콜렉팅 함
                }
                //LAddr ,LDis ,LStrA ,LStrU 
                /* 여기서 내가 만들어둔 저 리스트들에서... LDis 에서 PUSH 포인터
                   이게 나보다 위에서 나온적이 있으면...LDupList 에 추가. :LAddr,Ldis,LStrA,LStrU 에서 삭제.
                 */
                /*
               int count = LDis.Count;
               string[] words,words2;
               ulong Tmp,Tmp2;

               //중복제거 버튼
               if (chkdup.Checked)
               {
                   for(int i =0;i < count; i++)
                   {
                       for(int j=0;j<i; j++)
                       {
                           if (i >= count)
                               continue;
                           //느리다.
                           words = LDis[j].Split(' ');
                           words2 = LDis[i].Split(' ');
                           Tmp = (uint)Convert.ToInt32(words[words.Length - 1], 16);
                           Tmp2 = (uint)Convert.ToInt32(words2[words2.Length - 1], 16);
                           if (Tmp == Tmp2) 
                           {

                                //* 중복리스트에 추가를...
                               LAddr.RemoveAt(i);
                               LDis.RemoveAt(i);
                               LStrA.RemoveAt(i);
                               LStrU.RemoveAt(i);
                               j--;
                               count--;
                           }
                       }
                   }
               }*/

                listView1.BeginUpdate();
                for(int i=0;i<LDis.Count;i++)
                {
                    ListViewItem lvt = new ListViewItem(LAddr[i])
                    {
                        SubItems = { LDis[i], LStrA[i], LStrU[i] }
                    };
                    listView1.Items.Add(lvt);
                }


                listView1.EndUpdate();

                GC.Collect();//메모리 덕분에 강제로 콜렉팅 함222


            }
            else
            {
                MessageBox.Show("메뉴의 열기로 파일을 열어주십시요","알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        { 

            if(PE.isCalled)
            {
                MessageBox.Show("열려져 있는 파일이 이미 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            OpenFileDialog Open = new OpenFileDialog();
            Open.Filter = "EXE File(*.exe)|*.exe";
            Open.Title = "원하시는 파일을 선택해 주세요";
            if(Open.ShowDialog() == DialogResult.OK)
            {
                if (PE.ReadBinary(Open.FileName))
                {
                    Status.Text = "파일이 정상적으로 열렸습니다.";
                }
                else
                {
                    Status.Text = "해당 파일은 지원하지 않는 파일입니다.";
                    PE.Close();
                }

            }
            else
                Status.Text = "파일 열기가 취소되었습니다.";



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                listView1.Visible = true;
                listView2.Visible = false;
            }
            else
            {
                listView2.BeginUpdate();
                listView2.Items.Clear();
                listView1.Visible = false;
                listView2.Visible = true;
                if (PE.isCalled)
                {
                    for (int i = 0; i < listView1.Items.Count; i++) 
                    {
                        string NowText = listView1.Items[i].SubItems[2].Text;
                        string NowText2 = listView1.Items[i].SubItems[3].Text;
                        if (NowText.Contains(textBox1.Text) || (NowText2.Contains(textBox1.Text)))
                        {
                            ListViewItem lvt2 = new ListViewItem(listView1.Items[i].SubItems[0].Text);
                            lvt2.SubItems.Add(listView1.Items[i].SubItems[1].Text);
                            lvt2.SubItems.Add(listView1.Items[i].SubItems[2].Text);
                            lvt2.SubItems.Add(listView1.Items[i].SubItems[3].Text);
                            listView2.Items.Add(lvt2);
                        }
                    }
                }
                listView2.EndUpdate();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            GoForm3(listView1);
        }


        private void 얀덱스ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 번역 설정
            if(얀덱스ToolStripMenuItem.Checked)
            {
                얀덱스ToolStripMenuItem.Checked = false;
            }
            else
            {
                if (YandexKey == null)
                {
                    if (MessageBox.Show(
                        "얀덱스API 를 사용하기위한 Key값이 없습니다. 설정하시겠습니까?\n" +
                        "설정값은 번역 Key 설정에서 바꾸실수 있습니다.", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        frmAPI ApiForm = new frmAPI(this);
                        ApiForm.Show();
                        if (YandexKey != null) 얀덱스ToolStripMenuItem.Checked = true;
                    }


                }
            }
            
        }

        private void 얀덱스ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAPI ApiForm = new frmAPI(this);
            ApiForm.Show();
        }


        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!PE.isCalled)
            {
                MessageBox.Show("파일을 열어주십시요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ulong TotLen = 0;
            bool NeedNewSec = false;

            for (int i = 0; i < StringCon.Count; i++)
            {
                if (StringCon[i].isUnicode == false)
                {
                    byte[] OrgByte = PE.ANSIBinaryCopy(StringCon[i].uString_RAW);
                    byte[] StrByte = Encoding.Default.GetBytes(StringCon[i].szString);
                    if (OrgByte.Length < StrByte.Length)
                    {
                        TotLen += (ulong)StrByte.Length + 1;
                        NeedNewSec = true;
                    }
                }
                else
                {
                    byte[] OrgByte = PE.UnicodeBinaryCopy(StringCon[i].uString_RAW);
                    byte[] StrByte = Encoding.Unicode.GetBytes(StringCon[i].szString);
                    TotLen += (ulong)StrByte.Length + 2;
                    if (OrgByte.Length < StrByte.Length)
                    {
                        TotLen += (ulong)StrByte.Length + 2;
                        NeedNewSec = true;
                    }
                }

            }
            ulong rawOffset = 0;
            if (NeedNewSec)
            {
                IMAGE_SECTION_HEADER Section = PE.AddSection("__Tool__", TotLen, DataSectionFlags.IMAGE_SCN_MEM_READ);
                rawOffset = Section.PointerToRawData;
            }              
            for (int i = 0; i < StringCon.Count; i++)
            {
                //ANSI 모드
                if (StringCon[i].isUnicode == false) //이건 OK
                {
                    byte[] OrgByte = PE.ANSIBinaryCopy(StringCon[i].uString_RAW);
                    byte[] StrByte = Encoding.Default.GetBytes(StringCon[i].szString);
                    if (OrgByte.Length >= StrByte.Length)
                    {
                        Buffer.BlockCopy(StrByte, 0, PE.FileBinary, (int)StringCon[i].uString_RAW, StrByte.Length);
                        PE.FileBinary[StringCon[i].uString_RAW + (ulong)StrByte.Length] = 0x00;
                    }
                    else //PUSH 나 MOV 주소를 바꿔야 하는경우.
                    {
                        ulong vaOffset = PE.RAW2RVA(rawOffset) + PE.dwImageBase;
                        uint asmbytes = GetAsmByte(StringCon[i].uOperand_RAW);
                        PE.FileBinary[StringCon[i].uOperand_RAW + asmbytes - 4] = (byte)(vaOffset & 0xFF);
                        PE.FileBinary[StringCon[i].uOperand_RAW + asmbytes - 3] = (byte)((vaOffset & 0xFFFF) >> 8);
                        PE.FileBinary[StringCon[i].uOperand_RAW + asmbytes - 2] = (byte)((vaOffset & 0xFFFFFF) >> 16);
                        PE.FileBinary[StringCon[i].uOperand_RAW + asmbytes - 1] = (byte)((vaOffset & 0xFFFFFFFF) >> 24);
                        rawOffset += PE.AddString(rawOffset, StringCon[i].szString);
                    }
                }
                else //윤희코드 모드.
                {
                    byte[] OrgByte = PE.UnicodeBinaryCopy(StringCon[i].uString_RAW);
                    byte[] StrByte = Encoding.Unicode.GetBytes(StringCon[i].szString);
                    if (OrgByte.Length >= StrByte.Length)
                    {
                        Buffer.BlockCopy(StrByte, 0, PE.FileBinary, (int)StringCon[i].uString_RAW, StrByte.Length);
                        PE.FileBinary[StringCon[i].uString_RAW + (ulong)StrByte.Length] = 0x00;
                        PE.FileBinary[StringCon[i].uString_RAW + (ulong)StrByte.Length + 1] = 0x00;
                    }
                    else
                    {
                        ulong vaOffset = PE.RAW2RVA(rawOffset) + PE.dwImageBase;
                        uint asmbytes = GetAsmByte(StringCon[i].uOperand_RAW);
                        PE.FileBinary[StringCon[i].uOperand_RAW + asmbytes - 4] = (byte)(vaOffset & 0xFF);
                        PE.FileBinary[StringCon[i].uOperand_RAW + asmbytes - 3] = (byte)((vaOffset & 0xFFFF) >> 8);
                        PE.FileBinary[StringCon[i].uOperand_RAW + asmbytes - 2] = (byte)((vaOffset & 0xFFFFFF) >> 16);
                        PE.FileBinary[StringCon[i].uOperand_RAW + asmbytes - 1] = (byte)((vaOffset & 0xFFFFFFFF) >> 24);
                        rawOffset += PE.AddString(rawOffset, StringCon[i].szString,true);
                    }
                }
            }


            SaveFileDialog Save = new SaveFileDialog();
            Save.Filter = "EXE File(*.exe)|*.exe";
            Save.Title = "어따 저장하실?";
            if (Save.ShowDialog() == DialogResult.OK)
                PE.SaveBinary(Save.FileName);
            else
                Status.Text = "파일 저장이 취소되었습니다.";
            
        }

        private void 주소변환ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form3 frm = new Form3(this);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 자동 설정 버튼
            if (PE.isCalled)
            {
                ulong FirstVA = (PE.dwImageBase + PE.GetFirstRVA());
                textBox3.Text = FirstVA.ToString("X8");
                textBox4.Text = (FirstVA + PE.GetFirstSize() - 1).ToString("X8");
            }
            else
            {
                MessageBox.Show("파일을 열어주십시요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            GoForm3(listView2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             * 여기서 중복되는 리스트를 제거해야한다.
             * 
             */
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (PE.isCalled)
            {
                MessageBox.Show("열려져 있는 파일이 이미 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (PE.ReadBinary(file[0]))
                {
                    Status.Text = "파일이 정상적으로 열렸습니다.";
                }
                else
                {
                    Status.Text = "해당 파일은 지원하지 않는 파일입니다.";
                    PE.Close();
                }

                //foreach (string str in file)
                //{
                //    this.textBox1.Text += str + "\r" + "\n";
                //}
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
            }
        }

        private void 영어ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}