using System;
using System.Windows.Forms;

namespace TranslationTool
{
    public partial class Form3 : Form
    {

        public bool ProCh = false;
        Form1 _Form1;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 Frm)
        {
            InitializeComponent();
            _Form1 = Frm;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Form1.isHex(textBox1.Text) && !ProCh && (textBox1.Text.Length < 9))
            {
                    int Conv = Convert.ToInt32(textBox1.Text, 16);
                    ulong RVA = _Form1.PE.RAW2RVA((uint)Conv);
                    ProCh = true;
                    textBox2.Text = Form1.toHex(RVA);
                    textBox3.Text = Form1.toHex(RVA + _Form1.PE.NtHeader.OptionalHeader.ImageBase);
                    ProCh = false;
            }

        }
        private void Form3_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Form1.isHex(textBox2.Text) && !ProCh && textBox2.Text.Length < 9)
            {
                    int Conv = Convert.ToInt32(textBox2.Text, 16);
                    ulong RAW = _Form1.PE.RVA2RAW(Conv);
                    ProCh = true;
                    textBox1.Text = Form1.toHex(RAW);
                    textBox3.Text = Form1.toHex((ulong)Conv + _Form1.PE.NtHeader.OptionalHeader.ImageBase);
                    ProCh = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (Form1.isHex(textBox3.Text) && !ProCh && textBox3.Text.Length < 9)
            {
                    int Conv = Convert.ToInt32(textBox3.Text, 16);
                    ulong RAW = _Form1.PE.VA2RAW((ulong)Conv);
                    if((ulong)Conv  > _Form1.PE.NtHeader.OptionalHeader.ImageBase)
                    {
                        ProCh = true;
                        textBox1.Text = Form1.toHex(RAW);
                        textBox2.Text = Form1.toHex((ulong)Conv - _Form1.PE.NtHeader.OptionalHeader.ImageBase);
                        ProCh = false;
                    }
            }
        }
    }
}
