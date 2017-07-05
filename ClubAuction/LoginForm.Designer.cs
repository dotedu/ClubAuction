namespace ClubAuction
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.RandomCodeImg = new System.Windows.Forms.PictureBox();
            this.AuthCode = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.userAccount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RandomCodeImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "验证码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "密  码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "账  号：";
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(76, 126);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // RandomCodeImg
            // 
            this.RandomCodeImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RandomCodeImg.Location = new System.Drawing.Point(164, 85);
            this.RandomCodeImg.Name = "RandomCodeImg";
            this.RandomCodeImg.Size = new System.Drawing.Size(72, 36);
            this.RandomCodeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RandomCodeImg.TabIndex = 8;
            this.RandomCodeImg.TabStop = false;
            this.RandomCodeImg.Click += new System.EventHandler(this.RandomCodeImg_Click);
            // 
            // AuthCode
            // 
            this.AuthCode.Location = new System.Drawing.Point(76, 93);
            this.AuthCode.MaxLength = 4;
            this.AuthCode.Name = "AuthCode";
            this.AuthCode.Size = new System.Drawing.Size(82, 21);
            this.AuthCode.TabIndex = 11;
            this.AuthCode.TextChanged += new System.EventHandler(this.AuthCode_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(76, 55);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(160, 21);
            this.Password.TabIndex = 10;
            // 
            // userAccount
            // 
            this.userAccount.Location = new System.Drawing.Point(76, 15);
            this.userAccount.Name = "userAccount";
            this.userAccount.Size = new System.Drawing.Size(160, 21);
            this.userAccount.TabIndex = 9;
            this.userAccount.Leave += new System.EventHandler(this.userAccount_Leave);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 161);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.RandomCodeImg);
            this.Controls.Add(this.AuthCode);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.userAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆窗";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RandomCodeImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox RandomCodeImg;
        private System.Windows.Forms.TextBox AuthCode;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox userAccount;
    }
}