using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubAuction
{
    public partial class MainForm : Form
    {
        #region 自定义变量        
        int currentCol = -1;
        bool sort;
        #endregion
        int timeLeft=0;
        int count = 0;
        int heartbeat;

        int AutoExchange = 0;
        int AutoExchanging = 0;

        public static Version ApplicationVersion = new Version(Application.ProductVersion);
        string AppVersion = ApplicationVersion.ToString();

        int GiftListCount = 0; 

        public MainForm()
        {
            InitializeComponent();
        }

        private const string ContactsFileName = "contacts.cfg";
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "花粉俱乐部辅助工具 - "+ AppVersion;
            heartbeat = 100;
            StartTimePicker.Value = DateTime.Now;

            Program.api.Onlogin = () =>
            {
                    RunInMainthread(() =>
                    {
                        Avatar.Image = Program.api.getAvatar();
                        UserName.Text = AccountInfo.UserName;
                        MoneyNum.Text = AccountInfo.MoneyNum;
                    });


            };
            Program.api.OngetFormHash = () => {
                RunInMainthread(() => {
                    formhash.Text = LoginResult.formhash;
                });
                RunAsync(() => {
                    Program.api.qiandao();
                });
            };
            Program.api.OnAddListItem = (list) => {
                RunInMainthread(() => {
                    var lv = new ListViewItem(list[0]);
                    lv.SubItems.Add(list[1]);
                    lv.SubItems.Add(list[2]);
                    lv.SubItems.Add(list[3]);
                    lv.SubItems.Add(list[4]);
                    lv.SubItems.Add(list[5]);
                    GiftList.Items.Add(lv);
                });
            };

           
            RunAsync(() => {
                Program.api.getAuctionInfo();

            });
            var contacts = ReadOptions();

            realname.Text= contacts.realname;
            mobile.Text=contacts.mobile;
            Address.Text=contacts.address;
            Remark.Text=contacts.remark;

        }


        private void Remark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                ((TextBox)sender).SelectAll();

        }

        private void ManualBtn_Click(object sender, EventArgs e)
        {
            //Debug.Write(AutoExchanging);
            //Debug.Write(AutoExchange);


            if (!string.IsNullOrEmpty(GiftID.Text) || GiftListCount > 0)
            {
                if (AutoExchange == 1 && AutoExchanging == 0)
                {
                    AutoExchanging = 1;
                    timer.Start();
                }
                else if (AutoExchange == 1 && AutoExchanging == 1)
                {
                    AutoExchanging = 0;

                }
                else
                {
                    exchange();
                }

            }
            else
            {
                MessageBox.Show("未选择兑换商品");
            }
            Contacts contacts = new Contacts();
            contacts.realname = realname.Text;
            contacts.mobile = mobile.Text;
            contacts.address = Address.Text;
            contacts.remark = Remark.Text;
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, ContactsFileName),
                JsonConvert.SerializeObject(contacts, Formatting.Indented));


        }

        private void AutomaticBtn_Click(object sender, EventArgs e)
        {
            var time = DateTimeToStamp(StartTimePicker.Value) - DateTimeToStamp(DateTime.Now);
            if (!string.IsNullOrEmpty(GiftID.Text) || GiftListCount > 0)
            {
                if (timeLeft == 0 && time >= 0)
                {
                    timeLeft = time;
                    timer.Start();
                    AutomaticBtn.Text = "停止计时";
                }
                else
                {
                    timer.Stop();
                    timeLeft = 0;
                    AutomaticBtn.Text = "自动兑换";
                }
            }
            else
            {
                MessageBox.Show("未选择兑换商品");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (AutoExchanging == 1)
            {
                exchange();
                ManualBtn.Text = "兑换中";


            }
            else
            {
                timer.Stop();
                ManualBtn.Text = "兑换";

            }

        }
        private void RetryNum_Tick(object sender, EventArgs e)
        {
            if (count > 0)
            {
                AutomaticBtn.Text = "兑换中";
                count = count - 1;

                exchange();

            }
            else
            {
                RetryNum.Stop();
                AutomaticBtn.Text = "自动兑换";
                label8.Text = "停止中";

            }
        }

        private void MoreBtn_Click(object sender, EventArgs e)
        {
            GiftList.Items.Clear();
            Program.api.OnAddListItem = (list) => {
                RunInMainthread(() => {
                    var lv = new ListViewItem(list[0]);
                    lv.SubItems.Add(list[1]);
                    lv.SubItems.Add(list[2]);
                    lv.SubItems.Add(list[3]);
                    lv.SubItems.Add(list[4]);
                    lv.SubItems.Add(list[5]);
                    GiftList.Items.Add(lv);
                });
            };
            for (int i = 0; i < PageNum.Value; i++)
            {
                RunAsync((num) => {
                        Program.api.getMoreAuctionlist((int)num + 1);
                },i);
            }


        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            GiftList.Items.Clear();

            Program.api.OnAddListItem = (list) => {
                RunInMainthread(() => {
                    var lv = new ListViewItem(list[0]);
                    lv.SubItems.Add(list[1]);
                    lv.SubItems.Add(list[2]);
                    lv.SubItems.Add(list[3]);
                    lv.SubItems.Add(list[4]);
                    lv.SubItems.Add(list[5]);
                    GiftList.Items.Add(lv);
                });
            };


            RunAsync(() => {

                Program.api.RefreshGiftList();

            });
        }

        private void GiftList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string Asc = ((char)0x25bc).ToString().PadLeft(4, ' ');
            string Des = ((char)0x25b2).ToString().PadLeft(4, ' ');

            if (sort == false)
            {
                sort = true;
                string oldStr = this.GiftList.Columns[e.Column].Text.TrimEnd((char)0x25bc, (char)0x25b2, ' ');
                this.GiftList.Columns[e.Column].Text = oldStr + Des;
            }
            else if (sort == true)
            {
                sort = false;
                string oldStr = this.GiftList.Columns[e.Column].Text.TrimEnd((char)0x25bc, (char)0x25b2, ' ');
                this.GiftList.Columns[e.Column].Text = oldStr + Asc;
            }

            GiftList.ListViewItemSorter = new ListViewItemComparer(e.Column, sort);
            this.GiftList.Sort();
            int rowCount = this.GiftList.Items.Count;
            if (currentCol != -1)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    this.GiftList.Items[i].UseItemStyleForSubItems = false;
                    this.GiftList.Items[i].SubItems[currentCol].BackColor = Color.White;

                    if (e.Column != currentCol)
                        this.GiftList.Columns[currentCol].Text = this.GiftList.Columns[currentCol].Text.TrimEnd((char)0x25bc, (char)0x25b2, ' ');
                }
            }

            for (int i = 0; i < rowCount; i++)
            {
                this.GiftList.Items[i].UseItemStyleForSubItems = false;
                this.GiftList.Items[i].SubItems[e.Column].BackColor = Color.WhiteSmoke;
                currentCol = e.Column;
            }
        }


        void RunAsync(Action action)
        {
            ((Action)(delegate () {
                action?.Invoke();
            })).BeginInvoke(null, null);
        }

        void RunAsync(Action<object> action, object parameter)
        {
            ((Action)(delegate () {
                action?.Invoke(parameter);
            })).BeginInvoke(null, null);
        }
        void RunAsync(Action<string[]> action, string[] parameter)
        {
            ((Action)(delegate () {
                action?.Invoke(parameter);
            })).BeginInvoke(null, null);
        }

        void RunInMainthread(Action action)
        {
            this.BeginInvoke((Action)(delegate () {
                action?.Invoke();
            }));
        }

        void RunInMainthread(Action<object> action, object parameter)
        {
            this.BeginInvoke((Action)(delegate () {
                action?.Invoke(parameter);
            }));
        }


        private Contacts ReadOptions()
        {
            Contacts options;
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, ContactsFileName)))
            {
                options = JsonConvert.DeserializeObject<Contacts>(
                    File.ReadAllText(Path.Combine(Environment.CurrentDirectory, ContactsFileName)));
            }
            else
            {
                options = new Contacts();
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, ContactsFileName),
                    JsonConvert.SerializeObject(options, Formatting.Indented));
            }
            return options;
        }

        private int DateTimeToStamp(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }


        private String formatLongToTimeStr(int i)
        {
            int hour = 0;
            int minute = 0;
            int second=0;

            if (i > 60)
            {
                minute = i / 60;
                second = i % 60;
            }
            else
            {
                second = i;

            }
            if (minute > 60)
            {
                hour = minute / 60;
                minute = minute % 60;
            }
            if (hour>0)
            {
                return (hour + "小时" + minute + "分钟"+ second + "秒");

            }
            else if(minute >0)
            {

                return (minute + "分钟" + second + "秒");

            }
            else
            {
                return (second + "秒");

            }
        }

        private void exchange()
        {
            if (!string.IsNullOrEmpty(GiftID.Text))
            {
                if (GiftID.Text.Contains("-"))
                {
                    var t1 = Convert.ToInt32(sArray2(GiftID.Text)[0]);
                    var t2 = Convert.ToInt32(sArray2(GiftID.Text)[1]);
                    for (int i = t1; i < t2; i++)
                    {
                        var parameter1 = new string[7];
                        parameter1[0] = i.ToString();
                        parameter1[1] = Program.api.getDetail(i.ToString())[1];
                        parameter1[2] = realname.Text;
                        parameter1[3] = mobile.Text;
                        parameter1[4] = Address.Text;
                        parameter1[5] = Remark.Text;

                        Program.api.OnEexchangeSuccess = () => {
                            RunInMainthread(() => {
                                //MessageBox.Show("兑换成功");
                                Program.api.getAccountInfo();
                                MoneyNum.Text = AccountInfo.MoneyNum;

                            });
                        };
                        Program.api.OnEexchangeOver = () => {
                            RunInMainthread(() => {
                                MessageBox.Show("已经结束");
                            });
                        };
                        RunAsync((para) => {
                            var s1 = (para[0]);
                            var s2 = (para[1]);
                            var s3 = (para[2]);
                            var s4 = (para[3]);
                            var s5 = (para[4]);
                            var s6 = (para[5]);

                            Program.api.EexchangebyId(s1, s2, s3, s4, s5, s6);

                        }, parameter1);
                    }
                }
                else if (GiftID.Text.Contains(","))
                {
                    foreach (var item in sArray1(GiftID.Text))
                    {
                        var parameter1 = new string[7];
                        parameter1[0] = item;
                        parameter1[1] = Program.api.getDetail(item)[1];
                        parameter1[2] = realname.Text;
                        parameter1[3] = mobile.Text;
                        parameter1[4] = Address.Text;
                        parameter1[5] = Remark.Text;

                        Program.api.OnEexchangeSuccess = () => {
                            RunInMainthread(() => {
                                //MessageBox.Show("兑换成功");
                                Program.api.getAccountInfo();
                                MoneyNum.Text = AccountInfo.MoneyNum;

                            });
                        };
                        Program.api.OnEexchangeOver = () => {
                            RunInMainthread(() => {
                                MessageBox.Show("已经结束");
                            });
                        };
                        RunAsync((para) => {
                            var s1 = (para[0]);
                            var s2 = (para[1]);
                            var s3 = (para[2]);
                            var s4 = (para[3]);
                            var s5 = (para[4]);
                            var s6 = (para[5]);

                            Program.api.EexchangebyId(s1, s2, s3, s4, s5, s6);

                        }, parameter1);
                    }
                }
                else
                {
                    var parameter1 = new string[7];
                    parameter1[0] = GiftID.Text;
                    parameter1[1] = Program.api.getDetail(GiftID.Text)[1];
                    parameter1[2] = realname.Text;
                    parameter1[3] = mobile.Text;
                    parameter1[4] = Address.Text;
                    parameter1[5] = Remark.Text;

                    Program.api.OnEexchangeSuccess = () => {
                        RunInMainthread(() => {
                            MessageBox.Show("兑换成功");
                            Program.api.getAccountInfo();
                            MoneyNum.Text = AccountInfo.MoneyNum;

                        });
                    };
                    Program.api.OnEexchangeOver = () => {
                        RunInMainthread(() => {
                            MessageBox.Show("已经结束");
                        });
                    };
                    RunAsync((para) => {
                        var s1 = (para[0]);
                        var s2 = (para[1]);
                        var s3 = (para[2]);
                        var s4 = (para[3]);
                        var s5 = (para[4]);
                        var s6 = (para[5]);

                        Program.api.EexchangebyId(s1, s2, s3, s4, s5, s6);

                    }, parameter1);
                }
                


            }


            if (GiftListCount > 0)
            {
                //GiftList.CheckedItems[0].SubItems[2].Text
                //GiftList.Sort();


                for (int i = 0; i < this.GiftListCount; i++)
                {
                    if (this.GiftList.CheckedItems[i].Checked)
                    {
                        var parameter = new string[7];
                        parameter[0] = i.ToString();
                        parameter[1] = GiftList.CheckedItems[i].SubItems[2].Text;
                        parameter[2] = GiftList.CheckedItems[i].SubItems[4].Text;
                        parameter[3] = realname.Text;
                        parameter[4] = mobile.Text;
                        parameter[5] = Address.Text;
                        parameter[6] = Remark.Text;

                        Program.api.OnEexchangeSuccess = () => {
                            RunInMainthread(() => {
                                if (GiftListCount==1)
                                {
                                    MessageBox.Show("兑换成功");

                                }
                                Program.api.getAccountInfo();
                                MoneyNum.Text = AccountInfo.MoneyNum;

                            });
                        };


                        Program.api.OnEexchange = (arr) => {
                            RunInMainthread((para) => {
                                var num = Convert.ToInt32(arr[0]);
                                GiftList.CheckedItems[num].SubItems[3].Text = arr[1];
                            }, parameter);
                        };
                        RunAsync((para) => {
                            var s0 = (para[0]);
                            var s1 = (para[1]);
                            var s2 = (para[2]);
                            var s3 = (para[3]);
                            var s4 = (para[4]);
                            var s5 = (para[5]);
                            var s6 = (para[6]);

                            Program.api.Eexchange(s0,s1, s2, s3, s4, s5, s6);

                        }, parameter);

                    }
                    //Delay(3000);
                    Debug.Write(i);

                }
            }
        }


        public void Delay(int mm)
        {
            DateTime current = DateTime.Now;

            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }
        private string[] sArray1(string GiftText)
        {
            var t = GiftText.Split(',');
            return t;
        }
        private string[] sArray2(string GiftText)
        {
            var t = GiftText.Split('-');
            return t;
        }
        private void Heartbeat_Tick(object sender, EventArgs e)
        {
            if (heartbeat > 0)
            {
                heartbeat = heartbeat - 1;
                RunAsync(() => {
                    Program.api.heartbeat();
                });
               
            }
            else
            {
                MessageBox.Show("登陆即将过期，请退出后重新登陆");
            }
        }

        private void CheckTimeBtn_Click(object sender, EventArgs e)
        {
            var t1 = GetTimeStamp(DateTime.Now);
            ErrorTime.Text = "误差约为：" + Program.api.checktime(t1) + "ms";
            //label9.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
        }

        private long GetTimeStamp(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (dateTime.Ticks - dt1970.Ticks) / 10000;
        }
        private DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                AutoExchange = 1;
            }
            else
            {
                AutoExchange = 0;
                AutoExchanging = 0;

            }
        }

        private void GiftList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            GiftListCount = GiftList.CheckedItems.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            Program.api.OnReplaySuccess = () => {
                RunInMainthread(() => {
                    label9.Visible = true;
                });
            };

            var ReplyStr = ReplayText.Text;
            if (!string.IsNullOrEmpty(ReplayText.Text)&& !string.IsNullOrEmpty(UidText.Text))
            {
                Program.api.Reply(UidText.Text, ReplayText.Text);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            Program.api.OnRateSuccess = () => {
                RunInMainthread(() => {
                    MessageBox.Show("评分成功");
                });
            };
            Program.api.OnRateFail = () => {
                RunInMainthread(() => {
                    MessageBox.Show("24小时评分超过限制");
                });
            };
            
            if (!string.IsNullOrEmpty(Score1.Text) && !string.IsNullOrEmpty(Score3.Text) && !string.IsNullOrEmpty(Score5.Text) && !string.IsNullOrEmpty(UidText.Text))
            {
                Program.api.Rate(UidText.Text, Score1.Text, Score3.Text, Score5.Text, ReasonStr.Text);

            }
        }
    }

}
