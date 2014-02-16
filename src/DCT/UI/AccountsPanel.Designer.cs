namespace DCT.UI
{
    partial class AccountsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpConnections = new System.Windows.Forms.GroupBox();
            this.pnl = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lnkChkServer = new System.Windows.Forms.LinkLabel();
            this.lnkAccountsCheckAll = new System.Windows.Forms.LinkLabel();
            this.lnkAccountsUncheckAll = new System.Windows.Forms.LinkLabel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvAccounts = new System.Windows.Forms.ListView();
            this.clmCharName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmInRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMobs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEXP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAvgExp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.login_rgsessid = new System.ComponentModel.BackgroundWorker();
            this.login_normal = new System.ComponentModel.BackgroundWorker();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.grpConnections.SuspendLayout();
            this.pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnections
            // 
            this.grpConnections.Controls.Add(this.pnl);
            this.grpConnections.Controls.Add(this.lvAccounts);
            this.grpConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConnections.Location = new System.Drawing.Point(0, 0);
            this.grpConnections.Name = "grpConnections";
            this.grpConnections.Size = new System.Drawing.Size(230, 436);
            this.grpConnections.TabIndex = 12;
            this.grpConnections.TabStop = false;
            this.grpConnections.Text = "Connections";
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.linkLabel2);
            this.pnl.Controls.Add(this.linkLabel1);
            this.pnl.Controls.Add(this.lnkChkServer);
            this.pnl.Controls.Add(this.lnkAccountsCheckAll);
            this.pnl.Controls.Add(this.lnkAccountsUncheckAll);
            this.pnl.Controls.Add(this.btnRefresh);
            this.pnl.Controls.Add(this.btnLogout);
            this.pnl.Controls.Add(this.btnLogin);
            this.pnl.Controls.Add(this.txtPassword);
            this.pnl.Controls.Add(this.txtUsername);
            this.pnl.Controls.Add(this.label1);
            this.pnl.Controls.Add(this.label2);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl.Location = new System.Drawing.Point(3, 314);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(230, 119);
            this.pnl.TabIndex = 13;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(77, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(36, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Import";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkChkServer
            // 
            this.lnkChkServer.AutoSize = true;
            this.lnkChkServer.Location = new System.Drawing.Point(139, 5);
            this.lnkChkServer.Name = "lnkChkServer";
            this.lnkChkServer.Size = new System.Drawing.Size(70, 13);
            this.lnkChkServer.TabIndex = 12;
            this.lnkChkServer.TabStop = true;
            this.lnkChkServer.Text = "Check server";
            this.lnkChkServer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChkServer_LinkClicked);
            // 
            // lnkAccountsCheckAll
            // 
            this.lnkAccountsCheckAll.AutoSize = true;
            this.lnkAccountsCheckAll.Location = new System.Drawing.Point(22, 5);
            this.lnkAccountsCheckAll.Name = "lnkAccountsCheckAll";
            this.lnkAccountsCheckAll.Size = new System.Drawing.Size(52, 13);
            this.lnkAccountsCheckAll.TabIndex = 2;
            this.lnkAccountsCheckAll.TabStop = true;
            this.lnkAccountsCheckAll.Text = "Check All";
            this.lnkAccountsCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccountsCheckAll_LinkClicked);
            // 
            // lnkAccountsUncheckAll
            // 
            this.lnkAccountsUncheckAll.AutoSize = true;
            this.lnkAccountsUncheckAll.Location = new System.Drawing.Point(74, 5);
            this.lnkAccountsUncheckAll.Name = "lnkAccountsUncheckAll";
            this.lnkAccountsUncheckAll.Size = new System.Drawing.Size(65, 13);
            this.lnkAccountsUncheckAll.TabIndex = 3;
            this.lnkAccountsUncheckAll.TabStop = true;
            this.lnkAccountsUncheckAll.Text = "Uncheck All";
            this.lnkAccountsUncheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccountsUncheckAll_LinkClicked);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(85, 93);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(152, 93);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(61, 23);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(18, 93);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(61, 23);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(107, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(110, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(107, 42);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(110, 20);
            this.txtUsername.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rampid Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rampid Password:";
            // 
            // lvAccounts
            // 
            this.lvAccounts.CheckBoxes = true;
            this.lvAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmCharName,
            this.clmInRoom,
            this.clmMobs,
            this.clmEXP,
            this.clmAvgExp});
            this.lvAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAccounts.FullRowSelect = true;
            this.lvAccounts.GridLines = true;
            this.lvAccounts.Location = new System.Drawing.Point(3, 16);
            this.lvAccounts.Name = "lvAccounts";
            this.lvAccounts.Size = new System.Drawing.Size(224, 298);
            this.lvAccounts.TabIndex = 1;
            this.lvAccounts.UseCompatibleStateImageBehavior = false;
            this.lvAccounts.View = System.Windows.Forms.View.Details;
            this.lvAccounts.SelectedIndexChanged += new System.EventHandler(this.lvAccounts_SelectedIndexChanged);
            // 
            // clmCharName
            // 
            this.clmCharName.Text = "Name";
            // 
            // clmInRoom
            // 
            this.clmInRoom.Text = "In";
            this.clmInRoom.Width = 30;
            // 
            // clmMobs
            // 
            this.clmMobs.Text = "Mobs";
            this.clmMobs.Width = 30;
            // 
            // clmEXP
            // 
            this.clmEXP.Text = "xpGain";
            this.clmEXP.Width = 45;
            // 
            // clmAvgExp
            // 
            this.clmAvgExp.Text = "xpAvg";
            this.clmAvgExp.Width = 50;
            // 
            // login_rgsessid
            // 
            this.login_rgsessid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.login_rgsessid_DoWork);
            this.login_rgsessid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.login_rgsessid_RunWorkerCompleted);
            // 
            // login_normal
            // 
            this.login_normal.DoWork += new System.ComponentModel.DoWorkEventHandler(this.login_normal_DoWork);
            this.login_normal.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.login_normal_RunWorkerCompleted);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(116, 18);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(37, 13);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Export";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // AccountsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpConnections);
            this.Name = "AccountsPanel";
            this.Size = new System.Drawing.Size(230, 436);
            this.grpConnections.ResumeLayout(false);
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnections;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkAccountsUncheckAll;
        private System.Windows.Forms.LinkLabel lnkAccountsCheckAll;
        internal System.Windows.Forms.ListView lvAccounts;
        private System.Windows.Forms.ColumnHeader clmCharName;
        private System.Windows.Forms.ColumnHeader clmInRoom;
        private System.Windows.Forms.ColumnHeader clmMobs;
        private System.Windows.Forms.ColumnHeader clmEXP;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.ColumnHeader clmAvgExp;
        private System.ComponentModel.BackgroundWorker login_rgsessid;
        private System.ComponentModel.BackgroundWorker login_normal;
        private System.Windows.Forms.LinkLabel lnkChkServer;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}
