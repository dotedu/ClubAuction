using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubAuction
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private UserAccount useraccount;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Program.api.OnGetQRCodeImage = (image) => {
                RunInMainthread(() => {
                    RandomCodeImg.Image = image;
                });
            };
            Program.api.OnSetLocalInfo = () => {
                RunInMainthread(() => {
                    //textBox1.Text = Localinfo.DicLocalinfo["pageToken"];
                });
            };

            RunAsync(() => {

                Program.api.Run();
            });
        }
        private void userAccount_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userAccount.Text))
            {
                Program.api.OnValidUser = (Bool) => {
                    RunInMainthread(() => {
                        btnLogin.Enabled = Bool;
                        if (Bool)
                        {
                            useraccount = Program.api.getUserAccount(userAccount.Text);
                        }
                    });
                };

                RunAsync(() => {
                    Program.api.isValidUser(userAccount.Text);
                });


            }
        }


 

        private void RandomCodeImg_Click(object sender, EventArgs e)
        {
            Program.api.OnchgQRCodeImage = (image) => {
                RunInMainthread(() => {
                    RandomCodeImg.Image = image;
                });
            };
            RunAsync(() => {
                Program.api.chgRandomCodeForLogin();
            });

        }



        private void AuthCode_TextChanged(object sender, EventArgs e)
        {
            if (AuthCode.TextLength == 4)
            {
                Program.api.OnAuthCodeTure = () => {
                    RunInMainthread(() => {
                        AuthCode.ForeColor = Color.YellowGreen;
                        
                    });
                };

                Program.api.OnAuthCodeFalse = () => {
                    RunInMainthread(() => {
                        AuthCode.ForeColor = Color.Red;
                    });
                };

                RunAsync(() => {
                    Program.api.isAuthCodeValidate(AuthCode.Text);
                });

            }

        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            Program.api.login(userAccount.Text, Password.Text, AuthCode.Text, null, null, null);
            if (LoginResult.isSuccess == 1)
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                if (LoginResult.errorCode == "70002072")
                {
                    var authcode = new VerifyForm();
                    authcode.Owner = this;
                    authcode.strUserAccount = this.userAccount.Text;
                    authcode.strPassword = this.Password.Text;
                    authcode.strAuthCode = this.AuthCode.Text;
                    authcode.UserAccountList = this.useraccount;

                    authcode.ShowDialog();
                    if (authcode.DialogResult == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
                else
                {
                    if (LoginResult.errorCode== "10000400")
                    {
                        MessageBox.Show("错误：" + LoginResult.errorDesc + "\r\n错误代码：" + LoginResult.errorCode + "\r\n密码错误！！");

                    }
                    else
                    {
                        MessageBox.Show("错误：" + LoginResult.errorDesc + "\r\n错误代码：" + LoginResult.errorCode);

                    }

                }
            }
        }



        void RunAsync(Action action)
        {
            ((Action)(delegate () {
                action?.Invoke();
            })).BeginInvoke(null, null);
        }

        void RunInMainthread(Action action)
        {
            this.BeginInvoke((Action)(delegate () {
                action?.Invoke();
            }));
        }

        private long GetTimeStamp(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (dateTime.Ticks - dt1970.Ticks) / 10000;
        }
    }
}
