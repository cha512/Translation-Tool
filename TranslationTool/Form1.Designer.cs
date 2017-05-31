namespace TranslationTool
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.기능ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.주소변환ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.기본언어설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem자동감지 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem한국어 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem중국어간체 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem중국어번체 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem일본어 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem유니코드 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem영어 = new System.Windows.Forms.ToolStripMenuItem();
            this.bing번역APIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.얀덱스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.구글ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.빙ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.번역Key설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.얀덱스ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.주소타입설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRAW = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRVA = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemVA = new System.Windows.Forms.ToolStripMenuItem();
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(28, 28);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(97, 23);
            this.textBox3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(131, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "~";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(158, 28);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(97, 23);
            this.textBox4.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "불러오기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 100);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(551, 257);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Address";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Disassembly";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "String";
            this.columnHeader4.Width = 152;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "String Unicode";
            this.columnHeader7.Width = 152;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.기능ToolStripMenuItem,
            this.설정ToolStripMenuItem,
            this.정보ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(577, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.저장SToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일ToolStripMenuItem.Text = "파일(&F)";
            this.파일ToolStripMenuItem.Click += new System.EventHandler(this.파일ToolStripMenuItem_Click);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.열기ToolStripMenuItem.Text = "열기(&O)";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장SToolStripMenuItem
            // 
            this.저장SToolStripMenuItem.Name = "저장SToolStripMenuItem";
            this.저장SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.저장SToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.저장SToolStripMenuItem.Text = "저장(&S)";
            this.저장SToolStripMenuItem.Click += new System.EventHandler(this.저장SToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 기능ToolStripMenuItem
            // 
            this.기능ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.주소변환ToolStripMenuItem});
            this.기능ToolStripMenuItem.Name = "기능ToolStripMenuItem";
            this.기능ToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.기능ToolStripMenuItem.Text = "기능(&I)";
            // 
            // 주소변환ToolStripMenuItem
            // 
            this.주소변환ToolStripMenuItem.Name = "주소변환ToolStripMenuItem";
            this.주소변환ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.주소변환ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.주소변환ToolStripMenuItem.Text = "주소변환";
            this.주소변환ToolStripMenuItem.Click += new System.EventHandler(this.주소변환ToolStripMenuItem_Click_1);
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.기본언어설정ToolStripMenuItem,
            this.bing번역APIToolStripMenuItem,
            this.번역Key설정ToolStripMenuItem,
            this.주소타입설정ToolStripMenuItem});
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.설정ToolStripMenuItem.Text = "설정(&S)";
            this.설정ToolStripMenuItem.Click += new System.EventHandler(this.설정ToolStripMenuItem_Click);
            // 
            // 기본언어설정ToolStripMenuItem
            // 
            this.기본언어설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem자동감지,
            this.MenuItem한국어,
            this.MenuItem중국어간체,
            this.MenuItem중국어번체,
            this.MenuItem일본어,
            this.MenuItem유니코드,
            this.MenuItem영어});
            this.기본언어설정ToolStripMenuItem.Name = "기본언어설정ToolStripMenuItem";
            this.기본언어설정ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.기본언어설정ToolStripMenuItem.Text = "기본언어 설정";
            // 
            // MenuItem자동감지
            // 
            this.MenuItem자동감지.Checked = true;
            this.MenuItem자동감지.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItem자동감지.Name = "MenuItem자동감지";
            this.MenuItem자동감지.Size = new System.Drawing.Size(142, 22);
            this.MenuItem자동감지.Tag = "자동감지로 설정되었습니다.";
            this.MenuItem자동감지.Text = "자동감지";
            // 
            // MenuItem한국어
            // 
            this.MenuItem한국어.Name = "MenuItem한국어";
            this.MenuItem한국어.Size = new System.Drawing.Size(142, 22);
            this.MenuItem한국어.Tag = "한국어로 설정되었습니다.";
            this.MenuItem한국어.Text = "한국어";
            // 
            // MenuItem중국어간체
            // 
            this.MenuItem중국어간체.Name = "MenuItem중국어간체";
            this.MenuItem중국어간체.Size = new System.Drawing.Size(142, 22);
            this.MenuItem중국어간체.Tag = "중국어(간체)로 설정되었습니다.";
            this.MenuItem중국어간체.Text = "중국어(간체)";
            // 
            // MenuItem중국어번체
            // 
            this.MenuItem중국어번체.Name = "MenuItem중국어번체";
            this.MenuItem중국어번체.Size = new System.Drawing.Size(142, 22);
            this.MenuItem중국어번체.Tag = "중국어(번체)로 설정되었습니다.";
            this.MenuItem중국어번체.Text = "중국어(번체)";
            // 
            // MenuItem일본어
            // 
            this.MenuItem일본어.Name = "MenuItem일본어";
            this.MenuItem일본어.Size = new System.Drawing.Size(142, 22);
            this.MenuItem일본어.Tag = "일본어로 설정되었습니다.";
            this.MenuItem일본어.Text = "일본어";
            // 
            // MenuItem유니코드
            // 
            this.MenuItem유니코드.Name = "MenuItem유니코드";
            this.MenuItem유니코드.Size = new System.Drawing.Size(142, 22);
            this.MenuItem유니코드.Tag = "유니코드로 설정되었습니다.";
            this.MenuItem유니코드.Text = "유니코드";
            // 
            // MenuItem영어
            // 
            this.MenuItem영어.Name = "MenuItem영어";
            this.MenuItem영어.Size = new System.Drawing.Size(142, 22);
            this.MenuItem영어.Tag = "영어로 설정되었습니다.";
            this.MenuItem영어.Text = "영어";
            this.MenuItem영어.Click += new System.EventHandler(this.영어ToolStripMenuItem_Click);
            // 
            // bing번역APIToolStripMenuItem
            // 
            this.bing번역APIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.얀덱스ToolStripMenuItem,
            this.구글ToolStripMenuItem,
            this.빙ToolStripMenuItem});
            this.bing번역APIToolStripMenuItem.Name = "bing번역APIToolStripMenuItem";
            this.bing번역APIToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bing번역APIToolStripMenuItem.Text = "번역 API 설정";
            // 
            // 얀덱스ToolStripMenuItem
            // 
            this.얀덱스ToolStripMenuItem.Name = "얀덱스ToolStripMenuItem";
            this.얀덱스ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.얀덱스ToolStripMenuItem.Text = "얀덱스";
            this.얀덱스ToolStripMenuItem.Click += new System.EventHandler(this.얀덱스ToolStripMenuItem_Click);
            // 
            // 구글ToolStripMenuItem
            // 
            this.구글ToolStripMenuItem.Enabled = false;
            this.구글ToolStripMenuItem.Name = "구글ToolStripMenuItem";
            this.구글ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.구글ToolStripMenuItem.Text = "구글";
            // 
            // 빙ToolStripMenuItem
            // 
            this.빙ToolStripMenuItem.Enabled = false;
            this.빙ToolStripMenuItem.Name = "빙ToolStripMenuItem";
            this.빙ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.빙ToolStripMenuItem.Text = "빙";
            // 
            // 번역Key설정ToolStripMenuItem
            // 
            this.번역Key설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.얀덱스ToolStripMenuItem1});
            this.번역Key설정ToolStripMenuItem.Name = "번역Key설정ToolStripMenuItem";
            this.번역Key설정ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.번역Key설정ToolStripMenuItem.Text = "번역 Key 설정";
            // 
            // 얀덱스ToolStripMenuItem1
            // 
            this.얀덱스ToolStripMenuItem1.Name = "얀덱스ToolStripMenuItem1";
            this.얀덱스ToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.얀덱스ToolStripMenuItem1.Text = "얀덱스";
            this.얀덱스ToolStripMenuItem1.Click += new System.EventHandler(this.얀덱스ToolStripMenuItem1_Click);
            // 
            // 주소타입설정ToolStripMenuItem
            // 
            this.주소타입설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemRAW,
            this.MenuItemRVA,
            this.MenuItemVA});
            this.주소타입설정ToolStripMenuItem.Enabled = false;
            this.주소타입설정ToolStripMenuItem.Name = "주소타입설정ToolStripMenuItem";
            this.주소타입설정ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.주소타입설정ToolStripMenuItem.Text = "주소타입 설정";
            // 
            // MenuItemRAW
            // 
            this.MenuItemRAW.Name = "MenuItemRAW";
            this.MenuItemRAW.Size = new System.Drawing.Size(100, 22);
            this.MenuItemRAW.Tag = "주소타입이 RAW 로 설정되었습니다.";
            this.MenuItemRAW.Text = "RAW";
            // 
            // MenuItemRVA
            // 
            this.MenuItemRVA.Name = "MenuItemRVA";
            this.MenuItemRVA.Size = new System.Drawing.Size(100, 22);
            this.MenuItemRVA.Tag = "주소타입이 RVA 로 설정되었습니다.";
            this.MenuItemRVA.Text = "RVA";
            // 
            // MenuItemVA
            // 
            this.MenuItemVA.Checked = true;
            this.MenuItemVA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemVA.Name = "MenuItemVA";
            this.MenuItemVA.Size = new System.Drawing.Size(100, 22);
            this.MenuItemVA.Tag = "주소타입이 VA 로 설정되었습니다.";
            this.MenuItemVA.Text = "VA";
            // 
            // 정보ToolStripMenuItem
            // 
            this.정보ToolStripMenuItem.Image = global::TranslationTool.Properties.Resources.information_icon_6059;
            this.정보ToolStripMenuItem.Name = "정보ToolStripMenuItem";
            this.정보ToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.정보ToolStripMenuItem.Text = "정보(&O)";
            this.정보ToolStripMenuItem.Click += new System.EventHandler(this.정보ToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(550, 23);
            this.textBox1.TabIndex = 24;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 361);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(577, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 17);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 24);
            this.button2.TabIndex = 30;
            this.button2.Text = "범위자동설정";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Address";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Disassembly";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "String";
            this.columnHeader6.Width = 152;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "String Unicode";
            this.columnHeader8.Width = 152;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8});
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(12, 101);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(551, 257);
            this.listView2.TabIndex = 27;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Visible = false;
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 383);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translation Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.ToolStripMenuItem 기능ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 주소변환ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 주소타입설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRAW;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRVA;
        private System.Windows.Forms.ToolStripMenuItem MenuItemVA;
        private System.Windows.Forms.ToolStripMenuItem bing번역APIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 얀덱스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 구글ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 빙ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 기본언어설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem한국어;
        private System.Windows.Forms.ToolStripMenuItem MenuItem중국어간체;
        private System.Windows.Forms.ToolStripMenuItem MenuItem중국어번체;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem자동감지;
        private System.Windows.Forms.ToolStripMenuItem MenuItem일본어;
        private System.Windows.Forms.ToolStripMenuItem MenuItem유니코드;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        public System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ToolStripMenuItem 번역Key설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 얀덱스ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem영어;
    }
}

