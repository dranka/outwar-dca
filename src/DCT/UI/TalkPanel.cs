using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCT.Outwar;
using DCT.Outwar.World;
using DCT.Pathfinding;
using DCT.Util;
using System.Threading;

namespace DCT.UI
{
    public partial class TalkPanel : UserControl
    {

        internal bool TalkEnabled
        {
            get { return btnRefresh.Enabled && btnTalk.Enabled; }
            set { btnRefresh.Enabled = btnTalk.Enabled = value; }
        }

        internal ListView.ListViewItemCollection QuestMobs
        {
            get { return lvMobs.Items; }
        }

        internal Mover Mover { get; private set; }

        private readonly CoreUI mUI;

        internal TalkPanel(CoreUI ui)
        {
            mUI = ui;
            InitializeComponent();
        }

        internal delegate void AddQuestMobs(string MobName, string MobID, string Room);
        internal void AddMob(string MobName, string MobID, string Room)
        {
            if (InvokeRequired)
            {
                Invoke(new AddQuestMobs(AddMob),MobName, MobID, Room);
                return;
            }
            else
            {
                ListViewItem item1 = lvMobs.FindItemWithText(MobName);
                if (item1 == null)
                    lvMobs.Items.Add(new ListViewItem(new string[] { MobName, MobID, Room }));
                if (MobName == "ERROR")
                {

                }
                else
                {
                    Pathfinding.QuestMobs.Add(MobName, MobID, Room);
                }

            }
        }

        internal void BuildView()
        {
            lvMobs.Items.Clear();
            //SortedList<string, int> l = Pathfinder.Adventures;
            //for (int i = 0; i < l.Count; i++)
            //{
            //    ListViewItem tmp = new ListViewItem(
            //            new string[]
            //                {
            //                    l.Keys[i], l.Values[i].ToString()
            //                });

            //    tmp.Name = l.Keys[i];
            //    lvAdventures.Items.Add(tmp);
            //}
        }

        internal delegate void LoadQuestMob(string MobName, string MobID, string Room);
        internal void LoadQuestMobs(string MobName, string MobID, string Room)
        {
            if (InvokeRequired)
            {
                Invoke(new LoadQuestMob(LoadQuestMobs), MobName, MobID, Room);
                return;
            }
            else
            {
                ListViewItem item1 = lvMobs.FindItemWithText(MobName);
                if (item1 == null)
                    lvMobs.Items.Add(new ListViewItem(new string[] { MobName, MobID, Room }));
                //Pathfinding.QuestMobs.Add(MobName, "n/a", Room);
            }
        }

        internal delegate void AddItems(string ItemName, string MobName);
        internal void AddItem(string ItemName, string MobName)
        {
            if (InvokeRequired)
            {
                    Invoke(new AddItems(AddItem), ItemName, MobName);
                    return;
            }
            else
            {
                ListViewItem item1 = lvDrops.FindItemWithText(ItemName);
                if (item1 == null)
                {
                    item1 = lvDrops.Items.Add(new ListViewItem(new string[] { ItemName, MobName, "1" }));
                }
                else
                {
                    int a = Convert.ToInt32(item1.SubItems[2].Text);
                    a = a + 1;
                    item1.SubItems[2].Text = a.ToString();
                }
            }
        }

        public void QuestTalk()
        {

        }

        private void btnTalk_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Coming soon.", "Coming soon", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (mUI.AccountsPanel.CheckedIndices.Count < 1)
            {
                mUI.LogPanel.Log("E: Check the accounts you want to move.");
                return;
            }
            if (lvMobs.FocusedItem == null)
            {
                mUI.LogPanel.Log("E: Choose an quest mob to move to.");
                return;
            }
            mUI.InvokeBulkMove(int.Parse(lvMobs.FocusedItem.SubItems[2].Text));
        }

