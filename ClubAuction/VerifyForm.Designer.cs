namespace ClubAuction
{
    partial class VerifyForm
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
            this.components = new System.ComponentModel.Container();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.oldAuthCode = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.getAuthCodeBtn = new System.Windows.Forms.Button();
            this.AccountList = new System.Windows.Forms.ComboBox();
            this.VerifyTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Enabled = false;
            this.ConfirmBtn.Location = new System.Drawing.Point(146, 103);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 4;
            this.ConfirmBtn.Text = "验证";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // oldAuthCode
            // 
            this.oldAuthCode.Location = new System.Drawing.Point(12, 63);
            this.oldAuthCode.MaxLength = 6;
            this.oldAuthCode.Name = "oldAuthCode";
            this.oldAuthCode.Size = new System.Drawing.Size(146, 21);
            this.oldAuthCode.TabIndex = 2;
            this.oldAuthCode.TextChanged += new System.EventHandler(this.oldAuthCode_TextChanged);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(34, 103);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // getAuthCodeBtn
            // 
            this.getAuthCodeBtn.Location = new System.Drawing.Point(164, 22);
            this.getAuthCodeBtn.Name = "getAuthCodeBtn";
            this.getAuthCodeBtn.Size = new System.Drawing.Size(85, 23);
            this.getAuthCodeBtn.TabIndex = 0;
            this.getAuthCodeBtn.Text = "获取验证码";
            this.getAuthCodeBtn.UseVisualStyleBackColor = true;
            this.getAuthCodeBtn.Click += new System.EventHandler(this.getAuthCodeBtn_Click);
            // 
            // AccountList
            // 
            this.AccountList.FormattingEnabled = true;
            this.AccountList.Location = new System.Drawing.Point(12, 23);
            this.AccountList.Name = "AccountList";
            this.AccountList.Size = new System.Drawing.Size(146, 20);
            this.AccountList.TabIndex = 1;
            // 
            // VerifyTimer
            // 
            this.VerifyTimer.Interval = 1000;
            this.VerifyTimer.Tick += new System.EventHandler(this.VerifyTimer_Tick);
            // 
            // VerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 141);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.oldAuthCode);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.getAuthCodeBtn);
            this.Controls.Add(this.AccountList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerifyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerifyForm";
            this.Load += new System.EventHandler(this.VerifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.TextBox oldAuthCode;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button getAuthCodeBtn;
        private System.Windows.Forms.ComboBox AccountList;
        private System.Windows.Forms.Timer VerifyTimer;
    }
}