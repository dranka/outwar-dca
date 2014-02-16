namespace DCT.UI
{
    partial class RaidsPanel
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
            this.btnAdventuresGo = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmRoomID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvAdventures = new System.Windows.Forms.ListView();
            this.btnStopMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdventuresGo
            // 
            this.btnAdventuresGo.Location = new System.Drawing.Point(232, 2);
            this.btnAdventuresGo.Name = "btnAdventuresGo";
            this.btnAdventuresGo.Size = new System.Drawing.Size(31, 23);
            this.btnAdventuresGo.TabIndex = 11;
            this.btnAdventuresGo.Text = "Go";
            this.btnAdventuresGo.UseVisualStyleBackColor = true;
            this.btnAdventuresGo.Click += new System.EventHandler(this.btnAdventuresGo_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(223, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Move all checked accounts to selected room:";
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 200;
            // 
            // clmRoomID
            // 
            this.clmRoomID.Text = "Room ID";
            this.clmRoomID.Width = 100;
            // 
            // lvAdventures
            // 
            this.lvAdventures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmRoomID});
            this.lvAdventures.FullRowSelect = true;
            this.lvAdventures.GridLines = true;
            this.lvAdventures.Location = new System.Drawing.Point(3, 25);
            this.lvAdventures.MultiSelect = false;
            this.lvAdventures.Name = "lvAdventures";
            this.lvAdventures.Size = new System.Drawing.Size(420, 254);
            this.lvAdventures.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAdventures.TabIndex = 10;
            this.lvAdventures.UseCompatibleStateImageBehavior = false;
            this.lvAdventures.View = System.Windows.Forms.View.Details;
            // 
            // btnStopMove
            // 
            this.btnStopMove.Enabled = false;
            this.btnStopMove.Location = new System.Drawing.Point(269, 2);
            this.btnStopMove.Name = "btnStopMove";
            this.btnStopMove.Size = new System.Drawing.Size(38, 23);
            this.btnStopMove.TabIndex = 12;
            this.btnStopMove.Text = "Stop";
            this.btnStopMove.UseVisualStyleBackColor = true;
            this.btnStopMove.Visible = false;
            this.btnStopMove.Click += new System.EventHandler(this.btnStopMove_Click);
            // 
            // RaidsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStopMove);
            this.Controls.Add(this.btnAdventuresGo);
            this.Controls.Add(this.lvAdventures);
            this.Controls.Add(this.label16);
            this.Name = "RaidsPanel";
            this.Size = new System.Drawing.Size(436, 290);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdventuresGo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmRoomID;
        private System.Windows.Forms.ListView lvAdventures;
        private System.Windows.Forms.Button btnStopMove;
    }
}
