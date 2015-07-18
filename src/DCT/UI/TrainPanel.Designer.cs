namespace DCT.UI
{
    partial class TrainPanel
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Main", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Potion", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Orbs", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lnkLingBuff = new System.Windows.Forms.LinkLabel();
            this.chkAutoTrain = new System.Windows.Forms.CheckBox();
            this.chkTrainReturn = new System.Windows.Forms.CheckBox();
            this.lblTrain = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFuryCasted = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFury = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkCast = new System.Windows.Forms.LinkLabel();
            this.lblCasted = new System.Windows.Forms.Label();
            this.lnkRefreshCasted = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkUseBoosters = new System.Windows.Forms.CheckBox();
            this.rdMinorExp = new System.Windows.Forms.RadioButton();
            this.rdMajorExp = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkSecurity = new System.Windows.Forms.CheckBox();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.lvBackpack = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(411, 288);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lnkLingBuff);
            this.tabPage1.Controls.Add(this.chkAutoTrain);
            this.tabPage1.Controls.Add(this.chkTrainReturn);
            this.tabPage1.Controls.Add(this.lblTrain);
            this.tabPage1.Controls.Add(this.btnTrain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(403, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Trainer\\Buff";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lnkLingBuff
            // 
            this.lnkLingBuff.AutoSize = true;
            this.lnkLingBuff.Location = new System.Drawing.Point(115, 125);
            this.lnkLingBuff.Name = "lnkLingBuff";
            this.lnkLingBuff.Size = new System.Drawing.Size(183, 13);
            this.lnkLingBuff.TabIndex = 12;
            this.lnkLingBuff.TabStop = true;
            this.lnkLingBuff.Text = "Cast Ling Buff On Selected Accounts";
            this.lnkLingBuff.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLingBuff_LinkClicked_1);
            // 
            // chkAutoTrain
            // 
            this.chkAutoTrain.AutoSize = true;
            this.chkAutoTrain.Checked = true;
            this.chkAutoTrain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoTrain.Location = new System.Drawing.Point(6, 6);
            this.chkAutoTrain.Name = "chkAutoTrain";
            this.chkAutoTrain.Size = new System.Drawing.Size(245, 17);
            this.chkAutoTrain.TabIndex = 8;
            this.chkAutoTrain.Text = "Automatically train accounts that need leveling";
            this.chkAutoTrain.UseVisualStyleBackColor = true;
            this.chkAutoTrain.CheckedChanged += new System.EventHandler(this.chkAutoTrain_CheckedChanged_1);
            // 
            // chkTrainReturn
            // 
            this.chkTrainReturn.AutoSize = true;
            this.chkTrainReturn.Location = new System.Drawing.Point(43, 64);
            this.chkTrainReturn.Name = "chkTrainReturn";
            this.chkTrainReturn.Size = new System.Drawing.Size(132, 17);
            this.chkTrainReturn.TabIndex = 10;
            this.chkTrainReturn.Text = "Move back afterwards";
            this.chkTrainReturn.UseVisualStyleBackColor = true;
            this.chkTrainReturn.Visible = false;
            // 
            // lblTrain
            // 
            this.lblTrain.AutoSize = true;
            this.lblTrain.Location = new System.Drawing.Point(22, 84);
            this.lblTrain.Name = "lblTrain";
            this.lblTrain.Size = new System.Drawing.Size(344, 13);
            this.lblTrain.TabIndex = 9;
            this.lblTrain.Text = "The checked accounts will be moved to the nearest trainer and trained.";
            this.lblTrain.Visible = false;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(129, 29);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(155, 23);
            this.btnTrain.TabIndex = 11;
            this.btnTrain.Text = "Level selected accounts";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(403, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Potions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 231);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Potions";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFuryCasted);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbFury);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 76);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rage Potions";
            // 
            // lblFuryCasted
            // 
            this.lblFuryCasted.AutoSize = true;
            this.lblFuryCasted.Location = new System.Drawing.Point(107, 37);
            this.lblFuryCasted.Name = "lblFuryCasted";
            this.lblFuryCasted.Size = new System.Drawing.Size(13, 13);
            this.lblFuryCasted.TabIndex = 48;
            this.lblFuryCasted.Text = "0";
            this.lblFuryCasted.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Casted:";
            this.label1.Visible = false;
            // 
            // cbFury
            // 
            this.cbFury.AutoSize = true;
            this.cbFury.Location = new System.Drawing.Point(6, 36);
            this.cbFury.Name = "cbFury";
            this.cbFury.Size = new System.Drawing.Size(46, 17);
            this.cbFury.TabIndex = 46;
            this.cbFury.Text = "Fury";
            this.cbFury.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnkCast);
            this.groupBox2.Controls.Add(this.lblCasted);
            this.groupBox2.Controls.Add(this.lnkRefreshCasted);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkUseBoosters);
            this.groupBox2.Controls.Add(this.rdMinorExp);
            this.groupBox2.Controls.Add(this.rdMajorExp);
            this.groupBox2.Location = new System.Drawing.Point(6, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 124);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Experience Potions";
            // 
            // lnkCast
            // 
            this.lnkCast.AutoSize = true;
            this.lnkCast.Enabled = false;
            this.lnkCast.Location = new System.Drawing.Point(32, 108);
            this.lnkCast.Name = "lnkCast";
            this.lnkCast.Size = new System.Drawing.Size(47, 13);
            this.lnkCast.TabIndex = 8;
            this.lnkCast.TabStop = true;
            this.lnkCast.Text = "Cast Pot";
            this.lnkCast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCast_LinkClicked);
            // 
            // lblCasted
            // 
            this.lblCasted.AutoSize = true;
            this.lblCasted.Enabled = false;
            this.lblCasted.Location = new System.Drawing.Point(335, 108);
            this.lblCasted.Name = "lblCasted";
            this.lblCasted.Size = new System.Drawing.Size(13, 13);
            this.lblCasted.TabIndex = 7;
            this.lblCasted.Text = "0";
            // 
            // lnkRefreshCasted
            // 
            this.lnkRefreshCasted.AutoSize = true;
            this.lnkRefreshCasted.Enabled = false;
            this.lnkRefreshCasted.Location = new System.Drawing.Point(262, 16);
            this.lnkRefreshCasted.Name = "lnkRefreshCasted";
            this.lnkRefreshCasted.Size = new System.Drawing.Size(111, 13);
            this.lnkRefreshCasted.TabIndex = 6;
            this.lnkRefreshCasted.TabStop = true;
            this.lnkRefreshCasted.Text = "Refresh Casted Count";
            this.lnkRefreshCasted.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefreshCasted_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(286, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Casted:";
            // 
            // chkUseBoosters
            // 
            this.chkUseBoosters.AutoSize = true;
            this.chkUseBoosters.Location = new System.Drawing.Point(7, 19);
            this.chkUseBoosters.Name = "chkUseBoosters";
            this.chkUseBoosters.Size = new System.Drawing.Size(113, 17);
            this.chkUseBoosters.TabIndex = 4;
            this.chkUseBoosters.Text = "Use EXP Boosters";
            this.chkUseBoosters.UseVisualStyleBackColor = true;
            this.chkUseBoosters.CheckedChanged += new System.EventHandler(this.chkUseBoosters_CheckedChanged);
            // 
            // rdMinorExp
            // 
            this.rdMinorExp.AutoSize = true;
            this.rdMinorExp.Enabled = false;
            this.rdMinorExp.Location = new System.Drawing.Point(7, 42);
            this.rdMinorExp.Name = "rdMinorExp";
            this.rdMinorExp.Size = new System.Drawing.Size(105, 17);
            this.rdMinorExp.TabIndex = 1;
            this.rdMinorExp.TabStop = true;
            this.rdMinorExp.Text = "Minor EXP Boost";
            this.rdMinorExp.UseVisualStyleBackColor = true;
            // 
            // rdMajorExp
            // 
            this.rdMajorExp.AutoSize = true;
            this.rdMajorExp.Enabled = false;
            this.rdMajorExp.Location = new System.Drawing.Point(7, 65);
            this.rdMajorExp.Name = "rdMajorExp";
            this.rdMajorExp.Size = new System.Drawing.Size(105, 17);
            this.rdMajorExp.TabIndex = 0;
            this.rdMajorExp.TabStop = true;
            this.rdMajorExp.Text = "Major EXP Boost";
            this.rdMajorExp.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.chkSecurity);
            this.tabPage3.Controls.Add(this.linkLabel8);
            this.tabPage3.Controls.Add(this.linkLabel7);
            this.tabPage3.Controls.Add(this.lvBackpack);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(403, 262);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Backpack";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkSecurity
            // 
            this.chkSecurity.AutoSize = true;
            this.chkSecurity.Location = new System.Drawing.Point(287, 245);
            this.chkSecurity.Name = "chkSecurity";
            this.chkSecurity.Size = new System.Drawing.Size(110, 17);
            this.chkSecurity.TabIndex = 6;
            this.chkSecurity.Text = "No Security Word";
            this.chkSecurity.UseVisualStyleBackColor = true;
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.Location = new System.Drawing.Point(6, 246);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(83, 13);
            this.linkLabel8.TabIndex = 5;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "Load Backpack";
            this.linkLabel8.Visible = false;
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel8_LinkClicked);
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(95, 246);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(75, 13);
            this.linkLabel7.TabIndex = 4;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "Drop Selected";
            this.linkLabel7.Visible = false;
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel7_LinkClicked);
            // 
            // lvBackpack
            // 
            this.lvBackpack.CheckBoxes = true;
            this.lvBackpack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvBackpack.GridLines = true;
            listViewGroup1.Header = "Main";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "Potion";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "Orbs";
            listViewGroup3.Name = "listViewGroup3";
            this.lvBackpack.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lvBackpack.Location = new System.Drawing.Point(6, 6);
            this.lvBackpack.Name = "lvBackpack";
            this.lvBackpack.Size = new System.Drawing.Size(391, 237);
            this.lvBackpack.TabIndex = 3;
            this.lvBackpack.UseCompatibleStateImageBehavior = false;
            this.lvBackpack.View = System.Windows.Forms.View.Details;
            this.lvBackpack.Visible = false;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Stats";
            this.columnHeader8.Width = 250;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ID";
            this.columnHeader9.Width = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Drop Augs";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TrainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TrainPanel";
            this.Size = new System.Drawing.Size(417, 294);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.LinkLabel lnkLingBuff;
        private System.Windows.Forms.CheckBox chkAutoTrain;
        private System.Windows.Forms.CheckBox chkTrainReturn;
        private System.Windows.Forms.Label lblTrain;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.ListView lvBackpack;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.CheckBox chkSecurity;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblFuryCasted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbFury;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkUseBoosters;
        private System.Windows.Forms.RadioButton rdMinorExp;
        private System.Windows.Forms.RadioButton rdMajorExp;
        private System.Windows.Forms.Label lblCasted;
        private System.Windows.Forms.LinkLabel lnkRefreshCasted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkCast;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;

    }
}