        private void lvMobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMobs.SelectedItems.Count < 1)
            {
                btnTalk.Text = "Go to selection";
                return;
            }
            string txt = lvMobs.SelectedItems[0].SubItems[0].Text;
            if (txt.StartsWith("A "))
                txt = txt.Substring(2);
            btnTalk.Text = string.Format("Talk to {0}", txt);
            btnRefresh.Text = string.Format("Move to {0}", txt);
        }



        private void lnkQuests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // http://sigil.outwar.com/backpack.php?quest=1
        }

        private void lnkOrbs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // http://sigil.outwar.com/backpack.php?orb=1
        }

        private void lnkPotions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // http://sigil.outwar.com/backpack.php?potion=1
        }

        private void lnkKeys_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // http://sigil.outwar.com/backpack.php?key=1
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lvMobs.Items.Clear();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lvDrops.Items.Clear();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> rs = new List<string>();
            foreach (ListViewItem m in lvMobs.Items)
            {
                if (!rs.Contains(m.Text))
                {
                    rs.Add(m.Text + "," + m.SubItems[1].Text + "," + m.SubItems[2].Text + ";");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (string s in rs)
            {
                sb.Append(s).Append("\n");
            }
            FileIO.SaveFileFromString("Export Mobs List", "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                "DCT quest mobs.txt", sb.ToString());
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = FileIO.LoadFileToString("Import Mobs");
            if (s == null)
            {
                return;
            }
            foreach (string l in s.Split(new[] { ';', '\n', '\r', '\t' }))
            {
                string[] Items = l.Split(',');
                if (Items.Length == 3)
                lvMobs.Items.Add(new ListViewItem(new string[] { Items[0], Items[1], Items[2] }));

            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> rs = new List<string>();
            foreach (ListViewItem m in lvDrops.Items)
            {
                if (!rs.Contains(m.Text))
                {
                    rs.Add(m.SubItems[1].Text + " dropped " + m.Text + "\r\n");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (string s in rs)
            {
                sb.Append(s).Append("\n");
            }
            FileIO.SaveFileFromString("Export Mobs List", "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                "DCT Drops.txt", sb.ToString());
        }

        private int mSortColumn;
        private void lvMobs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != mSortColumn)
            {
                mSortColumn = e.Column;
                lvMobs.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvMobs.Sorting == SortOrder.Ascending)
                    lvMobs.Sorting = SortOrder.Descending;
                else
                    lvMobs.Sorting = SortOrder.Ascending;
            }


            lvMobs.ListViewItemSorter = new MobViewItemComparer(e.Column,
                                                                lvMobs.Sorting);

            lvMobs.Sort();
        }

        private int SortColumn;
        private void lvDrops_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != SortColumn)
            {
                SortColumn = e.Column;
                lvDrops.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvDrops.Sorting == SortOrder.Ascending)
                    lvDrops.Sorting = SortOrder.Descending;
                else
                    lvDrops.Sorting = SortOrder.Ascending;
            }


            lvDrops.ListViewItemSorter = new MobViewItemComparer(e.Column,
                                                                lvDrops.Sorting);

            lvDrops.Sort();
        }

        private void StartEobGlitch(object t)
        {
            int i = Convert.ToInt32(t);
            CoreUI.Instance.AccountsPanel.Engine[i].Mover.RefreshRoom();

            if (CoreUI.Instance.AccountsPanel.Engine[i].Mover.Location.Id == 4867)
            {
                CoreUI.Instance.AccountsPanel.Engine[i].Mover.Socket.Get("mob_talk.php?id=15931&stepid=1514&finish=1&userspawn=");
                Threading.ThreadEngine.Sleep(100);
                CoreUI.Instance.AccountsPanel.Engine[i].Mover.Socket.Get("mob_talk.php?id=15931&stepid=2168&finish=1&userspawn=");
                CoreUI.Instance.LogPanel.Log(CoreUI.Instance.AccountsPanel.Engine[i].Name + " received a Radiation Prototype!");
            }
            else
            {
                CoreUI.Instance.LogPanel.Log(CoreUI.Instance.AccountsPanel.Engine[i].Name + " is not at rindo tan.");
            }
        }

        private void lnkEobGlitch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (int index in CoreUI.Instance.AccountsPanel.CheckedIndices)
            {
                string i = index.ToString();
                ThreadPool.QueueUserWorkItem(StartEobGlitch, i);
                Threading.ThreadEngine.Sleep(50);
            }
        }
    }
}
