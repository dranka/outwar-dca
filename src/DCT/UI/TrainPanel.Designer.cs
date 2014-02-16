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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lnkLingBuff = new System.Windows.Forms.LinkLabel();
            this.chkAutoTrain = new System.Windows.Forms.CheckBox();
            this.chkTrainReturn = new System.Windows.Forms.CheckBox();
            this.lblTrain = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFuryCasted = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFury = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 269);
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
            this.tabPage1.Size = new System.Drawing.Size(465, 243);
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
            this.tabPage2.Size = new System.Drawing.Size(465, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Potions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFuryCasted);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbFury);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 231);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Potions";
            // 
            // lblFuryCasted
            // 
            this.lblFuryCasted.AutoSize = true;
            this.lblFuryCasted.Location = new System.Drawing.Point(107, 20);
            this.lblFuryCasted.Name = "lblFuryCasted";
            this.lblFuryCasted.Size = new System.Drawing.Size(13, 13);
            this.lblFuryCasted.TabIndex = 45;
            this.lblFuryCasted.Text = "0";
            this.lblFuryCasted.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Casted:";
            this.label1.Visible = false;
            // 
            // cbFury
            // 
            this.cbFury.AutoSize = true;
            this.cbFury.Location = new System.Drawing.Point(6, 19);
            this.cbFury.Name = "cbFury";
            this.cbFury.Size = new System.Drawing.Size(46, 17);
            this.cbFury.TabIndex = 41;
            this.cbFury.Text = "Fury";
            this.cbFury.UseVisualStyleBackColor = true;
            this.cbFury.CheckedChanged += new System.EventHandler(this.cbFury_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(4, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(102, 17);
            this.checkBox2.TabIndex = 42;
            this.checkBox2.Text = "Minor exp Boost";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(4, 42);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(102, 17);
            this.checkBox3.TabIndex = 43;
            this.checkBox3.Text = "Major exp Boost";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // TrainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TrainPanel";
            this.Size = new System.Drawing.Size(479, 275);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label lblFuryCasted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbFury;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;

    }
}
