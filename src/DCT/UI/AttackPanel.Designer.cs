namespace DCT.UI
{
    partial class AttackPanel
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
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.chkMultiThread = new System.Windows.Forms.CheckBox();
            this.chkQuestKills = new System.Windows.Forms.CheckBox();
            this.pnlMainPanel = new System.Windows.Forms.Panel();
            this.chkReturnToStart = new System.Windows.Forms.CheckBox();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numRageLimit = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numLevelMin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numRageStop = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numLevel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkAutoTeleport = new System.Windows.Forms.CheckBox();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRageLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevelMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRageStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.chkMultiThread);
            this.grpSettings.Controls.Add(this.chkQuestKills);
            this.grpSettings.Controls.Add(this.pnlMainPanel);
            this.grpSettings.Controls.Add(this.chkReturnToStart);
            this.grpSettings.Controls.Add(this.numTimeout);
            this.grpSettings.Controls.Add(this.label5);
            this.grpSettings.Controls.Add(this.numRageLimit);
            this.grpSettings.Controls.Add(this.label13);
            this.grpSettings.Controls.Add(this.numLevelMin);
            this.grpSettings.Controls.Add(this.label12);
            this.grpSettings.Controls.Add(this.numRageStop);
            this.grpSettings.Controls.Add(this.label11);
            this.grpSettings.Controls.Add(this.numLevel);
            this.grpSettings.Controls.Add(this.label4);
            this.grpSettings.Controls.Add(this.label14);
            this.grpSettings.Controls.Add(this.chkAutoTeleport);
            this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSettings.Location = new System.Drawing.Point(0, 0);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(414, 255);
            this.grpSettings.TabIndex = 6;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // chkMultiThread
            // 
            this.chkMultiThread.AutoSize = true;
            this.chkMultiThread.Location = new System.Drawing.Point(3, 200);
            this.chkMultiThread.Name = "chkMultiThread";
            this.chkMultiThread.Size = new System.Drawing.Size(121, 17);
            this.chkMultiThread.TabIndex = 40;
            this.chkMultiThread.Text = "MultiThread Attacks";
            this.chkMultiThread.UseVisualStyleBackColor = true;
            this.chkMultiThread.CheckedChanged += new System.EventHandler(this.chkMultiThread_CheckedChanged);
            // 
            // chkQuestKills
            // 
            this.chkQuestKills.AutoSize = true;
            this.chkQuestKills.Location = new System.Drawing.Point(3, 177);
            this.chkQuestKills.Name = "chkQuestKills";
            this.chkQuestKills.Size = new System.Drawing.Size(165, 17);
            this.chkQuestKills.TabIndex = 7;
            this.chkQuestKills.Text = "Stop when done re quest kills";
            this.chkQuestKills.UseVisualStyleBackColor = true;
            this.chkQuestKills.CheckedChanged += new System.EventHandler(this.chkQuestKills_CheckedChanged);
            // 
            // pnlMainPanel
            // 
            this.pnlMainPanel.Location = new System.Drawing.Point(192, 10);
            this.pnlMainPanel.Name = "pnlMainPanel";
            this.pnlMainPanel.Size = new System.Drawing.Size(216, 130);
            this.pnlMainPanel.TabIndex = 38;
            // 
            // chkReturnToStart
            // 
            this.chkReturnToStart.AutoSize = true;
            this.chkReturnToStart.Checked = true;
            this.chkReturnToStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReturnToStart.Location = new System.Drawing.Point(3, 154);
            this.chkReturnToStart.Name = "chkReturnToStart";
            this.chkReturnToStart.Size = new System.Drawing.Size(133, 17);
            this.chkReturnToStart.TabIndex = 37;
            this.chkReturnToStart.Text = "Return to starting room";
            this.chkReturnToStart.UseVisualStyleBackColor = true;
            this.chkReturnToStart.CheckedChanged += new System.EventHandler(this.chkReturnToStart_CheckedChanged_1);
            // 
            // numTimeout
            // 
            this.numTimeout.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTimeout.Location = new System.Drawing.Point(298, 146);
            this.numTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTimeout.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(69, 20);
            this.numTimeout.TabIndex = 7;
            this.numTimeout.ThousandsSeparator = true;
            this.numTimeout.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.numTimeout.ValueChanged += new System.EventHandler(this.numTimeout_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Request timeout:";
            // 
            // numRageLimit
            // 
            this.numRageLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRageLimit.Location = new System.Drawing.Point(62, 64);
            this.numRageLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRageLimit.Name = "numRageLimit";
            this.numRageLimit.Size = new System.Drawing.Size(50, 18);
            this.numRageLimit.TabIndex = 2;
            this.numRageLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numRageLimit.ValueChanged += new System.EventHandler(this.numRageLimit_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Use up to";
            // 
            // numLevelMin
            // 
            this.numLevelMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLevelMin.Location = new System.Drawing.Point(23, 38);
            this.numLevelMin.Name = "numLevelMin";
            this.numLevelMin.Size = new System.Drawing.Size(37, 18);
            this.numLevelMin.TabIndex = 0;
            this.numLevelMin.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numLevelMin.ValueChanged += new System.EventHandler(this.numLevelMin_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "and";
            // 
            // numRageStop
            // 
            this.numRageStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRageStop.Location = new System.Drawing.Point(91, 94);
            this.numRageStop.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numRageStop.Name = "numRageStop";
            this.numRageStop.Size = new System.Drawing.Size(58, 18);
            this.numRageStop.TabIndex = 3;
            this.numRageStop.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRageStop.ValueChanged += new System.EventHandler(this.numRageStop_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Stop below rage:";
            // 
            // numLevel
            // 
            this.numLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLevel.Location = new System.Drawing.Point(95, 38);
            this.numLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(37, 18);
            this.numLevel.TabIndex = 1;
            this.numLevel.Value = new decimal(new int[] {
            62,
            0,
            0,
            0});
            this.numLevel.ValueChanged += new System.EventHandler(this.numLevel_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Attack between levels:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(113, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "rage per attack";
            // 
            // chkAutoTeleport
            // 
            this.chkAutoTeleport.AutoSize = true;
            this.chkAutoTeleport.Checked = true;
            this.chkAutoTeleport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoTeleport.Location = new System.Drawing.Point(3, 118);
            this.chkAutoTeleport.Name = "chkAutoTeleport";
            this.chkAutoTeleport.Size = new System.Drawing.Size(172, 30);
            this.chkAutoTeleport.TabIndex = 5;
            this.chkAutoTeleport.Text = "Automatically teleport if lost\r\n(do not check if in Stoneraven)";
            this.chkAutoTeleport.UseVisualStyleBackColor = true;
            this.chkAutoTeleport.CheckedChanged += new System.EventHandler(this.chkAutoTeleport_CheckedChanged);
            // 
            // AttackPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSettings);
            this.Name = "AttackPanel";
            this.Size = new System.Drawing.Size(414, 255);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRageLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevelMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRageStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numRageLimit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numLevelMin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numRageStop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkAutoTeleport;
        private System.Windows.Forms.CheckBox chkReturnToStart;
        private System.Windows.Forms.Panel pnlMainPanel;
        private System.Windows.Forms.CheckBox chkQuestKills;
        private System.Windows.Forms.CheckBox chkMultiThread;

    }
}
