using System;
using System.Windows.Forms;
using System.Threading;
using DCT.Outwar;
using DCT.Pathfinding;
using DCT.Protocols.Http;
using DCT.Util;
using DCT.Parsing;

namespace DCT.UI
{
    internal partial class TrainPanel : UserControl
    {
        public int FuryCount = 0;
        public int ExpCasted = 0;
        public int minutes; //countdown time
        public DateTime start; // Use UtcNow instead of Now
        public DateTime endtime;
        private AccountsEngine mEngine = new AccountsEngine();
        private static DCT.Threading.ThreadEngine w = new DCT.Threading.ThreadEngine(5, 100);

        private readonly CoreUI mUI;

        internal bool TrainEnabled
        {
            get { return btnTrain.Enabled; }
            set
            {
                btnTrain.Enabled = value;
                chkTrainReturn.Enabled = value;
            }
        }
        internal delegate void IncreaseCounter();
        public void IncreaseFuryCounter()
        {
            if (InvokeRequired)
            {
                Invoke(new IncreaseCounter(IncreaseFuryCounter));
                return;
            }
            else
            {
                FuryCount++;
                lblFuryCasted.Text = FuryCount.ToString();
            }
        }

        internal bool AutoTrain
        {
            get { return chkAutoTrain.Checked; }
            set { chkAutoTrain.Checked = value; }
        }

        internal bool UseFury
        {
            get { return (bool)cbFury.Checked; }
            set { cbFury.Checked = value; }
        }

        internal TrainPanel(CoreUI ui)
        {
            mUI = ui;
            InitializeComponent();
        }

        private void chkAutoTrain_CheckedChanged(object sender, EventArgs e)
        {
            CoreUI.Instance.Settings.AutoTrain = chkAutoTrain.Checked;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            mUI.InvokeTraining(chkTrainReturn.Checked);
        }

        private void lnkLingBuff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            w.Do(BeginCast);
        }

        private void BeginCast()
        {
            CoreUI.Instance.LogPanel.Log("Casting ling buff on selected accounts...");
            foreach (int index in CoreUI.Instance.AccountsPanel.CheckedIndices)
            {
                string i = index.ToString();
                ThreadPool.QueueUserWorkItem(CastLingBuff, i);
                Threading.ThreadEngine.Sleep(100);
            }
            CoreUI.Instance.LogPanel.Log("Done casting ling buff.");
        }

        private void CastLingBuff(object t)
        {
            int x = int.Parse(t.ToString());
            string scr = CoreUI.Instance.AccountsPanel.Engine[x].Mover.Socket.Get("underlings.php?claim=1&rg_sess_id=" + CoreUI.Instance.AccountsPanel.Engine.RgSessId);
            Thread.Sleep(1);
        }

        private void btnTrain_Click_1(object sender, EventArgs e)
        {
            mUI.InvokeTraining(chkTrainReturn.Checked);
        }

