﻿namespace HtsProgram
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.id_textbox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.turnoverRatioLabel = new System.Windows.Forms.Label();
            this.currentPriceLabel = new System.Windows.Forms.Label();
            this.netChangeLabel = new System.Windows.Forms.Label();
            this.fluctuationRateLabel = new System.Windows.Forms.Label();
            this.volumeChangeLabel = new System.Windows.Forms.Label();
            this.accumulatedVolumeLabel = new System.Windows.Forms.Label();
            this.lowPriceLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.highPriceLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.openPriceLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tradingValueLabel = new System.Windows.Forms.Label();
            this.chartYLabel = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tickButton = new System.Windows.Forms.Button();
            this.minuteButton = new System.Windows.Forms.Button();
            this.monthlyButton = new System.Windows.Forms.Button();
            this.weeklyButton = new System.Windows.Forms.Button();
            this.dailyButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.kospiAndKosdaqButton = new System.Windows.Forms.Button();
            this.allItemButton = new System.Windows.Forms.Button();
            this.KospiButton = new System.Windows.Forms.Button();
            this.itemSearchGridView = new System.Windows.Forms.DataGridView();
            this.kosdaqButton = new System.Windows.Forms.Button();
            this.itemGridView = new System.Windows.Forms.DataGridView();
            this.종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameSearchTextBox = new System.Windows.Forms.TextBox();
            this.codeSearchTextBox = new System.Windows.Forms.TextBox();
            this.elwButton = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemSearchGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "로그인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(216, 260);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(10, 20);
            this.axKHOpenAPI1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(12, 557);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1156, 92);
            this.textBox1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(80, 20);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 539);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1152, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "로그인";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "모의투자",
            "실전투자"});
            this.comboBox2.Location = new System.Drawing.Point(88, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Text = "모의투자";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1152, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "계좌 조회";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.Location = new System.Drawing.Point(6, 172);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 25);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "수수료 계산";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(6, 197);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(838, 150);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 20;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "종목명";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "보유량";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "주문가능";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "평균단가";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "현재가";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "매입금액";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "평가금액";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "평가손익";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 80;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "손익율";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 70;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "이익분기점";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 90;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.id_textbox);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.username_textbox);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(855, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "잔고";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.75926F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.24074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label13, 7, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.17391F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.82609F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 47);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "순자산총액";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "순자산총액";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "예수금";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "총평가금액";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "총평가금액";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "예수금";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(517, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "총평가손액";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(718, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 14;
            this.label9.Text = "총평가손액";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(301, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 15;
            this.label10.Text = "총매수금액";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 21);
            this.label11.TabIndex = 16;
            this.label11.Text = "총매수금액";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(525, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 21);
            this.label12.TabIndex = 17;
            this.label12.Text = "총수익률";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(734, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 21);
            this.label13.TabIndex = 18;
            this.label13.Text = "총수익률";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "계좌";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 0;
            this.button2.Text = "조회";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // id_textbox
            // 
            this.id_textbox.BackColor = System.Drawing.Color.White;
            this.id_textbox.Location = new System.Drawing.Point(265, 22);
            this.id_textbox.Name = "id_textbox";
            this.id_textbox.ReadOnly = true;
            this.id_textbox.Size = new System.Drawing.Size(78, 29);
            this.id_textbox.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(54, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 29);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // username_textbox
            // 
            this.username_textbox.BackColor = System.Drawing.Color.White;
            this.username_textbox.Location = new System.Drawing.Point(181, 22);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.ReadOnly = true;
            this.username_textbox.Size = new System.Drawing.Size(78, 29);
            this.username_textbox.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel2);
            this.tabPage3.Controls.Add(this.chartYLabel);
            this.tabPage3.Controls.Add(this.comboBox3);
            this.tabPage3.Controls.Add(this.tickButton);
            this.tabPage3.Controls.Add(this.minuteButton);
            this.tabPage3.Controls.Add(this.monthlyButton);
            this.tabPage3.Controls.Add(this.weeklyButton);
            this.tabPage3.Controls.Add(this.dailyButton);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.tabControl2);
            this.tabPage3.Controls.Add(this.trackBar1);
            this.tabPage3.Controls.Add(this.chart1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1152, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "차트";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 13;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel2.Controls.Add(this.turnoverRatioLabel, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.currentPriceLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.netChangeLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.fluctuationRateLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.volumeChangeLabel, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.accumulatedVolumeLabel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lowPriceLabel, 12, 0);
            this.tableLayoutPanel2.Controls.Add(this.label16, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.highPriceLabel, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.label15, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.openPriceLabel, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.tradingValueLabel, 6, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(273, 56);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(877, 34);
            this.tableLayoutPanel2.TabIndex = 34;
            // 
            // turnoverRatioLabel
            // 
            this.turnoverRatioLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.turnoverRatioLabel.AutoSize = true;
            this.turnoverRatioLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.turnoverRatioLabel.Location = new System.Drawing.Point(366, 7);
            this.turnoverRatioLabel.Name = "turnoverRatioLabel";
            this.turnoverRatioLabel.Size = new System.Drawing.Size(37, 19);
            this.turnoverRatioLabel.TabIndex = 34;
            this.turnoverRatioLabel.Text = "80%";
            // 
            // currentPriceLabel
            // 
            this.currentPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentPriceLabel.AutoSize = true;
            this.currentPriceLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.currentPriceLabel.Location = new System.Drawing.Point(5, 7);
            this.currentPriceLabel.Name = "currentPriceLabel";
            this.currentPriceLabel.Size = new System.Drawing.Size(65, 19);
            this.currentPriceLabel.TabIndex = 24;
            this.currentPriceLabel.Text = "2000000";
            // 
            // netChangeLabel
            // 
            this.netChangeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.netChangeLabel.AutoSize = true;
            this.netChangeLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.netChangeLabel.Location = new System.Drawing.Point(81, 7);
            this.netChangeLabel.Name = "netChangeLabel";
            this.netChangeLabel.Size = new System.Drawing.Size(49, 19);
            this.netChangeLabel.TabIndex = 25;
            this.netChangeLabel.Text = "10000";
            // 
            // fluctuationRateLabel
            // 
            this.fluctuationRateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fluctuationRateLabel.AutoSize = true;
            this.fluctuationRateLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.fluctuationRateLabel.Location = new System.Drawing.Point(149, 7);
            this.fluctuationRateLabel.Name = "fluctuationRateLabel";
            this.fluctuationRateLabel.Size = new System.Drawing.Size(37, 19);
            this.fluctuationRateLabel.TabIndex = 26;
            this.fluctuationRateLabel.Text = "10%";
            // 
            // volumeChangeLabel
            // 
            this.volumeChangeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.volumeChangeLabel.AutoSize = true;
            this.volumeChangeLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.volumeChangeLabel.Location = new System.Drawing.Point(298, 7);
            this.volumeChangeLabel.Name = "volumeChangeLabel";
            this.volumeChangeLabel.Size = new System.Drawing.Size(37, 19);
            this.volumeChangeLabel.TabIndex = 27;
            this.volumeChangeLabel.Text = "80%";
            // 
            // accumulatedVolumeLabel
            // 
            this.accumulatedVolumeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.accumulatedVolumeLabel.AutoSize = true;
            this.accumulatedVolumeLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.accumulatedVolumeLabel.Location = new System.Drawing.Point(203, 7);
            this.accumulatedVolumeLabel.Name = "accumulatedVolumeLabel";
            this.accumulatedVolumeLabel.Size = new System.Drawing.Size(73, 19);
            this.accumulatedVolumeLabel.TabIndex = 31;
            this.accumulatedVolumeLabel.Text = "10000000";
            // 
            // lowPriceLabel
            // 
            this.lowPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lowPriceLabel.AutoSize = true;
            this.lowPriceLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lowPriceLabel.Location = new System.Drawing.Point(796, 7);
            this.lowPriceLabel.Name = "lowPriceLabel";
            this.lowPriceLabel.Size = new System.Drawing.Size(65, 19);
            this.lowPriceLabel.TabIndex = 30;
            this.lowPriceLabel.Text = "1000000";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.LightGray;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label16.Location = new System.Drawing.Point(751, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 21);
            this.label16.TabIndex = 36;
            this.label16.Text = "저";
            // 
            // highPriceLabel
            // 
            this.highPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.highPriceLabel.AutoSize = true;
            this.highPriceLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.highPriceLabel.Location = new System.Drawing.Point(674, 7);
            this.highPriceLabel.Name = "highPriceLabel";
            this.highPriceLabel.Size = new System.Drawing.Size(65, 19);
            this.highPriceLabel.TabIndex = 29;
            this.highPriceLabel.Text = "1000000";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.LightGray;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label15.Location = new System.Drawing.Point(636, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 21);
            this.label15.TabIndex = 38;
            this.label15.Text = "고";
            // 
            // openPriceLabel
            // 
            this.openPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openPriceLabel.AutoSize = true;
            this.openPriceLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.openPriceLabel.Location = new System.Drawing.Point(558, 7);
            this.openPriceLabel.Name = "openPriceLabel";
            this.openPriceLabel.Size = new System.Drawing.Size(65, 19);
            this.openPriceLabel.TabIndex = 28;
            this.openPriceLabel.Text = "1000000";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.LightGray;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label14.Location = new System.Drawing.Point(520, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 21);
            this.label14.TabIndex = 37;
            this.label14.Text = "시";
            // 
            // tradingValueLabel
            // 
            this.tradingValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tradingValueLabel.AutoSize = true;
            this.tradingValueLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.tradingValueLabel.Location = new System.Drawing.Point(445, 7);
            this.tradingValueLabel.Name = "tradingValueLabel";
            this.tradingValueLabel.Size = new System.Drawing.Size(41, 19);
            this.tradingValueLabel.TabIndex = 33;
            this.tradingValueLabel.Text = "1000";
            // 
            // chartYLabel
            // 
            this.chartYLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartYLabel.BackColor = System.Drawing.Color.NavajoWhite;
            this.chartYLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartYLabel.Location = new System.Drawing.Point(1081, 93);
            this.chartYLabel.Name = "chartYLabel";
            this.chartYLabel.Size = new System.Drawing.Size(71, 19);
            this.chartYLabel.TabIndex = 6;
            this.chartYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chartYLabel.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "10",
            "15",
            "20",
            "30",
            "60",
            "120"});
            this.comboBox3.Location = new System.Drawing.Point(467, 20);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(39, 29);
            this.comboBox3.TabIndex = 22;
            this.comboBox3.Text = "1";
            this.comboBox3.TextChanged += new System.EventHandler(this.comboBox3_TextChanged);
            // 
            // tickButton
            // 
            this.tickButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tickButton.Location = new System.Drawing.Point(430, 19);
            this.tickButton.Name = "tickButton";
            this.tickButton.Size = new System.Drawing.Size(30, 30);
            this.tickButton.TabIndex = 21;
            this.tickButton.Text = "틱";
            this.tickButton.UseVisualStyleBackColor = true;
            // 
            // minuteButton
            // 
            this.minuteButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.minuteButton.Location = new System.Drawing.Point(394, 19);
            this.minuteButton.Name = "minuteButton";
            this.minuteButton.Size = new System.Drawing.Size(30, 30);
            this.minuteButton.TabIndex = 20;
            this.minuteButton.Text = "분";
            this.minuteButton.UseVisualStyleBackColor = true;
            // 
            // monthlyButton
            // 
            this.monthlyButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.monthlyButton.Location = new System.Drawing.Point(358, 19);
            this.monthlyButton.Name = "monthlyButton";
            this.monthlyButton.Size = new System.Drawing.Size(30, 30);
            this.monthlyButton.TabIndex = 19;
            this.monthlyButton.Text = "월";
            this.monthlyButton.UseVisualStyleBackColor = true;
            // 
            // weeklyButton
            // 
            this.weeklyButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.weeklyButton.Location = new System.Drawing.Point(322, 19);
            this.weeklyButton.Name = "weeklyButton";
            this.weeklyButton.Size = new System.Drawing.Size(30, 30);
            this.weeklyButton.TabIndex = 18;
            this.weeklyButton.Text = "주";
            this.weeklyButton.UseVisualStyleBackColor = true;
            // 
            // dailyButton
            // 
            this.dailyButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dailyButton.Location = new System.Drawing.Point(286, 20);
            this.dailyButton.Name = "dailyButton";
            this.dailyButton.Size = new System.Drawing.Size(30, 30);
            this.dailyButton.TabIndex = 17;
            this.dailyButton.Text = "일";
            this.dailyButton.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Location = new System.Drawing.Point(1115, 475);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 16;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(1080, 475);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 15;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(267, 499);
            this.tabControl2.TabIndex = 14;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.kospiAndKosdaqButton);
            this.tabPage4.Controls.Add(this.allItemButton);
            this.tabPage4.Controls.Add(this.KospiButton);
            this.tabPage4.Controls.Add(this.itemSearchGridView);
            this.tabPage4.Controls.Add(this.kosdaqButton);
            this.tabPage4.Controls.Add(this.itemGridView);
            this.tabPage4.Controls.Add(this.nameSearchTextBox);
            this.tabPage4.Controls.Add(this.codeSearchTextBox);
            this.tabPage4.Controls.Add(this.elwButton);
            this.tabPage4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(259, 473);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "종목 검색";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // kospiAndKosdaqButton
            // 
            this.kospiAndKosdaqButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.kospiAndKosdaqButton.Location = new System.Drawing.Point(89, 44);
            this.kospiAndKosdaqButton.Name = "kospiAndKosdaqButton";
            this.kospiAndKosdaqButton.Size = new System.Drawing.Size(156, 30);
            this.kospiAndKosdaqButton.TabIndex = 3;
            this.kospiAndKosdaqButton.Text = "거래소 + 코스닥";
            this.kospiAndKosdaqButton.UseVisualStyleBackColor = true;
            // 
            // allItemButton
            // 
            this.allItemButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.allItemButton.Location = new System.Drawing.Point(8, 8);
            this.allItemButton.Name = "allItemButton";
            this.allItemButton.Size = new System.Drawing.Size(75, 29);
            this.allItemButton.TabIndex = 0;
            this.allItemButton.Text = "전종목";
            this.allItemButton.UseVisualStyleBackColor = true;
            // 
            // KospiButton
            // 
            this.KospiButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.KospiButton.Location = new System.Drawing.Point(89, 8);
            this.KospiButton.Name = "KospiButton";
            this.KospiButton.Size = new System.Drawing.Size(75, 30);
            this.KospiButton.TabIndex = 1;
            this.KospiButton.Text = "거래소";
            this.KospiButton.UseVisualStyleBackColor = true;
            // 
            // itemSearchGridView
            // 
            this.itemSearchGridView.AllowUserToDeleteRows = false;
            this.itemSearchGridView.AllowUserToResizeColumns = false;
            this.itemSearchGridView.AllowUserToResizeRows = false;
            this.itemSearchGridView.BackgroundColor = System.Drawing.Color.White;
            this.itemSearchGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemSearchGridView.GridColor = System.Drawing.Color.DarkGray;
            this.itemSearchGridView.Location = new System.Drawing.Point(8, 114);
            this.itemSearchGridView.MultiSelect = false;
            this.itemSearchGridView.Name = "itemSearchGridView";
            this.itemSearchGridView.ReadOnly = true;
            this.itemSearchGridView.RowHeadersVisible = false;
            this.itemSearchGridView.RowTemplate.Height = 23;
            this.itemSearchGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemSearchGridView.Size = new System.Drawing.Size(237, 345);
            this.itemSearchGridView.TabIndex = 10;
            this.itemSearchGridView.Visible = false;
            this.itemSearchGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemSearchGridView_MouseClick);
            // 
            // kosdaqButton
            // 
            this.kosdaqButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.kosdaqButton.Location = new System.Drawing.Point(170, 8);
            this.kosdaqButton.Name = "kosdaqButton";
            this.kosdaqButton.Size = new System.Drawing.Size(75, 30);
            this.kosdaqButton.TabIndex = 2;
            this.kosdaqButton.Text = "코스닥";
            this.kosdaqButton.UseVisualStyleBackColor = true;
            // 
            // itemGridView
            // 
            this.itemGridView.AllowUserToDeleteRows = false;
            this.itemGridView.AllowUserToResizeColumns = false;
            this.itemGridView.AllowUserToResizeRows = false;
            this.itemGridView.BackgroundColor = System.Drawing.Color.White;
            this.itemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.종목명,
            this.코드});
            this.itemGridView.GridColor = System.Drawing.Color.DarkGray;
            this.itemGridView.Location = new System.Drawing.Point(8, 114);
            this.itemGridView.MultiSelect = false;
            this.itemGridView.Name = "itemGridView";
            this.itemGridView.ReadOnly = true;
            this.itemGridView.RowHeadersVisible = false;
            this.itemGridView.RowTemplate.Height = 23;
            this.itemGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemGridView.Size = new System.Drawing.Size(237, 345);
            this.itemGridView.TabIndex = 9;
            this.itemGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemGridView_MouseClick);
            // 
            // 종목명
            // 
            this.종목명.HeaderText = "종목명";
            this.종목명.MinimumWidth = 10;
            this.종목명.Name = "종목명";
            this.종목명.ReadOnly = true;
            this.종목명.Width = 140;
            // 
            // 코드
            // 
            this.코드.HeaderText = "코드";
            this.코드.MinimumWidth = 10;
            this.코드.Name = "코드";
            this.코드.ReadOnly = true;
            this.코드.Width = 75;
            // 
            // nameSearchTextBox
            // 
            this.nameSearchTextBox.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameSearchTextBox.Location = new System.Drawing.Point(8, 79);
            this.nameSearchTextBox.Name = "nameSearchTextBox";
            this.nameSearchTextBox.Size = new System.Drawing.Size(142, 29);
            this.nameSearchTextBox.TabIndex = 5;
            // 
            // codeSearchTextBox
            // 
            this.codeSearchTextBox.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.codeSearchTextBox.Location = new System.Drawing.Point(156, 80);
            this.codeSearchTextBox.Name = "codeSearchTextBox";
            this.codeSearchTextBox.Size = new System.Drawing.Size(89, 29);
            this.codeSearchTextBox.TabIndex = 7;
            // 
            // elwButton
            // 
            this.elwButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.elwButton.Location = new System.Drawing.Point(8, 43);
            this.elwButton.Name = "elwButton";
            this.elwButton.Size = new System.Drawing.Size(75, 30);
            this.elwButton.TabIndex = 6;
            this.elwButton.Text = "ELW";
            this.elwButton.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(259, 473);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "관심 종목";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.trackBar1.BackColor = System.Drawing.Color.White;
            this.trackBar1.Location = new System.Drawing.Point(987, 476);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(97, 45);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AlignWithChartArea = "volumeChartArea";
            chartArea1.AxisX.IsReversed = true;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.ScrollBar.Enabled = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 92.36364F;
            chartArea1.InnerPlotPosition.Width = 90.32448F;
            chartArea1.InnerPlotPosition.X = 1.675532F;
            chartArea1.InnerPlotPosition.Y = 3.818182F;
            chartArea1.Name = "PriceChartArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 55F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 3F;
            chartArea2.AxisX.IsReversed = true;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 80.86906F;
            chartArea2.InnerPlotPosition.Width = 90.32448F;
            chartArea2.InnerPlotPosition.X = 1.675532F;
            chartArea2.InnerPlotPosition.Y = 4.999996F;
            chartArea2.Name = "volumeChartArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 38F;
            chartArea2.Position.Width = 94F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 59F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chart1.Location = new System.Drawing.Point(261, 71);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "PriceChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "priceSeries";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "volumeChartArea";
            series2.Name = "volumeSeries";
            series2.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(891, 434);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chart1_AxisViewChanged);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemSearchGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox id_textbox;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button kospiAndKosdaqButton;
        private System.Windows.Forms.Button kosdaqButton;
        private System.Windows.Forms.Button KospiButton;
        private System.Windows.Forms.Button allItemButton;
        private System.Windows.Forms.TextBox codeSearchTextBox;
        private System.Windows.Forms.Button elwButton;
        private System.Windows.Forms.TextBox nameSearchTextBox;
        private System.Windows.Forms.DataGridView itemSearchGridView;
        private System.Windows.Forms.DataGridView itemGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button tickButton;
        private System.Windows.Forms.Button minuteButton;
        private System.Windows.Forms.Button monthlyButton;
        private System.Windows.Forms.Button weeklyButton;
        private System.Windows.Forms.Button dailyButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label chartYLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label currentPriceLabel;
        private System.Windows.Forms.Label netChangeLabel;
        private System.Windows.Forms.Label fluctuationRateLabel;
        private System.Windows.Forms.Label volumeChangeLabel;
        private System.Windows.Forms.Label accumulatedVolumeLabel;
        private System.Windows.Forms.Label tradingValueLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label openPriceLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label highPriceLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lowPriceLabel;
        private System.Windows.Forms.Label turnoverRatioLabel;
    }
}

