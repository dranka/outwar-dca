﻿namespace DCT.UI.Questing
{
    partial class frmMobTalk
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
            this.SuspendLayout();
            // 
            // talkpanel
            // 
            this.talkpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.talkpanel.Location = new System.Drawing.Point(0, 0);
            this.talkpanel.Name = "talkpanel";
            this.talkpanel.Size = new System.Drawing.Size(513, 338);
            this.talkpanel.TabIndex = 0;
            this.talkpanel.Load += new System.EventHandler(this.talkpanel_Load);
            // 
            // frmMobTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 338);
            this.Controls.Add(this.talkpanel);
            this.Name = "frmMobTalk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mob Talk";
            this.ResumeLayout(false);

        }

        #endregion

        private MobTalkControl talkpanel;
    }
}