using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HtsProgram
{
    public partial class Form1 : Form
    {
        List<itemEntityObject> itemAllList;
        List<itemEntityObject> kospiList;
        List<itemEntityObject> kosdaqList;
        List<itemEntityObject> elwList;

        // 차트 구현
        Series chartSeries;
        List<PriceInfoEntityObject> priceInfoList;
        private Series priceSeries;
        private Series volumeSeries;

        private int selectedTickUnit = 1;
        private int selectedMinuteUnit = 1;
        private Boolean isMinuteSelected = false;
        private Boolean isTickSelected = false;

        private string ItemClick;

        int[] chrint = { 44032, 44620, 45208, 45796, 46384, 46972, 47560,
            48148, 48736, 49324, 49912, 50500, 51088, 51676, 52264, 52852, 53440, 54028, 54616, 55204 };
        char[] chr = {'ㄱ', 'ㄲ', 'ㄴ', 'ㄷ', 'ㄸ', 'ㄹ', 'ㅁ', 'ㅂ', 'ㅃ', 'ㅅ', 'ㅆ',
            'ㅇ', 'ㅈ', 'ㅉ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ' };
        string[] str = { "가", "까", "나", "다", "따", "라", "마", "바", "빠", "사", "싸",
            "아", "자", "짜", "차", "카", "타", "파", "하" };
        public Form1()
        {


            InitializeComponent();
            this.axKHOpenAPI1.OnEventConnect += this.AxKHOpenAPI_OnEventConnect;
            this.axKHOpenAPI1.OnReceiveTrData += this.AxKHOpenAPI_OnReceiveTrData;
            this.axKHOpenAPI1.OnReceiveRealData += this.AxkhopenAPI_OnReceiveRealData;

            this.nameSearchTextBox.GotFocus += this.TextBox_GotFocus;
            this.nameSearchTextBox.LostFocus += this.TextBox_LostFocus;
            this.codeSearchTextBox.GotFocus += this.TextBox_GotFocus;
            this.codeSearchTextBox.LostFocus += this.TextBox_LostFocus;
            this.nameSearchTextBox.TextChanged += this.Textbox_TextChanged;
            this.codeSearchTextBox.TextChanged += this.Textbox_TextChanged;


            // 주식 검색 리스트
            allItemButton.Click += ButtonClicked;
            KospiButton.Click += ButtonClicked;
            kosdaqButton.Click += ButtonClicked;
            elwButton.Click += ButtonClicked;
            kospiAndKosdaqButton.Click += ButtonClicked;


            // 차트 구현
            dailyButton.Click += ButtonClicked;
            weeklyButton.Click += ButtonClicked;
            monthlyButton.Click += ButtonClicked;
            minuteButton.Click += ButtonClicked;
            tickButton.Click += ButtonClicked;

            priceSeries = chart1.Series["priceSeries"];
            priceSeries["PriceUpColor"] = "Red";
            priceSeries["PriceDownColor"] = "Blue";
            volumeSeries = chart1.Series["volumeSeries"];
            volumeSeries["PriceUpColor"] = "Red";
            volumeSeries["PriceDownColor"] = "Blue";

            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            chart1.ChartAreas[1].AxisY.LabelStyle.Format = "#,##0,K";

            new ToolTip().SetToolTip(currentPriceLabel, "현재가");
            new ToolTip().SetToolTip(netChangeLabel, "전일대비");
            new ToolTip().SetToolTip(fluctuationRateLabel, "등락률");
            new ToolTip().SetToolTip(accumulatedVolumeLabel, "누적거래량");
            new ToolTip().SetToolTip(volumeChangeLabel, "전일거래량 대비");
            new ToolTip().SetToolTip(turnoverRatioLabel, "거래량회전률");
            new ToolTip().SetToolTip(tradingValueLabel, "거래대금");
            new ToolTip().SetToolTip(openPriceLabel, "시가");
            new ToolTip().SetToolTip(highPriceLabel, "고가");
            new ToolTip().SetToolTip(lowPriceLabel, "저가");
        }


        class itemEntityObject
        {
            public string 종목명 { get; set; }
            public String 종목코드 { get; set; }
        }

        class PriceInfoEntityObject
        {
            public string 일자 { get; set; }
            public int 시가 { get; set; }
            public int 고가 { get; set; }
            public int 저가 { get; set; }
            public int 종가 { get; set; }
            public int 거래량 { get; set; }

            // 이평선
            public double pavr_5 { get; set; }
            public double pavr_20 { get; set; }
            public double pavr_60 { get; set; }
            public double pavr_120 { get; set; }

            public double vavr_5 { get; set; }
            public double vavr_20 { get; set; }
            public double vavr_60 { get; set; }
            public double vavr_120 { get; set; }
        }

        private void Textbox_TextChanged(object sender, EventArgs e)
        {
            if (sender.Equals(nameSearchTextBox) && nameSearchTextBox.Focused)
            {
                string x = nameSearchTextBox.Text;
                if (x.Length > 0)
                {
                    itemSearchGridView.Visible = true;
                    try
                    {
                        string pattern = "";
                        for (int i = 0; i < x.Length; i++)
                        {
                            if (x[i] >= 'ㄱ' && x[i] <= 'ㅎ') // 초성만 입력
                            {
                                for (int j = 0; j < chr.Length; i++)
                                {
                                    if (x[i] == chr[j])
                                    {
                                        pattern += string.Format("[{0}-{1}]", str[j], (char)(chrint[j + 1] - 1));
                                    }
                                }
                            }
                            // 완성된 문자를 입력했을때 검색패턴 쓰기
                            else if (x[i] >= '가')
                            {
                                // 받침이 있는지 검사
                                int magic = ((x[i] - '가') % 588);

                                // 받침이 없을 때
                                if (magic == 0)
                                {
                                    pattern += string.Format("[{0}-{1}]", x[i], (char)(x[i] + 27));
                                }

                                // 받침이 있을 때
                                else
                                {
                                    magic = 27 - (magic % 28);
                                    pattern += string.Format("[{0}-{1}]", x[i], (char)(x[i] + magic));
                                }
                            }
                            // 영어를 입력했을 때
                            else if (x[i] >= 'A' && x[i] <= 'z')
                            {
                                pattern += x[i];
                            }
                            // 숫자를 입력했을 때
                            else if (x[i] >= '0' && x[i] <= '9')
                            {
                                pattern += x[i];
                            }
                        }
                        var res = itemAllList.Where(c => Regex.IsMatch(c.종목명, pattern));
                        List<itemEntityObject> list = new List<itemEntityObject>();
                        list.AddRange(res);

                        itemSearchGridView.DataSource = list;
                    }
                    catch (Exception exception)
                    {
                    }
                }
                else
                {
                    itemSearchGridView.Visible = false;
                }
            }
            else if (sender.Equals(codeSearchTextBox) && codeSearchTextBox.Focused)
            {
                string x = codeSearchTextBox.Text;
                if (x.Length > 0)
                {
                    itemSearchGridView.Visible = true;

                    var res = itemAllList.Where(c => c.종목코드.Contains(x));

                    List<itemEntityObject> list = new List<itemEntityObject>();
                    list.AddRange(res);

                    itemSearchGridView.DataSource = list;
                }
                else
                {
                    itemSearchGridView.Visible = false;
                }
            }
        } // 텍스트가 바뀌었을 때 검색

        public void TextBox_GotFocus(object sender, EventArgs e)
        {
            if (sender.Equals(this.nameSearchTextBox))
            {
                nameSearchTextBox.ForeColor = Color.Black;
                nameSearchTextBox.Text = "";
                itemGridView.Sort(itemGridView.Columns[0], ListSortDirection.Ascending);

                codeSearchTextBox.ForeColor = Color.LightGray;
                codeSearchTextBox.Text = "코드검색";
            }
            else if (sender.Equals(this.codeSearchTextBox))
            {
                codeSearchTextBox.ForeColor = Color.Black;
                codeSearchTextBox.Text = "";
                itemGridView.Sort(itemGridView.Columns[1], ListSortDirection.Ascending);

                nameSearchTextBox.ForeColor = Color.LightGray;
                nameSearchTextBox.Text = "종목명, 초성검색";
            }
        } // 텍스트 "종목명, 초성검색" 및 "코드검색"

        public void TextBox_LostFocus(object sender, EventArgs e)
        {
            if (sender.Equals(this.nameSearchTextBox) && codeSearchTextBox.Focused)
            {
                itemSearchGridView.Visible = false;
                nameSearchTextBox.ForeColor = Color.LightGray;
                nameSearchTextBox.Text = "종목명, 초성검색";
            }
            else if (sender.Equals(this.codeSearchTextBox) && nameSearchTextBox.Focused)
            {
                itemGridView.Visible = false;
                codeSearchTextBox.ForeColor = Color.LightGray;
                codeSearchTextBox.Text = "코드검색";
            }
        }

        public void ButtonClicked(object sender, EventArgs e)
        {
            itemSearchGridView.Visible = false;
            if (sender.Equals(this.allItemButton))
            {
                itemGridView.Rows.Clear();
                for (int i = 0; i < itemAllList.Count; i++)
                {
                    itemGridView.Rows.Add();
                    itemGridView["종목명", i].Value = itemAllList[i].종목명;
                    itemGridView["코드", i].Value = itemAllList[i].종목코드;
                }
                itemGridView.Sort(itemGridView.Columns[0], ListSortDirection.Ascending);
            }
            else if (sender.Equals(this.KospiButton) || sender.Equals(this.kosdaqButton) || sender.Equals(this.elwButton))
            {
                itemGridView.Rows.Clear();
                List<itemEntityObject> itemList = null;
                string marketCode = null;

                if (sender.Equals(this.KospiButton))
                {
                    itemList = kospiList;
                    marketCode = "0";
                }
                else if (sender.Equals(this.kosdaqButton))
                {
                    itemList = kosdaqList;
                    marketCode = "10";
                }
                else if (sender.Equals(this.elwButton))
                {
                    itemList = elwList;
                    marketCode = "3";
                }

                if (itemList == null)
                {
                    itemList = new List<itemEntityObject>();
                    string codeList = axKHOpenAPI1.GetCodeListByMarket(marketCode);
                    string[] codeListArray = codeList.Split(';');

                    for (int i = 0; i < codeListArray.Length; i++)
                    {
                        string code = codeListArray[i];
                        if (code.Length > 0)
                        {
                            string name = axKHOpenAPI1.GetMasterCodeName(code);
                            itemList.Add(new itemEntityObject()
                            {
                                종목명 = name,
                                종목코드 = code
                            });

                            itemGridView.Rows.Add();
                            itemGridView["종목명", i].Value = name;
                            itemGridView["코드", i].Value = code;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        itemGridView.Rows.Add();
                        itemGridView["종목명", i].Value = itemList[i].종목명;
                        itemGridView["코드", i].Value = itemList[i].종목코드;
                    }
                }

                itemGridView.Sort(itemGridView.Columns[0], ListSortDirection.Ascending);
            }
            else if (sender.Equals(this.kospiAndKosdaqButton))
            {
                itemGridView.Rows.Clear();
                if (kospiList == null || kosdaqList == null)
                {
                    if (kospiList == null)
                    {
                        kospiList = new List<itemEntityObject>();
                        string codeList = axKHOpenAPI1.GetCodeListByMarket("0");
                        string[] codeListArray = codeList.Split(';');

                        for (int i = 0; i < codeListArray.Length; i++)
                        {
                            string code = codeListArray[i];
                            if (code.Length > 0)
                            {
                                string name = axKHOpenAPI1.GetMasterCodeName(code);
                                kospiList.Add(new itemEntityObject()
                                {
                                    종목명 = name,
                                    종목코드 = code
                                });
                            }
                        }
                    }
                    if (kosdaqList == null)
                    {
                        kosdaqList = new List<itemEntityObject>();
                        string codeList = axKHOpenAPI1.GetCodeListByMarket("10");
                        string[] codeListArray = codeList.Split(';');

                        for (int i = 0; i < codeListArray.Length; i++)
                        {
                            string code = codeListArray[i];
                            if (code.Length > 0)
                            {
                                string name = axKHOpenAPI1.GetMasterCodeName(code);
                                kosdaqList.Add(new itemEntityObject()
                                {
                                    종목명 = name,
                                    종목코드 = code
                                });
                            }
                        }
                    }
                }

                for (int i = 0; i < kospiList.Count; i++)
                {
                    itemGridView.Rows.Add();
                    itemGridView["종목명", i].Value = kospiList[i].종목명;
                    itemGridView["코드", i].Value = kospiList[i].종목코드;
                }
                for (int i = 0; i < kosdaqList.Count; i++)
                {
                    itemGridView.Rows.Add();
                    itemGridView["종목명", i + kospiList.Count].Value = kosdaqList[i].종목명;
                    itemGridView["코드", i + kospiList.Count].Value = kosdaqList[i].종목코드;
                }

                itemGridView.Sort(itemGridView.Columns[0], ListSortDirection.Ascending);
            }





            // 차트!
            if (sender.Equals(dailyButton))
            {
                if (ItemClick != "")
                {
                    comboBox3.Enabled = false;
                    RequestDailyChart();
                }
            }
            else if (sender.Equals(weeklyButton))
            {
                if (ItemClick != "")
                {
                    comboBox3.Enabled = false;
                    requestWeeklyChart();
                }
            }
            else if (sender.Equals(monthlyButton))
            {
                if (ItemClick != "")
                {
                    comboBox3.Enabled = false;
                    requestMonthlyChart();
                }
            }
            else if (sender.Equals(minuteButton))
            {
                if (ItemClick != "")
                {
                    comboBox3.Enabled = true;
                    isMinuteSelected = true;
                    isTickSelected = false;
                    requestMinuteChart(selectedMinuteUnit);
                }
            }
            else if (sender.Equals(tickButton))
            {
                if (ItemClick != "")
                {
                    comboBox3.Enabled = true;

                    isMinuteSelected = false;
                    isTickSelected = true;

                    requestTickChart(selectedTickUnit);
                }
            }

        }

        private void AxKHOpenAPI_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0) // 로그인 성공
            {
                textBox1.Text += "\r\nLogin Success!";
                textBox1.Text += "LOGIN ID : " + axKHOpenAPI1.GetLoginInfo("USER_ID");
                string str = axKHOpenAPI1.GetLoginInfo("ACCNO");
                string[] strArray = str.Split(';');
                textBox1.Text += "\r\n보유한 계좌 : " + axKHOpenAPI1.GetLoginInfo("ACCOUNT_CNT"); // 계좌 정보
                foreach (string forstring in strArray)
                {
                    textBox1.Text += "\r\n      Account : " + forstring;
                    break;
                }
                textBox1.Text += "\r\n사용자명 : " + axKHOpenAPI1.GetLoginInfo("USER_NAME");

                getUserInfo();

                // 전종목 리스트
                itemAllList = new List<itemEntityObject>();
                String codeList = axKHOpenAPI1.GetCodeListByMarket(null);
                string[] codeListArray = codeList.Split(';');

                for (int i = 0; i < codeListArray.Length; i++)
                {
                    string code = codeListArray[i];
                    if (code.Length > 0)
                    {
                        string name = axKHOpenAPI1.GetMasterCodeName(code);
                        itemAllList.Add(new itemEntityObject()
                        {
                            종목명 = name,
                            종목코드 = code
                        });

                        itemGridView.Rows.Add();
                        itemGridView["종목명", i].Value = name;
                        itemGridView["코드", i].Value = code;
                    }
                }

                itemGridView.Sort(itemGridView.Columns[0], ListSortDirection.Ascending);
                // 전종목 리스트
            }
            else // 로그인 실패
            {
                textBox1.Text += "\r\nLogin Error";
            }
        } // 키움증권 연결 완료

        private void AxKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName == "계좌평가현황요청")
            {

                double SumV = 0;
                double sw;
                if (comboBox2.Text == "모의투자")
                {
                    sw = 0.0035;
                }
                else
                {
                    sw = 0.00035;
                }

                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                DataGridViewRowCollection rowCollection = dataGridView1.Rows;
                for (int nldx = 0; nldx < nCnt; nldx++)
                {
                    string Name = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "종목명").ToString();
                    string Sum = String.Format("{0:#,###}", Convert.ToDouble(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "보유수량").Trim()));
                    //string Suma = String.Format("{0:#,###}", Convert.ToDouble(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "D+2추정예수금").Trim()));
                    string AVGSum = String.Format("{0:#,###}", Convert.ToDouble(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "평균단가").Trim()));
                    string Price = String.Format("{0:#,###}", Convert.ToDouble(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "현재가").Trim()));
                    string BuyPrice = String.Format("{0:#,###}", Convert.ToDouble(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "매입금액").Trim()));
                    string EvaluationPrice = String.Format("{0:#,###}", Convert.ToDouble(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "평가금액").Trim()));
                    string ProfitPrice = String.Format("{0:#,###}", Convert.ToDouble(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "손익금액").Trim()));


                    string Ratio = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nldx, "손익율").Trim();
                    double a = Convert.ToDouble(Ratio);
                    string ax = "";

                    double SS = Convert.ToDouble(AVGSum);

                    if (checkBox1.Checked == true)
                    {
                        SS = Convert.ToDouble(AVGSum) + (Convert.ToDouble(AVGSum) * sw) + (Convert.ToDouble(Price) * sw) + (Convert.ToDouble(Price) * 0.003);
                        if (Convert.ToDouble(Ratio) > 0)
                        {
                            a = Convert.ToDouble(Ratio) - sw * 200 - 0.3;
                            ProfitPrice = String.Format("{0:#,###}", (Convert.ToDouble(EvaluationPrice) - Convert.ToDouble(EvaluationPrice) * (sw * 2 + 0.003) - Convert.ToDouble(BuyPrice)));
                        }
                        else
                        {
                            a = Convert.ToDouble(Ratio) - sw * 200 - 0.3;

                            ProfitPrice = String.Format("{0:#,###}", (Convert.ToDouble(EvaluationPrice) - Convert.ToDouble(EvaluationPrice) * (sw * 2 + 0.003) - Convert.ToDouble(BuyPrice)));
                        }
                    }
                    ax = a.ToString("0.##") + "%";
                    string S = String.Format("{0:#,###}", SS);
                    rowCollection.Add(new object[] { false, Name, Sum, "", AVGSum, Price, BuyPrice, EvaluationPrice, ProfitPrice, ax, S });


                    foreach (DataGridViewRow row in dataGridView1.Rows) // 값이 0보다 작으면 파란색 크면 빨간색
                    {
                        // 평가 손익, 손익율
                        if (Convert.ToDouble(row.Cells[8].Value) < 0)
                        {
                            row.Cells[8].Style.ForeColor = Color.Blue;
                            row.Cells[9].Style.ForeColor = Color.Blue;
                        }
                        else
                        {
                            row.Cells[8].Style.ForeColor = Color.Red;
                            row.Cells[9].Style.ForeColor = Color.Red;
                        }

                    }




                    SumV += a;
                }

                label3.Text = String.Format("{0:#,###}", Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산").Trim()));
                label5.Text = String.Format("{0:#,###}", Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "D+2추정예수금").Trim()));

                label11.Text = String.Format("{0:#,###}", Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액").Trim()));
                label9.Text = String.Format("{0:#,###}", (Convert.ToDouble(String.Format("{0:#,###}",
                    Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액")) - Convert.ToDouble(label11.Text)))));
                label7.Text = String.Format("{0:#,###}", Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim()));
                label13.Text = (Convert.ToDouble(label7.Text) * 100 / Convert.ToDouble(label11.Text) - 100).ToString("0.##") + "%";
                if (checkBox1.Checked == true)
                {
                    label9.Text = String.Format("{0:#,###}", (Convert.ToDouble(String.Format("{0:#,###}",
                        Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액")) - Convert.ToDouble(label11.Text) -
                        Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액")) * (sw * 2 + 0.003)))));
                    label7.Text = String.Format("{0:#,###}", Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim()));
                    label13.Text = (Convert.ToDouble(label7.Text) * 100 / Convert.ToDouble(label11.Text) - sw * 200 - 0.3 - 100).ToString("0.##") + "%";
                    if ((Convert.ToDouble(label7.Text) * 100 / Convert.ToDouble(label11.Text) - 100) > 0)
                    {
                    }
                    else
                    {

                    }
                }
                else
                {
                    label7.Text = String.Format("{0:#,###}", Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim()) +
                    Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim()) * (sw * 2 + 0.003));
                }

                if (Convert.ToDouble(label9.Text) > 0)
                {
                    label9.ForeColor = Color.Red;
                }
                else if (Convert.ToDouble(label9.Text) == 0)
                {
                    label9.ForeColor = Color.Black;
                }
                else if (Convert.ToDouble(label9.Text) < 0)
                {
                    label9.ForeColor = Color.Blue;
                }
                double tmp;
                if (checkBox1.Checked == true)
                {
                    tmp = Convert.ToDouble(label7.Text) * 100 / Convert.ToDouble(label11.Text) - sw * 200 - 0.3 - 100;
                }
                else
                {
                    tmp = Convert.ToDouble(label7.Text) * 100 / Convert.ToDouble(label11.Text) - 100;
                }

                if (tmp > 0)
                {
                    label13.ForeColor = Color.Red;
                }
                else if (tmp == 0)
                {
                    label13.ForeColor = Color.Black;
                }
                else if (tmp < 0)
                {
                    label13.ForeColor = Color.Blue;
                }

            }

            if (e.sRQName == "JM_주식일봉차트조회" || e.sRQName == "JM_주식주봉차트조회" || e.sRQName == "JM_주식월봉차트조회" || e.sRQName == "JM_주식분봉차트조회" || e.sRQName == "JM_주식틱봉차트조회")
            {
                try
                {
                    int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);

                    priceInfoList = new List<PriceInfoEntityObject>();
                    priceSeries.Points.Clear();
                    volumeSeries.Points.Clear();

                    if (e.sRQName == "JM_주식분봉차트조회" || e.sRQName == "JM_주식틱봉차트조회")
                    {
                        chart1.Series["priceSeries"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        chart1.ChartAreas[1].AxisY.LabelStyle.Format = "#,##0";
                    }
                    else
                    {
                        chart1.Series["priceSeries"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
                        chart1.ChartAreas[1].AxisY.LabelStyle.Format = "#,##0,K";
                    }
                    ChartArea priceChartArea = chart1.ChartAreas["PriceChartArea"];
                    do
                    {
                        priceChartArea.AxisX.ScaleView.ZoomReset();
                    }
                    while (priceChartArea.AxisX.ScaleView.IsZoomed);

                    int maxValue = 0;
                    int minValue = int.MaxValue;

                    for (int nIdx = 0; nIdx < nCnt; nIdx++)
                    {
                        if (e.sRQName == "JM_주식분봉차트조회" || e.sRQName == "JM_주식틱봉차트조회")
                            priceInfoList.Add(new PriceInfoEntityObject()
                            {
                                일자 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "체결시간").Trim(),
                                시가 = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "시가").Trim())),
                                고가 = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "고가").Trim())),
                                저가 = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "저가").Trim())),
                                종가 = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "현재가").Trim())),
                                거래량 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "거래량").Trim()),
                            });
                        else
                            priceInfoList.Add(new PriceInfoEntityObject()
                            {
                                일자 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "일자").Trim(),
                                시가 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "시가").Trim()),
                                고가 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "고가").Trim()),
                                저가 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "저가").Trim()),
                                종가 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "현재가").Trim()),
                                거래량 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "거래량").Trim()),
                            });
                        if (priceInfoList[nIdx].고가 > maxValue)
                            maxValue = priceInfoList[nIdx].고가;
                        if (priceInfoList[nIdx].저가 < minValue)
                            minValue = priceInfoList[nIdx].저가;

                        // adding date and high
                        priceSeries.Points.AddXY(priceInfoList[nIdx].일자, priceInfoList[nIdx].고가);
                        // adding low
                        priceSeries.Points[nIdx].YValues[1] = priceInfoList[nIdx].저가;
                        //adding open
                        priceSeries.Points[nIdx].YValues[2] = priceInfoList[nIdx].시가;
                        // adding close
                        priceSeries.Points[nIdx].YValues[3] = priceInfoList[nIdx].종가;

                        priceSeries.Points[nIdx].ToolTip = "일자 : " + priceInfoList[nIdx].일자 + "\n"
                                                          + "시가 : " + String.Format("{0:#,###}", priceInfoList[nIdx].시가) + "\n"
                                                          + "고가 : " + String.Format("{0:#,###}", priceInfoList[nIdx].고가) + "\n"
                                                          + "저가 : " + String.Format("{0:#,###}", priceInfoList[nIdx].저가) + "\n"
                                                          + "종가 : " + String.Format("{0:#,###}", priceInfoList[nIdx].종가) + "\n"
                                                          + "거래량 : " + String.Format("{0:#,###}", priceInfoList[nIdx].거래량);

                        volumeSeries.Points.AddXY(priceInfoList[nIdx].일자, priceInfoList[nIdx].거래량);

                        volumeSeries.Points[nIdx].ToolTip = "일자 : " + priceInfoList[nIdx].일자 + "\n"
                                                           + "거래량 : " + String.Format("{0:#,###}", priceInfoList[nIdx].거래량);

                    }

                    requestStockInfo(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim());

                    if (nCnt > 0)
                    {
                        priceChartArea.AxisX.ScaleView.ZoomReset();

                        priceChartArea.AxisY.Maximum = maxValue;
                        priceChartArea.AxisY.Minimum = minValue;

                        if (!priceChartArea.AxisX.ScaleView.IsZoomed)
                            chart1_AxisViewChanged(chart1, new ViewEventArgs(priceChartArea.AxisX, 0));
                    }


                    update_price5이평선_create();
                    update_price20이평선_create();
                    update_price60이평선_create();
                    update_price120이평선_create();

                    update_volume5이평선_create();
                    update_volume20이평선_create();
                    update_volume60이평선_create();
                    update_volume120이평선_create();

                    
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message.ToString());
                }

            }
            else if (e.sRQName == "JM_주식기본정보요청")
            {
                try
                {
                    int 현재가 = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가"));
                    int 전일대비 = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "전일대비"));
                    double 등락율 = double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim());
                    double 거래량 = double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량"));
                    double 거래대비 = double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래대비"));
                    int 시가 = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "시가"));
                    int 고가 = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "고가"));
                    int 저가 = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "저가"));

                    SetStockInfo(현재가, 전일대비, 등락율, 거래량, 거래대비, 0, 0, 시가, 고가, 저가);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message.ToString());
                }
            }

        }

        private void AxkhopenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (e.sRealType == "주식체결")
            {
                string 종목코드 = e.sRealKey;
                //Console.WriteLine(종목코드);
                if (ItemClick.Equals(종목코드))
                {
                    int 현재가 = int.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 10));
                    int 전일대비 = int.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 11));
                    double 등락율 = double.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 12));
                    double 거래량 = double.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 13));
                    double 거래대비 = double.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 30));
                    double 거래회전율 = double.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 31));
                    double 거래대금 = double.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 14));
                    int 시가 = int.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 16));
                    int 고가 = int.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 17));
                    int 저가 = int.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 18));

                    SetStockInfo(현재가, 전일대비, 등락율, 거래량, 거래대비, 거래회전율, 거래대금, 시가, 고가, 저가);
                }
            }

        }

        private void SetStockInfo(int 현재가, int 전일대비, double 등락율, double 거래량, double 거래대비, double 거래회전율, double 거래대금, int 시가, int 고가, int 저가)
        {
            if (전일대비 > 0)
            {
                currentPriceLabel.ForeColor = Color.Red;
                netChangeLabel.ForeColor = Color.Red;
                fluctuationRateLabel.ForeColor = Color.Red;
            }
            else if (전일대비 < 0)
            {
                currentPriceLabel.ForeColor = Color.Blue;
                netChangeLabel.ForeColor = Color.Blue;
                fluctuationRateLabel.ForeColor = Color.Blue;

                현재가 *= -1;
            }

            if (거래대비 > 0)
                volumeChangeLabel.ForeColor = Color.Red;
            else if (거래대비 < 0)
            {
                volumeChangeLabel.ForeColor = Color.Blue;
                거래대비 *= -1;
            }

            if (시가 > 0)
                openPriceLabel.ForeColor = Color.Red;
            else if (시가 < 0)
            {
                openPriceLabel.ForeColor = Color.Blue;
                시가 *= -1;
            }
            if (고가 > 0)
                highPriceLabel.ForeColor = Color.Red;
            else if (고가 < 0)
            {
                highPriceLabel.ForeColor = Color.Blue;
                고가 *= -1;
            }
            if (저가 > 0)
                lowPriceLabel.ForeColor = Color.Red;
            else if (저가 < 0)
            {
                lowPriceLabel.ForeColor = Color.Blue;
                저가 *= -1;
            }

            currentPriceLabel.Text = String.Format("{0:#,###}", 현재가);
            netChangeLabel.Text = String.Format("{0:#,###}", 전일대비);
            fluctuationRateLabel.Text = 등락율 + "%";
            accumulatedVolumeLabel.Text = String.Format("{0:#,###}", 거래량);
            volumeChangeLabel.Text = 거래대비 + "%";
            turnoverRatioLabel.Text = 거래회전율 + "%";
            tradingValueLabel.Text = String.Format("{0:#,###}", 거래대금) + "백만";
            openPriceLabel.Text = String.Format("{0:#,###}", 시가);
            highPriceLabel.Text = String.Format("{0:#,###}", 고가);
            lowPriceLabel.Text = String.Format("{0:#,###}", 저가);
        }

        private void requestStockInfo(string 종목코드)
        {
            axKHOpenAPI1.SetInputValue("종목코드", this.ItemClick);

            int nRet = axKHOpenAPI1.CommRqData("JM_주식기본정보요청", "OPT10001", 0, "5001");

            if (nRet == 0)
            {
                Console.WriteLine("주식기본정보요청 성공");
            }
            else
            {
                Console.WriteLine("주식기본정보요청 실패");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ComboBox comboBox = (ComboBox)comboBox1;
            string selectedAccount = (string)comboBox.SelectedItem;
            axKHOpenAPI1.SetInputValue("계좌번호", selectedAccount.Trim());
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");

            int nRet = axKHOpenAPI1.CommRqData("계좌평가현황요청", "OPW00004", 0, "6001");


        } // 계좌 조회

        private void getUserInfo()
        {
            username_textbox.Text = axKHOpenAPI1.GetLoginInfo("USER_NAME");
            id_textbox.Text = axKHOpenAPI1.GetLoginInfo("USER_ID");
            string[] acountArray = axKHOpenAPI1.GetLoginInfo("ACCNO").Split(';');
            this.comboBox1.Items.AddRange(acountArray);
            comboBox1.Text = acountArray[0];
        } // 로그인 정보


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            string selectedAccount = (string)comboBox.SelectedItem;
            axKHOpenAPI1.SetInputValue("계좌번호", selectedAccount.Trim());
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ComboBox comboBox = (ComboBox)comboBox1;
            string selectedAccount = (string)comboBox.SelectedItem;
            axKHOpenAPI1.SetInputValue("계좌번호", selectedAccount.Trim());
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");

            int nRet = axKHOpenAPI1.CommRqData("계좌평가현황요청", "OPW00004", 0, "6001");
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private void button1_Click(object sender, EventArgs e) // 로그인
        {
            if (axKHOpenAPI1.CommConnect() == 0)
            {
                textBox1.Text += "\r\n로그인 시작";
            }
        }


        private void itemSearchGridView_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow dr = itemSearchGridView.SelectedRows[0];
            ItemClick = dr.Cells[1].Value.ToString();

            priceInfoList = new List<PriceInfoEntityObject>();

            RequestDailyChart();
        } // 주식 리스트 클릭

        private void itemGridView_MouseClick(object sender, MouseEventArgs e)
        {

            DataGridViewRow dr = itemGridView.SelectedRows[0];
            ItemClick = dr.Cells[1].Value.ToString();

            priceInfoList = new List<PriceInfoEntityObject>();

            RequestDailyChart();

            // 차트 초기화

        } // 주식 리스트 클릭


        private void RequestDailyChart() // 주식일봉차트조회
        {
            //chart1.Series["Series1"].Points.Clear();
            axKHOpenAPI1.SetInputValue("종목코드", ItemClick);
            axKHOpenAPI1.SetInputValue("기준일자", DateTime.Now.ToString("yyyyMMdd"));
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("JM_주식일봉차트조회", "OPT10081", 0, "5002");

            if (nRet == 0)
            {
                Console.WriteLine("주식 일봉 정보요청 성공");
            }
            else
            {
                Console.WriteLine("주식 일봉 정보요청 실패");
            }
        }

        private void requestWeeklyChart() // JM_주식주봉차트조회
        {
            //chart1.Series["Series1"].Points.Clear();
            axKHOpenAPI1.SetInputValue("종목코드", ItemClick);
            axKHOpenAPI1.SetInputValue("기준일자", DateTime.Now.ToString("yyyyMMdd"));
            axKHOpenAPI1.SetInputValue("끝일자", "");
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("JM_주식주봉차트조회", "OPT10082", 0, "5002");

            if (nRet == 0)
            {
                Console.WriteLine("주식 일봉 정보요청 성공");
            }
            else
            {
                Console.WriteLine("주식 일봉 정보요청 실패");
            }
        }

        private void requestMonthlyChart() // JM_주식월봉차트조회
        {
            //chart1.Series["Series1"].Points.Clear();
            axKHOpenAPI1.SetInputValue("종목코드", ItemClick);
            axKHOpenAPI1.SetInputValue("기준일자", DateTime.Now.ToString("yyyyMMdd"));
            axKHOpenAPI1.SetInputValue("끝일자", "");
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("JM_주식월봉차트조회", "OPT10083", 0, "5002");

            if (nRet == 0)
            {
                Console.WriteLine("주식 일봉 정보요청 성공");
            }
            else
            {
                Console.WriteLine("주식 일봉 정보요청 실패");
            }
        }

        private void requestMinuteChart(int minuteUnit) // JM_주식분봉차트조회
        {
            //chart1.Series["Series1"].Points.Clear();
            axKHOpenAPI1.SetInputValue("종목코드", ItemClick);
            axKHOpenAPI1.SetInputValue("틱범위", minuteUnit + "");
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("JM_주식분봉차트조회", "OPT10080", 0, "5002");

            if (nRet == 0)
            {
                Console.WriteLine("주식 일봉 정보요청 성공");
            }
            else
            {
                Console.WriteLine("주식 일봉 정보요청 실패");
            }
        }

        private void requestTickChart(int tickUnit) // JM_주식틱봉차트조회
        {
            //chart1.Series["Series1"].Points.Clear();
            axKHOpenAPI1.SetInputValue("종목코드", ItemClick);
            axKHOpenAPI1.SetInputValue("틱범위", tickUnit.ToString());
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("JM_주식틱봉차트조회", "OPT10079", 0, "5002");

            if (nRet == 0)
            {
                Console.WriteLine("주식 일봉 정보요청 성공");
            }
            else
            {
                Console.WriteLine("주식 일봉 정보요청 실패");
            }
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //chart1.ChartAreas[0].AxisX.Maximum = trackBar1.Value;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value < 295)
            {
                trackBar1.Value += 5;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value > 5)
            {
                trackBar1.Value -= 5;
            }

        }


        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "1")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 1;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 1;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "2")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 2;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 2;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "3")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 3;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 3;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "5")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 5;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 5;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "10")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 10;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 10;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "15")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 15;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 15;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "20")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 20;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 20;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "30")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 30;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 30;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "60")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 60;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 60;
                    requestTickChart(selectedTickUnit);
                }
            }
            else if (comboBox3.Text == "120")
            {
                if (isMinuteSelected)
                {
                    selectedMinuteUnit = 120;
                    requestMinuteChart(selectedMinuteUnit);
                }
                else if (isTickSelected)
                {
                    selectedTickUnit = 120;
                    requestTickChart(selectedTickUnit);
                }
            }
        } // 분봉, 틱봉 단위



        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            ChartArea priceChartArea = chart1.ChartAreas[0];
            ChartArea volumeChartArea = chart1.ChartAreas[1];
            Point mousePoint = new Point(e.X, e.Y);


            if (chart1.Height * 0.05 < e.Y && e.Y < chart1.Height * 0.57)
            {
                chartYLabel.Visible = true;
                priceChartArea.CursorX.SetCursorPixelPosition(mousePoint, true);
                priceChartArea.CursorY.SetCursorPixelPosition(mousePoint, true);


                chartYLabel.Text = String.Format("{0:#,###}", priceChartArea.CursorY.Position);
                chartYLabel.Location = new Point((int)(chart1.Width * 1.2), e.Y - chartYLabel.Height + 80);
            }
            else if (chart1.Height * 0.605 < e.Y && e.Y < chart1.Height * 0.915)
            {
                chartYLabel.Visible = true;
                volumeChartArea.CursorX.SetCursorPixelPosition(mousePoint, true);
                volumeChartArea.CursorY.SetCursorPixelPosition(mousePoint, true);

                chartYLabel.Text = String.Format("{0:#,###}", volumeChartArea.CursorY.Position);
                chartYLabel.Location = new Point((int)(chart1.Width * 1.2), e.Y - chartYLabel.Height + 80);
            }
            else
            {
                chartYLabel.Visible = false;
            }
        }

        private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            if (sender.Equals(chart1))
            {
                try
                {
                    int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
                    int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

                    int max = 0;
                    int min = int.MaxValue;

                    int volumeMax = 0;
                    int volumeMin = int.MaxValue;

                    for (int i = startPosition - 1; i < endPosition; i++)
                    {
                        if (i >= priceInfoList.Count)
                            break;
                        if (i < 0)
                            i = 0;

                        if (priceInfoList[i].고가 > max)
                            max = priceInfoList[i].고가;
                        if (priceInfoList[i].저가 < min)
                            min = priceInfoList[i].저가;

                        if (priceInfoList[i].거래량 > volumeMax)
                            volumeMax = priceInfoList[i].거래량;
                        if (priceInfoList[i].거래량 < volumeMin)
                            volumeMin = priceInfoList[i].거래량;
                    }

                    double offset = 0.2 * (max - min);
                    this.chart1.ChartAreas[0].AxisY.Maximum = max + offset;
                    this.chart1.ChartAreas[0].AxisY.Minimum = min - offset;

                    double volumeOffset = 0.2 * (volumeMax - volumeMin);
                    this.chart1.ChartAreas[1].AxisY.Maximum = volumeMax + volumeOffset;
                    if (volumeMin - volumeOffset > 0)
                        this.chart1.ChartAreas[1].AxisY.Minimum = volumeMin - volumeOffset;
                    else
                        this.chart1.ChartAreas[1].AxisY.Minimum = 0;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message.ToString());
                }
            }
        }





        void update_price5이평선_add()
        {
            //  5이평선이 그려저 있다면 그 정보를 가져온다.
            Series avr_5 = chart1.Series.FindByName("avr_5");

            if (avr_5 == null)
            {
                return;
            }

            double avr_sum;
            avr_sum = 0.0;

            // i~5개의 데이터 합을 구한다.
            for (int i = 0; i < 5; i++)
            {
                avr_sum += priceInfoList[i].종가;
            }
            priceInfoList[0].pavr_5 = avr_sum / 5;

            avr_5.Points.AddXY(chart1.Series["priceSeries"].Points[0].XValue, priceInfoList[0].pavr_5);
        }

        void update_price5이평선_update()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_5 = chart1.Series.FindByName("avr_5");

                if (avr_5 == null)
                    return;

                double avr_sum = 0.0;
                for (int i = 0; i < 5; i++)
                {
                    avr_sum += priceInfoList[i].종가;
                }

                priceInfoList[0].pavr_5 = avr_sum / 5;
                avr_5.Points[0].SetValueY(priceInfoList[0].pavr_5);
            }
        }

        void update_price5이평선_create()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_5 = chart1.Series.FindByName("avr_5");

                if (avr_5 == null)
                {
                    avr_5 = chart1.Series.Add("avr_5");
                }

                avr_5.ChartType = SeriesChartType.Line;
                avr_5.Color = Color.Green;
                avr_5.Points.Clear();

                for (int i = 0; i < priceInfoList.Count - 5; i++)
                {
                    double avr_sum = 0.0;

                    for (int j = 0; j < 5; j++)
                    {
                        avr_sum += priceInfoList[i + j].종가;
                    }

                    priceInfoList[i].pavr_5 = avr_sum / 5;
                    avr_5.Points.AddXY(chart1.Series["priceSeries"].Points[i].XValue, priceInfoList[i].pavr_5);
                }
            }
        }


        void update_price20이평선_add()
        {
            //  20이평선이 그려저 있다면 그 정보를 가져온다.
            Series avr_20 = chart1.Series.FindByName("avr_20");
            
            if(avr_20 == null)
            {
                return;
            }

            double avr_sum;
            avr_sum = 0.0;

            // i~20개의 데이터 합을 구한다.
            for(int i = 0; i < 20; i++)
            {
                avr_sum += priceInfoList[i].종가;
            }
            priceInfoList[0].pavr_20 = avr_sum / 20;

            avr_20.Points.AddXY(chart1.Series["priceSeries"].Points[0].XValue, priceInfoList[0].pavr_20);
        }

        void update_price20이평선_update()
        {
            if(priceInfoList.Count > 0)
            {
                Series avr_20 = chart1.Series.FindByName("avr_20");

                if (avr_20 == null)
                    return;

                double avr_sum = 0.0;
                for(int i = 0; i < 20; i++)
                {
                    avr_sum += priceInfoList[i].종가;
                }

                priceInfoList[0].pavr_20 = avr_sum / 20;
                avr_20.Points[0].SetValueY(priceInfoList[0].pavr_20);
            }
        }

        void update_price20이평선_create()
        {
            if(priceInfoList.Count > 0)
            {
                Series avr_20 = chart1.Series.FindByName("avr_20");

                if(avr_20 == null)
                {
                    avr_20 = chart1.Series.Add("avr_20");
                }

                avr_20.ChartType = SeriesChartType.Line;
                avr_20.Color = Color.Blue;
                avr_20.Points.Clear();

                for(int i = 0; i < priceInfoList.Count - 20; i++)
                {
                    double avr_sum = 0.0;
                    
                    for(int j = 0; j < 20; j++)
                    {
                        avr_sum += priceInfoList[i + j].종가;
                    }

                    priceInfoList[i].pavr_20 = avr_sum / 20;
                    avr_20.Points.AddXY(chart1.Series["priceSeries"].Points[i].XValue, priceInfoList[i].pavr_20);
                }
            }
        }


        void update_price60이평선_add()
        {
            //  60이평선이 그려저 있다면 그 정보를 가져온다.
            Series avr_60 = chart1.Series.FindByName("avr_60");

            if (avr_60 == null)
            {
                return;
            }

            double avr_sum;
            avr_sum = 0.0;

            // i~60개의 데이터 합을 구한다.
            for (int i = 0; i < 60; i++)
            {
                avr_sum += priceInfoList[i].종가;
            }
            priceInfoList[0].pavr_60 = avr_sum / 60;

            avr_60.Points.AddXY(chart1.Series["priceSeries"].Points[0].XValue, priceInfoList[0].pavr_60);
        }

        void update_price60이평선_update()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_60 = chart1.Series.FindByName("avr_60");

                if (avr_60 == null)
                    return;

                double avr_sum = 0.0;
                for (int i = 0; i < 60; i++)
                {
                    avr_sum += priceInfoList[i].종가;
                }

                priceInfoList[0].pavr_60 = avr_sum / 60;
                avr_60.Points[0].SetValueY(priceInfoList[0].pavr_60);
            }
        }

        void update_price60이평선_create()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_60 = chart1.Series.FindByName("avr_60");

                if (avr_60 == null)
                {
                    avr_60 = chart1.Series.Add("avr_60");
                }

                avr_60.ChartType = SeriesChartType.Line;
                avr_60.Color = Color.Purple;
                avr_60.Points.Clear();

                for (int i = 0; i < priceInfoList.Count - 60; i++)
                {
                    double avr_sum = 0.0;

                    for (int j = 0; j < 60; j++)
                    {
                        avr_sum += priceInfoList[i + j].종가;
                    }

                    priceInfoList[i].pavr_60 = avr_sum / 60;
                    avr_60.Points.AddXY(chart1.Series["priceSeries"].Points[i].XValue, priceInfoList[i].pavr_60);
                }
            }
        }


        void update_price120이평선_add()
        {
            //  20이평선이 그려저 있다면 그 정보를 가져온다.
            Series avr_120 = chart1.Series.FindByName("avr_120");

            if (avr_120 == null)
            {
                return;
            }

            double avr_sum;
            avr_sum = 0.0;

            // i~120개의 데이터 합을 구한다.
            for (int i = 0; i < 120; i++)
            {
                avr_sum += priceInfoList[i].종가;
            }
            priceInfoList[0].pavr_120 = avr_sum / 120;

            avr_120.Points.AddXY(chart1.Series["priceSeries"].Points[0].XValue, priceInfoList[0].pavr_120);
        }

        void update_price120이평선_update()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_120 = chart1.Series.FindByName("avr_120");

                if (avr_120 == null)
                    return;

                double avr_sum = 0.0;
                for (int i = 0; i < 120; i++)
                {
                    avr_sum += priceInfoList[i].종가;
                }

                priceInfoList[0].pavr_120 = avr_sum / 120;
                avr_120.Points[0].SetValueY(priceInfoList[0].pavr_120);
            }
        }

        void update_price120이평선_create()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_120 = chart1.Series.FindByName("avr_120");

                if (avr_120 == null)
                {
                    avr_120 = chart1.Series.Add("avr_120");
                }

                avr_120.ChartType = SeriesChartType.Line;
                avr_120.Color = Color.Brown;
                avr_120.Points.Clear();

                for (int i = 0; i < priceInfoList.Count - 120; i++)
                {
                    double avr_sum = 0.0;

                    for (int j = 0; j < 120; j++)
                    {
                        avr_sum += priceInfoList[i + j].종가;
                    }

                    priceInfoList[i].pavr_120 = avr_sum / 120;
                    avr_120.Points.AddXY(chart1.Series["priceSeries"].Points[i].XValue, priceInfoList[i].pavr_120);
                }
            }
        }





        void update_volume5이평선_add()
        {
            //  5이평선이 그려저 있다면 그 정보를 가져온다.
            Series avr_5 = chart1.Series.FindByName("vavr_5");

            if (avr_5 == null)
            {
                return;
            }

            double avr_sum;
            avr_sum = 0.0;

            // i~5개의 데이터 합을 구한다.
            for (int i = 0; i < 5; i++)
            {
                avr_sum += priceInfoList[i].거래량;
            }
            priceInfoList[0].vavr_5 = avr_sum / 5;

            avr_5.Points.AddXY(chart1.Series["volumeSeries"].Points[0].XValue, priceInfoList[0].vavr_5);
        }

        void update_volume5이평선_update()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_5 = chart1.Series.FindByName("vavr_5");

                if (avr_5 == null)
                    return;

                double avr_sum = 0.0;
                for (int i = 0; i < 5; i++)
                {
                    avr_sum += priceInfoList[i].거래량;
                }

                priceInfoList[0].vavr_5 = avr_sum / 5;
                avr_5.Points[0].SetValueY(priceInfoList[0].vavr_5);
            }
        }

        void update_volume5이평선_create()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_5 = chart1.Series.FindByName("vavr_5");

                if (avr_5 == null)
                {
                    avr_5 = chart1.Series.Add("vavr_5");
                }

                avr_5.ChartType = SeriesChartType.Line;
                avr_5.Color = Color.Green;
                avr_5.Points.Clear();

                for (int i = 0; i < priceInfoList.Count - 5; i++)
                {
                    double avr_sum = 0.0;

                    for (int j = 0; j < 5; j++)
                    {
                        avr_sum += priceInfoList[i + j].거래량;
                    }

                    priceInfoList[i].vavr_5 = avr_sum / 5;
                    avr_5.Points.AddXY(chart1.Series["volumeSeries"].Points[i].XValue, priceInfoList[i].vavr_5);
                }
            }
        }


        void update_volume20이평선_add()
        {
            //  20이평선이 그려저 있다면 그 정보를 가져온다.
            Series avr_20 = chart1.Series.FindByName("vavr_20");

            if (avr_20 == null)
            {
                return;
            }

            double avr_sum;
            avr_sum = 0.0;

            // i~20개의 데이터 합을 구한다.
            for (int i = 0; i < 20; i++)
            {
                avr_sum += priceInfoList[i].종가;
            }
            priceInfoList[0].vavr_20 = avr_sum / 20;

            avr_20.Points.AddXY(chart1.Series["volumeSeries"].Points[0].XValue, priceInfoList[0].vavr_20);
        }

        void update_volume20이평선_update()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_20 = chart1.Series.FindByName("vavr_20");

                if (avr_20 == null)
                    return;

                double avr_sum = 0.0;
                for (int i = 0; i < 20; i++)
                {
                    avr_sum += priceInfoList[i].거래량;
                }

                priceInfoList[0].vavr_20 = avr_sum / 20;
                avr_20.Points[0].SetValueY(priceInfoList[0].vavr_20);
            }
        }

        void update_volume20이평선_create()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_20 = chart1.Series.FindByName("vavr_20");

                if (avr_20 == null)
                {
                    avr_20 = chart1.Series.Add("vavr_20");
                }

                avr_20.ChartType = SeriesChartType.Line;
                avr_20.Color = Color.Blue;
                avr_20.Points.Clear();

                for (int i = 0; i < priceInfoList.Count - 20; i++)
                {
                    double avr_sum = 0.0;

                    for (int j = 0; j < 20; j++)
                    {
                        avr_sum += priceInfoList[i + j].거래량;
                    }

                    priceInfoList[i].vavr_20 = avr_sum / 20;
                    avr_20.Points.AddXY(chart1.Series["volumeSeries"].Points[i].XValue, priceInfoList[i].vavr_20);
                }
            }
        }


        void update_volume60이평선_add()
        {
            //  60이평선이 그려저 있다면 그 정보를 가져온다.
            Series avr_60 = chart1.Series.FindByName("vavr_60");

            if (avr_60 == null)
            {
                return;
            }

            double avr_sum;
            avr_sum = 0.0;

            // i~60개의 데이터 합을 구한다.
            for (int i = 0; i < 60; i++)
            {
                avr_sum += priceInfoList[i].종가;
            }
            priceInfoList[0].vavr_60 = avr_sum / 60;

            avr_60.Points.AddXY(chart1.Series["volumeSeries"].Points[0].XValue, priceInfoList[0].vavr_60);
        }

        void update_volume60이평선_update()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_60 = chart1.Series.FindByName("vavr_60");

                if (avr_60 == null)
                    return;

                double avr_sum = 0.0;
                for (int i = 0; i < 60; i++)
                {
                    avr_sum += priceInfoList[i].거래량;
                }

                priceInfoList[0].vavr_60 = avr_sum / 60;
                avr_60.Points[0].SetValueY(priceInfoList[0].vavr_60);
            }
        }

        void update_volume60이평선_create()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_60 = chart1.Series.FindByName("vavr_60");

                if (avr_60 == null)
                {
                    avr_60 = chart1.Series.Add("vavr_60");
                }

                avr_60.ChartType = SeriesChartType.Line;
                avr_60.Color = Color.Purple;
                avr_60.Points.Clear();

                for (int i = 0; i < priceInfoList.Count - 60; i++)
                {
                    double avr_sum = 0.0;

                    for (int j = 0; j < 60; j++)
                    {
                        avr_sum += priceInfoList[i + j].거래량;
                    }

                    priceInfoList[i].vavr_60 = avr_sum / 60;
                    avr_60.Points.AddXY(chart1.Series["volumeSeries"].Points[i].XValue, priceInfoList[i].vavr_60);
                }
            }
        }


        void update_volume120이평선_add()
        {
            //  20이평선이 그려저 있다면 그 정보를 가져온다.
            Series avr_120 = chart1.Series.FindByName("vavr_120");

            if (avr_120 == null)
            {
                return;
            }

            double avr_sum;
            avr_sum = 0.0;

            // i~120개의 데이터 합을 구한다.
            for (int i = 0; i < 120; i++)
            {
                avr_sum += priceInfoList[i].거래량;
            }
            priceInfoList[0].vavr_120 = avr_sum / 120;

            avr_120.Points.AddXY(chart1.Series["volumeSeries"].Points[0].XValue, priceInfoList[0].vavr_120);
        }

        void update_volume120이평선_update()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_120 = chart1.Series.FindByName("vavr_120");

                if (avr_120 == null)
                    return;

                double avr_sum = 0.0;
                for (int i = 0; i < 120; i++)
                {
                    avr_sum += priceInfoList[i].종가;
                }

                priceInfoList[0].vavr_120 = avr_sum / 120;
                avr_120.Points[0].SetValueY(priceInfoList[0].vavr_120);
            }
        }

        void update_volume120이평선_create()
        {
            if (priceInfoList.Count > 0)
            {
                Series avr_120 = chart1.Series.FindByName("vavr_120");

                if (avr_120 == null)
                {
                    avr_120 = chart1.Series.Add("vavr_120");
                }

                avr_120.ChartType = SeriesChartType.Line;
                avr_120.Color = Color.Brown;
                avr_120.Points.Clear();

                for (int i = 0; i < priceInfoList.Count - 120; i++)
                {
                    double avr_sum = 0.0;

                    for (int j = 0; j < 120; j++)
                    {
                        avr_sum += priceInfoList[i + j].종가;
                    }

                    priceInfoList[i].vavr_120 = avr_sum / 120;
                    avr_120.Points.AddXY(chart1.Series["volumeSeries"].Points[i].XValue, priceInfoList[i].vavr_120);
                }
            }
        }
    }
}