        private void lnkLingBuff_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;
            w.Do(BeginCast);

        }

        private void chkAutoTrain_CheckedChanged_1(object sender, EventArgs e)
        {
            CoreUI.Instance.Settings.AutoTrain = chkAutoTrain.Checked;
        }

        private void cbFury_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFury.Checked == true)
            {
                lblFuryCasted.Text = "0";
                label1.Visible = true;
                lblFuryCasted.Visible = true;
                FuryCount = 0;
            }
            else
            {
                label1.Visible = false;
                lblFuryCasted.Visible = false;
                FuryCount = 0;
            }
            mUI.Settings.UseFury = UseFury;
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvBackpack.Items.Count > 0)
            {
                lvBackpack.Items.Clear();
            }

            CoreUI.Instance.AccountsPanel.Engine.SetMain(CoreUI.Instance.AccountsPanel.CheckedIndices[0]);
            CoreUI.Instance.LogPanel.Log("Loading backpack for " + CoreUI.Instance.AccountsPanel.Engine.MainAccount.Name);
            Thread t = new Thread(LoadBP);
            t.Start();
            t.IsBackground = true;

            Thread t1 = new Thread(LoadPotions);
            t1.Start();
            t1.IsBackground = true;

            Thread t2 = new Thread(LoadOrbs);
            t2.Start();
            t2.IsBackground = true;
        }

        private void LoadBP(object t)
        {

            int i = Convert.ToInt32(t);
            string strHtml;
            strHtml = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("backpack.php");
            Parser BP = new Parser(strHtml);
            CheckForIllegalCrossThreadCalls = false;
            foreach (string x in BP.MultiParse("itempopup(event,'", "')"))
            {
                if (x == "ERROR")
                {

                }
                else
                {
                    string ItemHtml = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("itemlink.php?id=" + x);

                    Parser p = new Parser(ItemHtml);
                    string ItemName = p.Parse("align=\"left\">", "</td></tr>");
                    //ListViewItem L = lvBackpack.Items.Add(ItemName);
                    string ItemStats = p.Parse("Slot - ", "<td align=");
                    ItemStats = System.Text.RegularExpressions.Regex.Replace(ItemStats, "<[^>]*>", "");
                    Parser a = new Parser(ItemStats);
                    ItemStats = a.Parse("]", "	");
                    ListViewItem lvi = new ListViewItem(ItemName);
                    lvi.SubItems.Add(ItemStats);
                    lvi.SubItems.Add(x);
                    lvi.Group = lvBackpack.Groups[0];
                    lvBackpack.Items.Add(lvi);
                }
            }
        }

        private void LoadPotions(object t)
        {
            int i = Convert.ToInt32(t);
            string strHtml1 = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("backpack.php?potion=1");
            Parser BP1 = new Parser(strHtml1);
            CheckForIllegalCrossThreadCalls = false;
            foreach (string b in BP1.MultiParse("itempopup(event,'", "')"))
            {
                if (b == "ERROR")
                {

                }
                else
                {
                    string ItemHtml1 = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("itemlink.php?id=" + b);

                    Parser p1 = new Parser(ItemHtml1);
                    string ItemName1 = p1.Parse("align=\"left\">", "</td></tr>");
                    //ListViewItem L1 = lvBackpack.Items.Add(ItemName1);
                    string ItemStats1 = p1.Parse("normal;\">", "</div>");
                    ListViewItem lvi = new ListViewItem(ItemName1);
                    lvi.SubItems.Add(ItemStats1);
                    lvi.SubItems.Add(b);
                    lvi.Group = lvBackpack.Groups[1];
                    lvBackpack.Items.Add(lvi);
                }
            }
        }

        private void LoadOrbs(object t)
        {
            int i = Convert.ToInt32(t);
            string strHtml2 = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("backpack.php?orb=1");
            Parser BP2 = new Parser(strHtml2);
            CheckForIllegalCrossThreadCalls = false;
            foreach (string c in BP2.MultiParse("itempopup(event,'", "')"))
            {
                if (c == "ERROR")
                {

                }
                else
                {
                    string ItemHtml2 = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("itemlink.php?id=" + c);

                    Parser p2 = new Parser(ItemHtml2);
                    string ItemName2 = p2.Parse("align=\"left\">", "</td></tr>");
                    //ListViewItem L2 = lvBackpack.Items.Add(ItemName2);
                    string itemstats2 = p2.Parse("Slot - ", "<td align=");
                    itemstats2 = System.Text.RegularExpressions.Regex.Replace(itemstats2, @"<[^>]+>|&nbsp;", "");
                    Parser a = new Parser(itemstats2);
                    itemstats2 = a.Parse("]", "	");
                    
                    ListViewItem lvi = new ListViewItem(ItemName2);
                    lvi.SubItems.Add(itemstats2);
                    lvi.SubItems.Add(c);
                    lvi.Group = lvBackpack.Groups[2];
                    lvBackpack.Items.Add(lvi);
                }
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread d = new Thread(DropItems);
            d.IsBackground = true;
            d.Start();
        }

        private void DropItems(object t)
        {
            int i = Convert.ToInt32(t);
            string PostData = "dropitem%5B%5D=";
            ListViewItem lvi;
            for (int x = 0; x < lvBackpack.CheckedItems.Count; x++)
            {
                if (PostData == "dropitem%5B%5D=")
                {
                    lvi = lvBackpack.CheckedItems[x];
                    PostData = "dropitem%5B%5D=" + lvi.SubItems[2].Text;
                }
                else
                {
                    lvi = lvBackpack.CheckedItems[x];
                    PostData = PostData + "&dropitem%5B%5D=" + lvi.SubItems[2].Text;
                }
            }

            if (chkSecurity.Checked == true)
            {
                DialogResult answer = MessageBox.Show("Are you sure you want to drop " + lvBackpack.CheckedItems.Count + " items?", "Confirmation", MessageBoxButtons.YesNo);

                if (answer == DialogResult.Yes)
                {
                    PostData = PostData + "&eqdrop=Perform+Action";
                    string strHtml = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Post("home.php", PostData);
                    if (strHtml.IndexOf("You have been awarded") > 0)
                    {
                        CoreUI.Instance.LogPanel.Log(CoreUI.Instance.AccountsPanel.Engine.MainAccount.Name + " dropped " + lvBackpack.CheckedItems.Count + " items.");
                    }
                    else
                        CoreUI.Instance.LogPanel.Log("Error dropping items");
                }
            }
            else
            {
                string security = InputBox.Prompt("Security Required", "A security word is required for this action.");
                PostData = PostData + "&answer=" + security + "&eqdrop=Perform+Action";
                if (security.Length > 1)
                {
                string strHtml = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Post("home.php", PostData);
                if (strHtml.IndexOf("You have been awarded") > 0)
                {
                    CoreUI.Instance.LogPanel.Log(CoreUI.Instance.AccountsPanel.Engine.MainAccount.Name + " dropped " + lvBackpack.CheckedItems.Count + " items.");
                }
                else
                    CoreUI.Instance.LogPanel.Log("Error dropping items");
                }
            }
            CoreUI.Instance.LogPanel.Log("Refreshing backpack for " + CoreUI.Instance.AccountsPanel.Engine.MainAccount.Name);

            lvBackpack.Items.Clear();
            Thread tt = new Thread(LoadBP);
            tt.Start();
            tt.IsBackground = true;

            Thread t1 = new Thread(LoadPotions);
            t1.Start();
            t1.IsBackground = true;

            Thread t2 = new Thread(LoadOrbs);
            t2.Start();
            t2.IsBackground = true;
        }

        private void chkUseBoosters_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseBoosters.Checked == true)
            {
                rdMajorExp.Enabled = true;
                rdMinorExp.Enabled = true;
                lblCasted.Enabled = true;
                label2.Enabled = true;
                lnkRefreshCasted.Enabled = true;
                rdMajorExp.Checked = true;
                lnkCast.Enabled = true;
            }
            else
            {
                rdMajorExp.Enabled = false;
                rdMinorExp.Enabled = false;
                lblCasted.Enabled = false;
                label2.Enabled = false;
                lnkRefreshCasted.Enabled = false;
                lnkCast.Enabled = false;
            }
        }

        private void lnkRefreshCasted_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExpCasted = 0;
            lblCasted.Text = ExpCasted.ToString();
        }

        private void lnkCast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CoreUI.Instance.AccountsPanel.Engine.SetMain(CoreUI.Instance.AccountsPanel.CheckedIndices[0]);
            CheckForIllegalCrossThreadCalls = false;

            if (rdMajorExp.Checked == true)
            {
                minutes = 33;
                Thread cast = new Thread(CastMajorBooster);
                cast.IsBackground = true;
                cast.Start();
            }
            else
            {
                minutes = 18;
                Thread cast = new Thread(CastMiniorBooster);
                cast.IsBackground = true;
                cast.Start();
            }
        }

        private void CastMiniorBooster()
        {
            string chkRage = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("backpack.php?potion=1");
            if (chkRage.IndexOf("potions/exppot.gif") > 0)
            {
                    Parser minor = new Parser(chkRage);
                    string boosterid = minor.Parse("potions/exppot.gif", "kill();makemenu");
                    Parser id = new Parser(boosterid);
                    string MinorId = id.Parse("itempopup(event,'", "')");
                    string strCast = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("home.php?itemaction=" + MinorId);
                    ExpCasted++;
                    lblCasted.Text = ExpCasted.ToString();
                    CoreUI.Instance.LogPanel.Log("Minor exp boost casted on " + CoreUI.Instance.AccountsPanel.Engine.MainAccount.Name);
            }
        }

        private void CastMajorBooster()
        {
            string chkRage = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("backpack.php?potion=1");
            if (chkRage.IndexOf("potions/exppot2.gif") > 0)
            {
                Parser minor = new Parser(chkRage);
                string boosterid = minor.Parse("potions/exppot2.gif", "kill();makemenu");
                Parser id = new Parser(boosterid);
                string MinorId = id.Parse("itempopup(event,'", "')");
                string strCast = CoreUI.Instance.AccountsPanel.Engine.MainAccount.Socket.Get("home.php?itemaction=" + MinorId);
                ExpCasted++;
                lblCasted.Text = ExpCasted.ToString();
                CoreUI.Instance.LogPanel.Log("Major exp boost casted on " + CoreUI.Instance.AccountsPanel.Engine.MainAccount.Name);
            }
        }
    }
}
