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
    public partial class VerifyForm : Form
    {

        public VerifyForm()
        {
            InitializeComponent();
        }
        int timeLeft;

        private string UserAccount = string.Empty;
        public string strUserAccount
        {
            get
            {
                return UserAccount;
            }
            set
            {
                UserAccount = value;

            }
        }

        private string Password = string.Empty;
        public string strPassword
        {
            get
            {
                return Password;
            }
            set
            {
                Password = value;

            }
        }
        private string AuthCode = string.Empty;
        public string strAuthCode
        {
            get
            {
                return AuthCode;
            }
            set
            {
                AuthCode = value;

            }
        }
        private UserAccount Userinfo;
        public UserAccount UserAccountList
        {
            get
            {
                return Userinfo;
            }
            set
            {
                Userinfo = value;

            }
        }
        private void VerifyForm_Load(object sender, EventArgs e)
        {
            AccountList.DataSource = Userinfo.userAcctInfoList;
            AccountList.ValueMember = "accountType";
            AccountList.DisplayMember = "userAccount";

        }

        private void oldAuthCode_TextChanged(object sender, EventArgs e)
        {
            if (oldAuthCode.TextLength > 0)
            {
                ConfirmBtn.Enabled = true;
            }
            else
            {
                ConfirmBtn.Enabled = false;

            }

        }

        private void VerifyTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                getAuthCodeBtn.Text = "重新获取(" + timeLeft + ")";
            }
            else
            {
                VerifyTimer.Stop();
                getAuthCodeBtn.Text = "获取验证码";
                getAuthCodeBtn.Enabled = true;
            }

        }

        private void getAuthCodeBtn_Click(object sender, EventArgs e)
        {
            Program.api.getAuthCode(Convert.ToInt32(AccountList.SelectedValue), AccountList.Text, UserAccount, UserAccountList.userID);
            timeLeft = 60;
            getAuthCodeBtn.Enabled = false;
            VerifyTimer.Start();
            if (VerifyResult.isSuccess == 0)
            {
                MessageBox.Show("错误：" + VerifyResult.errorDesc + "\r\n错误代码：" + VerifyResult.errorCode);


            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();

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

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            Program.api.login(UserAccount, Password, AuthCode, oldAuthCode.Text, AccountList.SelectedValue.ToString(), AccountList.Text);
            if (LoginResult.isSuccess == 1)
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show("错误：" + LoginResult.errorDesc + "\r\n错误代码：" + LoginResult.errorCode);

            }
        }
    }
}
