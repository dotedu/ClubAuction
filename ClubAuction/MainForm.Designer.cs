namespace ClubAuction
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Remark = new System.Windows.Forms.TextBox();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.UserName = new System.Windows.Forms.Label();
            this.MoneyNum = new System.Windows.Forms.Label();
            this.Gifts = new System.Windows.Forms.GroupBox();
            this.ErrorTime = new System.Windows.Forms.Label();
            this.CheckTimeBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.MoreBtn = new System.Windows.Forms.Button();
            this.PageNum = new System.Windows.Forms.NumericUpDown();
            this.GiftList = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aucid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.starttime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Userinfo = new System.Windows.Forms.GroupBox();
            this.formhash = new System.Windows.Forms.Label();
            this.ContactGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GiftID = new System.Windows.Forms.TextBox();
            this.ManualBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.TextBox();
            this.mobile = new System.Windows.Forms.TextBox();
            this.realname = new System.Windows.Forms.TextBox();
            this.ConvertBox = new System.Windows.Forms.GroupBox();
            this.TryNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AutomaticBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.MainTip = new System.Windows.Forms.ToolTip(this.components);
            this.RetryNum = new System.Windows.Forms.Timer(this.components);
            this.Heartbeat = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ReasonStr = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.UidText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ReplayText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Score5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Score1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Score3 = new System.Windows.Forms.TextBox();
            this.UserGroup = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.Gifts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PageNum)).BeginInit();
            this.Userinfo.SuspendLayout();
            this.ContactGroupBox.SuspendLayout();
            this.ConvertBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TryNum)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Remark
            // 
            this.Remark.Location = new System.Drawing.Point(62, 87);
            this.Remark.Multiline = true;
            this.Remark.Name = "Remark";
            this.Remark.Size = new System.Drawing.Size(532, 35);
            this.Remark.TabIndex = 3;
            this.Remark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Remark_KeyDown);
            // 
            // Avatar
            // 
            this.Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Avatar.Location = new System.Drawing.Point(6, 20);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(48, 48);
            this.Avatar.TabIndex = 1;
            this.Avatar.TabStop = false;
            this.Avatar.WaitOnLoad = true;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserName.Location = new System.Drawing.Point(60, 20);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(42, 22);
            this.UserName.TabIndex = 2;
            this.UserName.Text = "花粉";
            // 
            // MoneyNum
            // 
            this.MoneyNum.AutoSize = true;
            this.MoneyNum.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.MoneyNum.Location = new System.Drawing.Point(114, 49);
            this.MoneyNum.Name = "MoneyNum";
            this.MoneyNum.Size = new System.Drawing.Size(17, 19);
            this.MoneyNum.TabIndex = 3;
            this.MoneyNum.Text = "0";
            this.MoneyNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Gifts
            // 
            this.Gifts.Controls.Add(this.ErrorTime);
            this.Gifts.Controls.Add(this.CheckTimeBtn);
            this.Gifts.Controls.Add(this.label6);
            this.Gifts.Controls.Add(this.RefreshBtn);
            this.Gifts.Controls.Add(this.MoreBtn);
            this.Gifts.Controls.Add(this.PageNum);
            this.Gifts.Controls.Add(this.GiftList);
            this.Gifts.Location = new System.Drawing.Point(12, 97);
            this.Gifts.Name = "Gifts";
            this.Gifts.Size = new System.Drawing.Size(600, 258);
            this.Gifts.TabIndex = 4;
            this.Gifts.TabStop = false;
            this.Gifts.Text = "兑换列表";
            // 
            // ErrorTime
            // 
            this.ErrorTime.AutoSize = true;
            this.ErrorTime.Location = new System.Drawing.Point(184, 233);
            this.ErrorTime.Name = "ErrorTime";
            this.ErrorTime.Size = new System.Drawing.Size(77, 12);
            this.ErrorTime.TabIndex = 11;
            this.ErrorTime.Text = "延迟约为：ms";
            this.ErrorTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MainTip.SetToolTip(this.ErrorTime, "正值表示本地时间比服务器快，负值则表示比服务器时间慢");
            // 
            // CheckTimeBtn
            // 
            this.CheckTimeBtn.Location = new System.Drawing.Point(94, 228);
            this.CheckTimeBtn.Name = "CheckTimeBtn";
            this.CheckTimeBtn.Size = new System.Drawing.Size(75, 23);
            this.CheckTimeBtn.TabIndex = 10;
            this.CheckTimeBtn.Text = "误差时间";
            this.CheckTimeBtn.UseVisualStyleBackColor = true;
            this.CheckTimeBtn.Click += new System.EventHandler(this.CheckTimeBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(402, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "页数:";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(8, 228);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshBtn.TabIndex = 8;
            this.RefreshBtn.Text = "刷新列表";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // MoreBtn
            // 
            this.MoreBtn.Location = new System.Drawing.Point(519, 228);
            this.MoreBtn.Name = "MoreBtn";
            this.MoreBtn.Size = new System.Drawing.Size(75, 23);
            this.MoreBtn.TabIndex = 7;
            this.MoreBtn.Text = "更多商品";
            this.MoreBtn.UseVisualStyleBackColor = true;
            this.MoreBtn.Click += new System.EventHandler(this.MoreBtn_Click);
            // 
            // PageNum
            // 
            this.PageNum.Location = new System.Drawing.Point(444, 229);
            this.PageNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PageNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PageNum.Name = "PageNum";
            this.PageNum.Size = new System.Drawing.Size(68, 21);
            this.PageNum.TabIndex = 6;
            this.MainTip.SetToolTip(this.PageNum, "选择获取多少页商店列表");
            this.PageNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // GiftList
            // 
            this.GiftList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GiftList.CheckBoxes = true;
            this.GiftList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.price,
            this.aucid,
            this.status,
            this.starttime,
            this.endtime});
            this.GiftList.FullRowSelect = true;
            this.GiftList.Location = new System.Drawing.Point(6, 20);
            this.GiftList.Name = "GiftList";
            this.GiftList.Size = new System.Drawing.Size(588, 202);
            this.GiftList.TabIndex = 5;
            this.GiftList.UseCompatibleStateImageBehavior = false;
            this.GiftList.View = System.Windows.Forms.View.Details;
            this.GiftList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.GiftList_ColumnClick);
            this.GiftList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.GiftList_ItemChecked);
            // 
            // name
            // 
            this.name.Text = "名称";
            this.name.Width = 200;
            // 
            // price
            // 
            this.price.Text = "价格";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.price.Width = 80;
            // 
            // aucid
            // 
            this.aucid.Text = "编号";
            this.aucid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.aucid.Width = 70;
            // 
            // status
            // 
            this.status.Text = "状态";
            this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.status.Width = 65;
            // 
            // starttime
            // 
            this.starttime.Text = "开始时间";
            this.starttime.Width = 130;
            // 
            // endtime
            // 
            this.endtime.Text = "结束时间";
            this.endtime.Width = 130;
            // 
            // Userinfo
            // 
            this.Userinfo.Controls.Add(this.label16);
            this.Userinfo.Controls.Add(this.UserGroup);
            this.Userinfo.Controls.Add(this.Avatar);
            this.Userinfo.Controls.Add(this.UserName);
            this.Userinfo.Controls.Add(this.MoneyNum);
            this.Userinfo.Location = new System.Drawing.Point(12, 11);
            this.Userinfo.Name = "Userinfo";
            this.Userinfo.Size = new System.Drawing.Size(600, 79);
            this.Userinfo.TabIndex = 5;
            this.Userinfo.TabStop = false;
            this.Userinfo.Text = "个人信息";
            // 
            // formhash
            // 
            this.formhash.AutoSize = true;
            this.formhash.Location = new System.Drawing.Point(322, 354);
            this.formhash.Name = "formhash";
            this.formhash.Size = new System.Drawing.Size(53, 12);
            this.formhash.TabIndex = 4;
            this.formhash.Text = "formhash";
            this.formhash.Visible = false;
            // 
            // ContactGroupBox
            // 
            this.ContactGroupBox.Controls.Add(this.checkBox1);
            this.ContactGroupBox.Controls.Add(this.label5);
            this.ContactGroupBox.Controls.Add(this.GiftID);
            this.ContactGroupBox.Controls.Add(this.ManualBtn);
            this.ContactGroupBox.Controls.Add(this.label4);
            this.ContactGroupBox.Controls.Add(this.label3);
            this.ContactGroupBox.Controls.Add(this.label2);
            this.ContactGroupBox.Controls.Add(this.label1);
            this.ContactGroupBox.Controls.Add(this.Address);
            this.ContactGroupBox.Controls.Add(this.mobile);
            this.ContactGroupBox.Controls.Add(this.realname);
            this.ContactGroupBox.Controls.Add(this.Remark);
            this.ContactGroupBox.Location = new System.Drawing.Point(12, 361);
            this.ContactGroupBox.Name = "ContactGroupBox";
            this.ContactGroupBox.Size = new System.Drawing.Size(600, 128);
            this.ContactGroupBox.TabIndex = 6;
            this.ContactGroupBox.TabStop = false;
            this.ContactGroupBox.Text = "联系方式";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(484, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "自动";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "商品信息：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GiftID
            // 
            this.GiftID.Location = new System.Drawing.Point(365, 19);
            this.GiftID.Name = "GiftID";
            this.GiftID.Size = new System.Drawing.Size(104, 21);
            this.GiftID.TabIndex = 4;
            this.MainTip.SetToolTip(this.GiftID, "手动指定抢购商品ID与开始时间，ID与时间用逗号隔开(选填)");
            // 
            // ManualBtn
            // 
            this.ManualBtn.Location = new System.Drawing.Point(538, 17);
            this.ManualBtn.Name = "ManualBtn";
            this.ManualBtn.Size = new System.Drawing.Size(56, 23);
            this.ManualBtn.TabIndex = 5;
            this.ManualBtn.Text = "兑换";
            this.ManualBtn.UseVisualStyleBackColor = true;
            this.ManualBtn.Click += new System.EventHandler(this.ManualBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "备  注：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "地  址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "电  话：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "联系人：";
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(62, 51);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(532, 21);
            this.Address.TabIndex = 2;
            // 
            // mobile
            // 
            this.mobile.Location = new System.Drawing.Point(205, 19);
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(80, 21);
            this.mobile.TabIndex = 1;
            // 
            // realname
            // 
            this.realname.Location = new System.Drawing.Point(62, 19);
            this.realname.Name = "realname";
            this.realname.Size = new System.Drawing.Size(80, 21);
            this.realname.TabIndex = 0;
            // 
            // ConvertBox
            // 
            this.ConvertBox.Controls.Add(this.TryNum);
            this.ConvertBox.Controls.Add(this.label8);
            this.ConvertBox.Controls.Add(this.label7);
            this.ConvertBox.Controls.Add(this.StartTimePicker);
            this.ConvertBox.Controls.Add(this.AutomaticBtn);
            this.ConvertBox.Location = new System.Drawing.Point(629, 138);
            this.ConvertBox.Name = "ConvertBox";
            this.ConvertBox.Size = new System.Drawing.Size(303, 78);
            this.ConvertBox.TabIndex = 7;
            this.ConvertBox.TabStop = false;
            this.ConvertBox.Text = "自动兑换";
            // 
            // TryNum
            // 
            this.TryNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TryNum.Location = new System.Drawing.Point(206, 50);
            this.TryNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TryNum.Name = "TryNum";
            this.TryNum.Size = new System.Drawing.Size(75, 21);
            this.TryNum.TabIndex = 4;
            this.MainTip.SetToolTip(this.TryNum, "抢兑次数");
            this.TryNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "停止中";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "兑换时间：";
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTimePicker.Location = new System.Drawing.Point(80, 20);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.ShowUpDown = true;
            this.StartTimePicker.Size = new System.Drawing.Size(90, 21);
            this.StartTimePicker.TabIndex = 1;
            this.StartTimePicker.Value = new System.DateTime(2016, 9, 26, 0, 0, 0, 0);
            // 
            // AutomaticBtn
            // 
            this.AutomaticBtn.Location = new System.Drawing.Point(206, 18);
            this.AutomaticBtn.Name = "AutomaticBtn";
            this.AutomaticBtn.Size = new System.Drawing.Size(75, 23);
            this.AutomaticBtn.TabIndex = 0;
            this.AutomaticBtn.Text = "自动兑换";
            this.AutomaticBtn.UseVisualStyleBackColor = true;
            this.AutomaticBtn.Click += new System.EventHandler(this.AutomaticBtn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 80;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // RetryNum
            // 
            this.RetryNum.Interval = 800;
            this.RetryNum.Tick += new System.EventHandler(this.RetryNum_Tick);
            // 
            // Heartbeat
            // 
            this.Heartbeat.Interval = 600000;
            this.Heartbeat.Tick += new System.EventHandler(this.Heartbeat_Tick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ReasonStr);
            this.GroupBox1.Controls.Add(this.label13);
            this.GroupBox1.Controls.Add(this.label9);
            this.GroupBox1.Controls.Add(this.button1);
            this.GroupBox1.Controls.Add(this.UidText);
            this.GroupBox1.Controls.Add(this.button2);
            this.GroupBox1.Controls.Add(this.ReplayText);
            this.GroupBox1.Controls.Add(this.label11);
            this.GroupBox1.Controls.Add(this.Score5);
            this.GroupBox1.Controls.Add(this.label10);
            this.GroupBox1.Controls.Add(this.Score1);
            this.GroupBox1.Controls.Add(this.label15);
            this.GroupBox1.Controls.Add(this.label12);
            this.GroupBox1.Controls.Add(this.label14);
            this.GroupBox1.Controls.Add(this.Score3);
            this.GroupBox1.Location = new System.Drawing.Point(12, 495);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(600, 182);
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "帖子管理";
            // 
            // ReasonStr
            // 
            this.ReasonStr.Location = new System.Drawing.Point(355, 45);
            this.ReasonStr.Name = "ReasonStr";
            this.ReasonStr.Size = new System.Drawing.Size(157, 21);
            this.ReasonStr.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(314, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "理由:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(518, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "回复成功！";
            this.label9.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "回复";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UidText
            // 
            this.UidText.Location = new System.Drawing.Point(64, 18);
            this.UidText.Name = "UidText";
            this.UidText.Size = new System.Drawing.Size(530, 21);
            this.UidText.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(519, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "点评";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ReplayText
            // 
            this.ReplayText.Location = new System.Drawing.Point(62, 74);
            this.ReplayText.Multiline = true;
            this.ReplayText.Name = "ReplayText";
            this.ReplayText.Size = new System.Drawing.Size(450, 100);
            this.ReplayText.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "回复内容:";
            // 
            // Score5
            // 
            this.Score5.Location = new System.Drawing.Point(257, 45);
            this.Score5.Name = "Score5";
            this.Score5.Size = new System.Drawing.Size(45, 21);
            this.Score5.TabIndex = 11;
            this.Score5.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "帖子 ID:";
            // 
            // Score1
            // 
            this.Score1.Location = new System.Drawing.Point(64, 45);
            this.Score1.Name = "Score1";
            this.Score1.Size = new System.Drawing.Size(45, 21);
            this.Score1.TabIndex = 3;
            this.Score1.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(216, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "花瓣:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "人   气:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(118, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "威望:";
            // 
            // Score3
            // 
            this.Score3.Location = new System.Drawing.Point(159, 45);
            this.Score3.Name = "Score3";
            this.Score3.Size = new System.Drawing.Size(45, 21);
            this.Score3.TabIndex = 6;
            this.Score3.Text = "0";
            // 
            // UserGroup
            // 
            this.UserGroup.AutoSize = true;
            this.UserGroup.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserGroup.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.UserGroup.Location = new System.Drawing.Point(214, 27);
            this.UserGroup.Name = "UserGroup";
            this.UserGroup.Size = new System.Drawing.Size(51, 19);
            this.UserGroup.TabIndex = 4;
            this.UserGroup.Text = "用户组";
            this.UserGroup.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label16.Location = new System.Drawing.Point(60, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 19);
            this.label16.TabIndex = 5;
            this.label16.Text = "花瓣：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 681);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.formhash);
            this.Controls.Add(this.ConvertBox);
            this.Controls.Add(this.Gifts);
            this.Controls.Add(this.Userinfo);
            this.Controls.Add(this.ContactGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "花粉俱乐部辅助工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.Gifts.ResumeLayout(false);
            this.Gifts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PageNum)).EndInit();
            this.Userinfo.ResumeLayout(false);
            this.Userinfo.PerformLayout();
            this.ContactGroupBox.ResumeLayout(false);
            this.ContactGroupBox.PerformLayout();
            this.ConvertBox.ResumeLayout(false);
            this.ConvertBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TryNum)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Remark;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label MoneyNum;
        private System.Windows.Forms.GroupBox Gifts;
        private System.Windows.Forms.GroupBox Userinfo;
        private System.Windows.Forms.Label formhash;
        private System.Windows.Forms.ListView GiftList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader aucid;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader starttime;
        private System.Windows.Forms.ColumnHeader endtime;
        private System.Windows.Forms.GroupBox ContactGroupBox;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox mobile;
        private System.Windows.Forms.TextBox realname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ConvertBox;
        private System.Windows.Forms.Button ManualBtn;
        private System.Windows.Forms.Button AutomaticBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DateTimePicker StartTimePicker;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button MoreBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox GiftID;
        private System.Windows.Forms.NumericUpDown PageNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip MainTip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer RetryNum;
        private System.Windows.Forms.NumericUpDown TryNum;
        private System.Windows.Forms.Timer Heartbeat;
        private System.Windows.Forms.Button CheckTimeBtn;
        private System.Windows.Forms.Label ErrorTime;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox UidText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ReplayText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Score5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Score3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Score1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ReasonStr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label UserGroup;
    }
}

