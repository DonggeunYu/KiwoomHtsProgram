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

namespace HtsProgram
{
    public partial class Form1 : Form
    {
            List<itemEntityObject> itemAllList;
            List<itemEntityObject> kospiList;
            List<itemEntityObject> kosdaqList;
            List<itemEntityObject> elwList;

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

            this.nameSearchTextBox.GotFocus += this.TextBox_GotFocus;
            this.nameSearchTextBox.LostFocus += this.TextBox_LostFocus;
            this.codeSearchTextBox.GotFocus += this.TextBox_GotFocus;
            this.codeSearchTextBox.LostFocus += this.TextBox_LostFocus;
            this.nameSearchTextBox.TextChanged += this.Textbox_TextChanged;
            this.codeSearchTextBox.TextChanged += this.Textbox_TextChanged;


            allItemButton.Click += ButtonClicked;
            KospiButton.Click += ButtonClicked;
            kosdaqButton.Click += ButtonClicked;
            elwButton.Click += ButtonClicked;
            kospiAndKosdaqButton.Click += ButtonClicked;
        }

        class itemEntityObject
        {
            public string 종목명 { get; set; }
            public String 종목코드 { get; set; }
        }

        private void Textbox_TextChanged(object sender, EventArgs e)
        {
            if(sender.Equals(nameSearchTextBox) && nameSearchTextBox.Focused)
            {
                string x = nameSearchTextBox.Text;
                if(x.Length > 0)
                {
                    itemSearchGridView.Visible = true;
                    try
                    {
                        string pattern = "";
                        for(int i = 0; i < x.Length; i++)
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
                                if(magic == 0)
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
                            else if(x[i] >= 'A' && x[i] <= 'z')
                            {
                                pattern += x[i];
                            }
                            // 숫자를 입력했을 때
                            else if(x[i] >= '0' && x[i] <= '9')
                            {
                                pattern += x[i];
                            }
                        }
                        var res = itemAllList.Where(c => Regex.IsMatch(c.종목명, pattern));
                        List<itemEntityObject> list = new List<itemEntityObject>();
                        list.AddRange(res);

                        itemSearchGridView.DataSource = list;
                    }
                    catch(Exception exception) { }
                }
                else
                {
                    itemSearchGridView.Visible = false;
                }
            }
            else if(sender.Equals(codeSearchTextBox) && codeSearchTextBox.Focused)
            {
                string x = codeSearchTextBox.Text;
                if(x.Length > 0)
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
                for(int i = 0; i < itemAllList.Count; i++)
                {
                    itemGridView.Rows.Add();
                    itemGridView["종목명", i].Value = itemAllList[i].종목명;
                    itemGridView["코드", i].Value = itemAllList[i].종목코드;
                }
                itemGridView.Sort(itemGridView.Columns[0], ListSortDirection.Ascending);
            }
            else if(sender.Equals(this.KospiButton) || sender.Equals(this.kosdaqButton) || sender.Equals(this.elwButton))
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

                if(itemList == null)
                {
                    itemList = new List<itemEntityObject>();
                    string codeList = axKHOpenAPI1.GetCodeListByMarket(marketCode);
                    string[] codeListArray = codeList.Split(';');

                    for(int i = 0; i < codeListArray.Length; i++)
                    {
                        string code = codeListArray[i];
                        if(code.Length > 0)
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
                    for(int i = 0; i < itemList.Count; i++)
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

                for(int i = 0; i < kospiList.Count; i++)
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
        }

         private void AxKHOpenAPI_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if(e.nErrCode == 0) // 로그인 성공
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

                for(int i = 0; i < codeListArray.Length; i++)
                {
                    string code = codeListArray[i];
                    if(code.Length > 0)
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
                        if(Convert.ToDouble(Ratio) > 0)
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
                    rowCollection.Add(new object[] { false, Name, Sum, "", AVGSum, Price, BuyPrice, EvaluationPrice, ProfitPrice, ax, S});


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

                if(Convert.ToDouble(label9.Text) > 0)
                {
                    label9.ForeColor = Color.Red;
                }else if(Convert.ToDouble(label9.Text) == 0)
                {
                    label9.ForeColor = Color.Black;
                }else if (Convert.ToDouble(label9.Text) < 0)
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

            
        }

        private void getUserInfo()
        {
            username_textbox.Text = axKHOpenAPI1.GetLoginInfo("USER_NAME");
            id_textbox.Text = axKHOpenAPI1.GetLoginInfo("USER_ID");
            string[] acountArray = axKHOpenAPI1.GetLoginInfo("ACCNO").Split(';');
            this.comboBox1.Items.AddRange(acountArray);
            comboBox1.Text = acountArray[0];
        }


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
            if(axKHOpenAPI1.CommConnect() == 0)
            {
                textBox1.Text += "로그인 시작\n";
            }
        }
    }
}
