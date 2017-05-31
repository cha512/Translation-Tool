using System;
using System.Text;
using System.Windows.Forms;

namespace TranslationTool
{
    public partial class Form2 : Form
    {
        public ulong dstAddr = 0; //이것은 RAW다.
        public ulong uOperandRAW = 0;
        public ulong NowCount = 0;
        public string OrgAutoString = null;
        YandexTranslate YandexT;

        Form1 _Form1;


        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 Form)
        {
            _Form1 = Form;

            if (_Form1.YandexKey != null)
                YandexT = new YandexTranslate(_Form1.YandexKey);


            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(_Form1.Location.X + _Form1.Width, _Form1.Location.Y);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_Form1.YandexKey != null)
            {
                string Lang = YandexT.Detect(textBox7.Text);
                textBox1.Text = YandexT.Translate("ko", textBox7.Text)[0].ToString();
            }
            else
            {
                MessageBox.Show("얀덱스 Key 가 없습니다. 메인화면의 설정에서 설정해 주십시요.");
            }
        }

        string GetUnicodeString(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                sb.Append("\\u");
                sb.Append(String.Format("{0:x4}", (int)c));
            }
            return sb.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 설정

            // 같은주소 수정하면 삭제하고 다시반영
            _Form1.StringCon.RemoveAll(element => element.uOperand_RAW == dstAddr);

            StringControl a = new StringControl();
            a.uOperand_RAW = uOperandRAW;
            a.uString_RAW = dstAddr;
            a.szString = textBox6.Text;
            a.isUnicode = checkBox1.Checked;
            _Form1.StringCon.Add(a);

            // 임시로 수정한걸 보여준다.
            // 여기서 유니코드로 변환하는대 왜 안짤리고 나오는거죠.
            if (checkBox1.Checked)
            {
                // 유니코드
                // 유니코드인데 아스키로 보일일 없지 않나?
                // 번역할떄 유니-> 유니, ANSI - ANSI 기 원칙.
                _Form1.lvItem.SubItems[2].Text = null;
                _Form1.lvItem.SubItems[3].Text = textBox6.Text;
            }
            else
            {
                // ANSI
                _Form1.lvItem.SubItems[2].Text = textBox6.Text;
                _Form1.lvItem.SubItems[3].Text = null;
            }


            if (checkBox1.Checked)
            {
                // 유니코드면
                byte[] OrgByte = _Form1.PE.UnicodeBinaryCopy(dstAddr);
                byte[] StrByte = Encoding.Default.GetBytes(textBox6.Text);
                if (OrgByte.Length >= StrByte.Length)
                {
                    this.Close();
                    return;
                }
            }
            else
            {
                byte[] OrgByte = _Form1.PE.ANSIBinaryCopy(dstAddr);
                byte[] StrByte = Encoding.Default.GetBytes(textBox6.Text);

                if (OrgByte.Length >= StrByte.Length)
                {
                    this.Close();
                    return;
                }
            }


            // 여기에 고치면 필터링 해서 전부다 바꿔주게해야함
            // 찾아서 구조체에 추가만 시키면됨



            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox7.Text = textBox12.Text;
            }
            else
            {
                textBox7.Text = OrgAutoString;
            }
        }
    }
}
