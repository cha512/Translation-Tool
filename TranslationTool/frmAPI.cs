using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace TranslationTool
{
    public partial class frmAPI : Form
    {
        Form1 _Form1;

        public frmAPI()
        {
            InitializeComponent();
        }

        public frmAPI(Form1 Frm)
        {
            _Form1 = Frm;
            InitializeComponent();
        }
        private void frmAPI_Load(object sender, EventArgs e)
        {
            if(_Form1.YandexKey != null)
            {
                textBox1.Text = _Form1.YandexKey;
            }
/*
            RegistryKey Reg = Registry.LocalMachine.CreateSubKey("Software").CreateSubKey(APP_REG);

            object objValue = Reg.GetValue(RegName);

            if (objValue != null && objValue.GetType() == typeof(int))
            {
                Reg.Close();
                return ToULong(objValue);
            }

            // 없으면 만듬
            Reg.SetValue(RegName, DefaultValue, RegistryValueKind.DWord);
            Reg.Close();
*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 설정
            RegistryKey Reg = Registry.LocalMachine.CreateSubKey("Software").CreateSubKey(_Form1.APP_REG);
            Reg.SetValue("YandexKey",textBox1.Text, RegistryValueKind.String);
            Reg.Close();
            _Form1.YandexKey = textBox1.Text;
            MessageBox.Show("얀덱스 키가 설정되었습니다.");
            this.Close();
        }
    }
}
