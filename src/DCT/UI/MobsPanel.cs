using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using DCT.Pathfinding;
using DCT.Util;

namespace DCT.UI
{
    public partial class MobsPanel : UserControl
    {
        internal ListView.ListViewItemCollection Mobs
        {
            get { return lvMobs.Items; }
        }

        internal ListView.CheckedListViewItemCollection CheckedMobs
        {
            get { return lvMobs.CheckedItems; }
        }

        internal ListView.CheckedIndexCollection CheckedIndices
        {
            get { return lvMobs.CheckedIndices; }
        }

        internal ListViewItem FocusedMob
        {
            get { return lvMobs.FocusedItem; }
        }

        internal bool MobsEnabled
        {
            get { return btnMobGo.Enabled; }
            set { btnMobGo.Enabled = value; }
        }

        private readonly CoreUI mUI;

        internal MobsPanel(CoreUI ui)
        {
            mUI = ui;
            Action<object> action = (object obj) =>
            {
                InitializeComponent();
            };

            Task t1 = new Task(action, "alpha");
            t1.Start();
            t1.Wait();
        }

        internal void BuildView()
        {
            lvMobs.Items.Clear();
            foreach (MappedMob mb in Pathfinder.Mobs)
            {
                if (mb != null)
                {
                    ListViewItem tmp = new ListViewItem(
                            new[]
                                {
                                    mb.Name, mb.Id.ToString(), mb.Room.ToString(),
                                    mb.Level.ToString(), mb.Rage.ToString()
                                });
                    tmp.Name = mb.Name;
                    lvMobs.Items.Add(tmp);
                }
            }
        }

        internal void AddMobs(List<MappedMob> mm)
        {
            lvMobs.Items.Clear();
            foreach (MappedMob mb in mm)
            {
                if (mb != null)
                {
                    ListViewItem tmp = new ListViewItem(
                            new[]
                                {
                                    mb.Name, mb.Id.ToString(), mb.Room.ToString(),
                                    mb.Level.ToString(), mb.Rage.ToString()
                                });
                    tmp.Name = mb.Name;
                    lvMobs.Items.Add(tmp);
                }
            }
        }

        internal void ClearMobs()
        {
            lvMobs.Items.Clear();
        }

        private void btnMobRage_Click(object sender, EventArgs e)
        {
            CalcMobRage();
        }

        internal void CalcMobRage()
        {
            btnMobRage.Enabled = false;
            UpdateMobRage();
            btnMobRage.Enabled = true;
        }

        private void UpdateMobRage()
        {
            int r = 0;
            foreach (ListViewItem i in lvMobs.CheckedItems)
            {
                int t = int.Parse(i.SubItems[4].Text);
                if (t > 0)
                    r += t;
            }
            lblMobRage.Text = "Using rage: " + r;
        }

        private void lnkUncheckMobs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvMobs.CheckedItems)
            {
                item.Checked = false;
            }
        }

        private void lnkMobLoad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = FileIO.LoadFileToString("Import Mobs");
            if (s == null)
            {
                return;
            }
            int i = 0;
            foreach (string l in s.Split(new[] { ',', '\n', '\r', ';', '\t' }))
            {
                i += SelectMobsByName(l);
            }
            MessageBox.Show("Selected " + i + " mobs.", "Loaded Mobs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkMobSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> rs = new List<string>();
            foreach (ListViewItem m in lvMobs.CheckedItems)
            {
                if (!rs.Contains(m.Text))
                {
                    rs.Add(m.Text);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (string s in rs)
            {
                sb.Append(s).Append("\n");
            }
            FileIO.SaveFileFromString("Export Mobs List", "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                "DCT mobs.txt", sb.ToString());
        }

        private int SelectMobsByName(string name)
        {
            int i = 0;
            foreach (ListViewItem item in lvMobs.Items.Find(name, false))
            {
                item.Checked = true;
                i++;
            }
            return i;
        }

        private int UncheckMobsbyName(string name)
        {
            int i = 0;
            foreach (ListViewItem item in lvMobs.Items.Find(name, false))
            {
                item.Checked = false;
                i++;
            }
            return i;
        }

        private void lnkMobsSelect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            string input = InputBox.Prompt("Mob Selection", "Check all mobs with the following names (separated by commas):");
            if (string.IsNullOrEmpty(input))
                return;
            foreach (string s in input.Split(new[] { ',' }))
            {
                i += SelectMobsByName(s.Trim());
            }
            MessageBox.Show("Selected " + i + " mobs.", "Select Mobs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPotionMobsSelect_Click(object sender, EventArgs e)
        {
            List<string> check = new List<string>();
            switch (cmbPotionMobs.Text.ToLower())
            {
                case "kix potion":
                    check.Add("Kix Oak Tree");
                    check.Add("Kix Spider");
                    check.Add("Mountain Weeds");
                    break;
                case "kinetic potion":
                    check.Add("Deadly Ripscale");
                    check.Add("Poison Drake");
                    check.Add("Enraged Centaur");
                    check.Add("Earth Troll");
                    check.Add("Evil Sherpa");
                    break;
                case "fire potion":
                    check.Add("Haunter");
                    check.Add("Evil Ranger Grunt");
                    check.Add("Lost Demon");
                    break;
                case "holy potion":
                    check.Add("Fallen Angel");
                    check.Add("Apparitional Veteran");
                    check.Add("Evil Ranger Grunt");
                    break;
                case "shadow potion":
                    check.Add("Caustic Corpse");
                    check.Add("Infuriated Savage");
                    check.Add("Evil Ranger Grunt");
                    break;
                case "arcane potion":
                    check.Add("Spectral Warrior");
                    check.Add("Ancient Deserter");
                    check.Add("Evil Ranger Grunt");
                    break;
                default:
                    MessageBox.Show("Choose a preset option.", "Select Potion Mobs", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
            }
            int i = 0;
            foreach (string m in check)
            {
                i += SelectMobsByName(m);
            }
            MessageBox.Show("Selected " + i + " mobs.", "Loaded Mobs", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnMobGo_Click(object sender, EventArgs e)
        {
            if (lvMobs.SelectedItems.Count < 1)
            {
                mUI.LogPanel.Log("E: No mob selected.");
                return;
            }
            ListViewItem item = lvMobs.SelectedItems[0];
            if (lvMobs.SelectedItems.Count > 1)
            {
                mUI.LogPanel.Log(string.Format("Moving to {0} in room {1}", item.SubItems[0].Text, item.SubItems[2].Text));
            }
            mUI.InvokePathfind(int.Parse(item.SubItems[2].Text));
        }

        private void lvMobs_DoubleClick(object sender, EventArgs e)
        {
            if (lvMobs.SelectedItems.Count > 0)
            {
                string n = lvMobs.SelectedItems[0].Text;
                CoreUI.Instance.TalkPanel.AddToQuester(n);
            }
        }

        private void lvMobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMobs.SelectedItems.Count < 1)
            {
                btnMobGo.Text = "Go to selection";
                return;
            }
            string txt = lvMobs.SelectedItems[0].SubItems[0].Text;
            if (txt.StartsWith("A "))
                txt = txt.Substring(2);
            btnMobGo.Text = string.Format("Go to {0}", txt);
        }

        private void lnkUncheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            string input = InputBox.Prompt("Mob Selection", "Check all mobs with the following names (separated by commas):");
            if (string.IsNullOrEmpty(input))
                return;
            foreach (string s in input.Split(new[] { ',' }))
            {
                i += UncheckMobsbyName(s.Trim());
            }
            MessageBox.Show("Unchecked " + i + " mobs.", "Unchecked Mobs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
