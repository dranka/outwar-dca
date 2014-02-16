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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 269);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
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
            this.lnkLingBuff.Enabled = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "** I am working on fixing ling buff. Will be back in a future update";
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
        private System.Windows.Forms.Label label1;

    }
}
