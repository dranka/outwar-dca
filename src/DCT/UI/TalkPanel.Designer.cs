namespace DCT.UI
{
    partial class TalkPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkKeys = new System.Windows.Forms.LinkLabel();
            this.lnkPotions = new System.Windows.Forms.LinkLabel();
            this.lnkOrbs = new System.Windows.Forms.LinkLabel();
            this.lnkQuests = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lvDrops = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.btnTalk = new System.Windows.Forms.Button();
            this.lvMobs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgQuest = new System.Windows.Forms.DataGridView();
            this.Mob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Done = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Needed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finished = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuest)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkKeys);
            this.groupBox1.Controls.Add(this.lnkPotions);
            this.groupBox1.Controls.Add(this.lnkOrbs);
            this.groupBox1.Controls.Add(this.lnkQuests);
            this.groupBox1.Location = new System.Drawing.Point(192, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(66, 59);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backpack";
            this.groupBox1.Visible = false;
            // 
            // lnkKeys
            // 
            this.lnkKeys.AutoSize = true;
            this.lnkKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkKeys.Location = new System.Drawing.Point(264, 25);
            this.lnkKeys.Name = "lnkKeys";
            this.lnkKeys.Size = new System.Drawing.Size(38, 16);
            this.lnkKeys.TabIndex = 3;
            this.lnkKeys.TabStop = true;
            this.lnkKeys.Text = "Keys";
            this.lnkKeys.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkKeys_LinkClicked);
            // 
            // lnkPotions
            // 
            this.lnkPotions.AutoSize = true;
            this.lnkPotions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPotions.Location = new System.Drawing.Point(205, 25);
            this.lnkPotions.Name = "lnkPotions";
            this.lnkPotions.Size = new System.Drawing.Size(53, 16);
            this.lnkPotions.TabIndex = 2;
            this.lnkPotions.TabStop = true;
            this.lnkPotions.Text = "Potions";
            this.lnkPotions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPotions_LinkClicked);
            // 
            // lnkOrbs
            // 
            this.lnkOrbs.AutoSize = true;
            this.lnkOrbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOrbs.Location = new System.Drawing.Point(162, 25);
            this.lnkOrbs.Name = "lnkOrbs";
            this.lnkOrbs.Size = new System.Drawing.Size(37, 16);
            this.lnkOrbs.TabIndex = 1;
            this.lnkOrbs.TabStop = true;
            this.lnkOrbs.Text = "Orbs";
            this.lnkOrbs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOrbs_LinkClicked);
            // 
            // lnkQuests
            // 
            this.lnkQuests.AutoSize = true;
            this.lnkQuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkQuests.Location = new System.Drawing.Point(106, 25);
            this.lnkQuests.Name = "lnkQuests";
            this.lnkQuests.Size = new System.Drawing.Size(50, 16);
            this.lnkQuests.TabIndex = 0;
            this.lnkQuests.TabStop = true;
            this.lnkQuests.Text = "Quests";
            this.lnkQuests.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkQuests_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.linkLabel6);
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lvDrops);
            this.tabPage2.Controls.Add(this.linkLabel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(409, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Item Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "|";
            this.label4.Visible = false;
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(173, 246);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(68, 13);
            this.linkLabel6.TabIndex = 12;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "Export Drops";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel6_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Location = new System.Drawing.Point(262, 246);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(74, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quest Options";
            this.linkLabel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "|";
            // 
            // lvDrops
            // 
            this.lvDrops.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvDrops.FullRowSelect = true;
            this.lvDrops.GridLines = true;
            this.lvDrops.Location = new System.Drawing.Point(6, 6);
            this.lvDrops.MultiSelect = false;
            this.lvDrops.Name = "lvDrops";
            this.lvDrops.Size = new System.Drawing.Size(391, 237);
            this.lvDrops.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDrops.TabIndex = 7;
            this.lvDrops.UseCompatibleStateImageBehavior = false;
            this.lvDrops.View = System.Windows.Forms.View.Details;
            this.lvDrops.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDrops_ColumnClick);
            this.lvDrops.DoubleClick += new System.EventHandler(this.lvDrops_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Item Name";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mob";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Drops";
            this.columnHeader6.Width = 80;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(67, 246);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(85, 13);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Clear Item Drops";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.linkLabel5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.linkLabel4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.linkLabel3);
            this.tabPage1.Controls.Add(this.btnTalk);
            this.tabPage1.Controls.Add(this.lvMobs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(409, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mobs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(277, 248);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Display quest dialog";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(118, 246);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(65, 13);
            this.linkLabel5.TabIndex = 14;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Import Mobs";
            this.linkLabel5.Visible = false;
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "|";
            this.label3.Visible = false;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(204, 246);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(66, 13);
            this.linkLabel4.TabIndex = 12;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Export Mobs";
            this.linkLabel4.Visible = false;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "|";
            this.label2.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(43, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(155, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Move to...";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(6, 246);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(91, 13);
            this.linkLabel3.TabIndex = 10;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Clear Quest Mobs";
            this.linkLabel3.Visible = false;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // btnTalk
            // 
            this.btnTalk.AutoEllipsis = true;
            this.btnTalk.Location = new System.Drawing.Point(204, 6);
            this.btnTalk.Name = "btnTalk";
            this.btnTalk.Size = new System.Drawing.Size(155, 23);
            this.btnTalk.TabIndex = 2;
            this.btnTalk.Text = "Talk to...";
            this.btnTalk.UseVisualStyleBackColor = true;
            this.btnTalk.Click += new System.EventHandler(this.btnTalk_Click);
            // 
            // lvMobs
            // 
            this.lvMobs.AccessibleName = "lvMobs";
            this.lvMobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvMobs.FullRowSelect = true;
            this.lvMobs.GridLines = true;
            this.lvMobs.Location = new System.Drawing.Point(6, 35);
            this.lvMobs.MultiSelect = false;
            this.lvMobs.Name = "lvMobs";
            this.lvMobs.Size = new System.Drawing.Size(391, 208);
            this.lvMobs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvMobs.TabIndex = 0;
            this.lvMobs.UseCompatibleStateImageBehavior = false;
            this.lvMobs.View = System.Windows.Forms.View.Details;
            this.lvMobs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvMobs_ColumnClick);
            this.lvMobs.SelectedIndexChanged += new System.EventHandler(this.lvMobs_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Id";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Room";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 294);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgQuest);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(409, 268);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Questing";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgQuest
            // 
            this.dgQuest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgQuest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mob,
            this.Done,
            this.Needed,
            this.Finished});
            this.dgQuest.Location = new System.Drawing.Point(6, 6);
            this.dgQuest.Name = "dgQuest";
            this.dgQuest.Size = new System.Drawing.Size(397, 256);
            this.dgQuest.TabIndex = 0;
            // 
            // Mob
            // 
            this.Mob.HeaderText = "Mob/Item";
            this.Mob.Name = "Mob";
            this.Mob.Width = 150;
            // 
            // Done
            // 
            this.Done.HeaderText = "Done";
            this.Done.Name = "Done";
            this.Done.ReadOnly = true;
            this.Done.Width = 50;
            // 
            // Needed
            // 
            this.Needed.HeaderText = "Needed";
            this.Needed.Name = "Needed";
            this.Needed.Width = 50;
            // 
            // Finished
            // 
            this.Finished.HeaderText = "";
            this.Finished.Name = "Finished";
            this.Finished.ReadOnly = true;
            this.Finished.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Finished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Finished.Width = 50;
            // 
            // TalkPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "TalkPanel";
            this.Size = new System.Drawing.Size(417, 294);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkKeys;
        private System.Windows.Forms.LinkLabel lnkPotions;
        private System.Windows.Forms.LinkLabel lnkOrbs;
        private System.Windows.Forms.LinkLabel lnkQuests;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvDrops;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Button btnTalk;
        private System.Windows.Forms.ListView lvMobs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgQuest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mob;
        private System.Windows.Forms.DataGridViewTextBoxColumn Done;
        private System.Windows.Forms.DataGridViewTextBoxColumn Needed;
        private System.Windows.Forms.DataGridViewImageColumn Finished;
    }
}
