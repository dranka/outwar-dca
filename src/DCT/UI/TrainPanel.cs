using System;
using System.Windows.Forms;
using System.Threading;
using DCT.Outwar;
using DCT.Pathfinding;
using DCT.Protocols.Http;
using DCT.Util;

namespace DCT.UI
{
    internal partial class TrainPanel : UserControl
    {
        public int FuryCount = 0;
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
    }
}
