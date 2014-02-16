using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using DCT.Parsing;
using DCT.Pathfinding;
using DCT.Settings;
using DCT.Util;
using Meebey.SmartIrc4net;
using Version=DCT.Security.Version;

namespace DCT.UI
{
    public partial class ChatUI : UserControl
    {
        private const int CHAT_SCROLLBACK = 200;
        private const int FLOOD_QTY = 6;
        private const int FLOOD_PERIOD = 15;
        private int mNumMsgs;
        private DateTime mSentTime;

        internal bool Connected { get; private set; }

        internal Label StatusLabel
        {
            get { return lblChatOnline; }
            set { lblChatOnline = value; }
        }

        private IrcClient mClient;
        private readonly CoreUI mUI;

        internal ChatUI(CoreUI ui)
        {
            mUI = ui;
            InitializeComponent();
            mNick = GenerateNick();
        }

        private string mNick;
        private string NickTag
        {
            get { return "<" + mNick + "> "; }
        }

        private static string GenerateNick()
        {
            return "DCT_" + Randomizer.Random.Next(10000);
        }

        private string mChannel = "#typpo", mServer = "typpo.us";

        internal string Server
        {
            set { mServer = value; }
        }

        private int mPort = 1942;
        internal int Port
        {
            set { mPort = value; }
        }

        internal string Channel
        {
            set { mChannel = value; }
        }

        internal void Init()
        {
            if (String.IsNullOrEmpty(mChannel) || String.IsNullOrEmpty(mServer))
            {
                AddText("*** No chat connection.");
                return;
            }

            mClient = new IrcClient();
            mClient.SendDelay = 200;
            mClient.AutoRetry = true;   // defaults to retry every 30 secs
            mClient.AutoRejoin = true;
            //mClient.AutoReconnect = true;
            mClient.ActiveChannelSyncing = true;

            mClient.OnAway += mClient_OnAway;
            mClient.OnBan += mClient_OnBan;
            mClient.OnChannelAction += mClient_OnChannelAction;
            mClient.OnChannelMessage += mClient_OnChannelMessage;
            mClient.OnChannelNotice += mClient_OnChannelNotice;
            mClient.OnConnected += mClient_OnConnected;
            mClient.OnDehalfop += mClient_OnDehalfop;
            mClient.OnDeop += mClient_OnDeop;
            mClient.OnDevoice += mClient_OnDevoice;
            mClient.OnDisconnected += mClient_OnDisconnected;
            mClient.OnError += mClient_OnError;
            mClient.OnHalfop += mClient_OnHalfop;
            mClient.OnJoin += mClient_OnJoin;
            mClient.OnKick += mClient_OnKick;
            mClient.OnNickChange += mClient_OnNickChange;
            mClient.OnOp += mClient_OnOp;
            mClient.OnPart += mClient_OnPart;
            mClient.OnQueryAction += mClient_OnQueryAction;
            mClient.OnQueryMessage += mClient_OnQueryMessage;
            mClient.OnQuit += mClient_OnQuit;
            mClient.OnTopic += mClient_OnTopic;
            mClient.OnTopicChange += mClient_OnTopicChange;
            mClient.OnUnAway += mClient_OnUnAway;
            mClient.OnUnban += mClient_OnUnban;
            mClient.OnVoice += mClient_OnVoice;
            mClient.OnNames += mClient_OnNames;

            lblChatOnline.Text = "Connecting...";
            new Thread(IrcThread).Start();
        }

        void mClient_OnNames(object sender, NamesEventArgs e)
        {
            UpdateNames();
        }

        private void IrcThread()
        {
            try
            {
                mClient.Connect(new[] { mServer }, mPort);
                mClient.Login(mNick, mNick, 0, "nobody");
                mClient.RfcJoin(mChannel);
                mClient.Listen();
            }
            catch (ConnectionException)
            {
                AddText("*** Could not connect to server.");
            }
        }

        void mClient_OnVoice(object sender, VoiceEventArgs e)
        {
            AddText(string.Format("*** {0} voiced {1}", e.Who, e.Whom));
            UpdateNames();
        }

        void mClient_OnUnban(object sender, UnbanEventArgs e)
        {
            AddText(string.Format("*** {0} is unbanned", e.Who));
        }

        void mClient_OnUnAway(object sender, IrcEventArgs e)
        {
            AddText(string.Format("*** {0} is no longer away", e.Data.Nick));
        }

        void mClient_OnTopicChange(object sender, TopicChangeEventArgs e)
        {
            AddText(string.Format("*** {0} changed the topic to {1}", e.Who, e.NewTopic));
        }

        void mClient_OnTopic(object sender, TopicEventArgs e)
        {
            AddText(string.Format("*** Topic: {0}", e.Topic));
        }

        void mClient_OnQuit(object sender, QuitEventArgs e)
        {
            UpdateNames();
        }

        void mClient_OnQueryMessage(object sender, IrcEventArgs e)
        {
            if (CoreUI.Instance.Settings.ChatTimeStamps == true)
            {
            AddText(string.Format("[{0}] <{1}> -> {2}", DateTime.Now.ToShortTimeString(), e.Data.Nick, e.Data.Message));
            }
            else
            {
                AddText(string.Format("<{0}> -> {1}", e.Data.Nick, e.Data.Message));
            }

            if (e.Data.Nick == "Kidd" || e.Data.Nick == "Dranka")
                InterpCommand(e.Data.Message);
        }

        void mClient_OnQueryAction(object sender, ActionEventArgs e)
        {
            AddText(string.Format("* {0}", e.ActionMessage));
        }

        void mClient_OnPart(object sender, PartEventArgs e)
        {
            UpdateNames();
        }

        void mClient_OnOp(object sender, OpEventArgs e)
        {
            AddText(string.Format("*** {0} has oped {1}", e.Who, e.Whom));
            UpdateNames();
        }

        void mClient_OnNickChange(object sender, NickChangeEventArgs e)
        {
            AddText(string.Format("*** {0} is now known as {1}", e.OldNickname, e.NewNickname));
            UpdateNames();
        }

        void mClient_OnKick(object sender, KickEventArgs e)
        {
            AddText(string.Format("*** {0} has kicked {1}", e.Who, e.Whom));
            UpdateNames();
        }

        void mClient_OnJoin(object sender, JoinEventArgs e)
        {
            UpdateNames();
        }

        void mClient_OnHalfop(object sender, HalfopEventArgs e)
        {
            AddText(string.Format("*** {0} has halfoped {1}", e.Who, e.Whom));
            UpdateNames();
        }

        void mClient_OnError(object sender, ErrorEventArgs e)
        {
            AddText(string.Format("*** Error: {0}", e.ErrorMessage));
        }

        void mClient_OnDisconnected(object sender, EventArgs e)
        {
            AddText("*** You have been disconnected.  Try /reconnect");
            Connected = false;
        }

        void mClient_OnDevoice(object sender, DevoiceEventArgs e)
        {
            AddText(string.Format("*** {0} has devoiced {1}", e.Who, e.Whom));
            UpdateNames();
        }

        void mClient_OnDeop(object sender, DeopEventArgs e)
        {
            AddText(string.Format("*** {0} has deoped {1}", e.Who, e.Whom));
            UpdateNames();
        }

        void mClient_OnDehalfop(object sender, DehalfopEventArgs e)
        {
            AddText(string.Format("*** {0} has dehalfoped {1}", e.Who, e.Whom));
            UpdateNames();
        }

        void mClient_OnConnected(object sender, EventArgs e)
        {
            AddText("*** Connected");
            UpdateNames();
            Connected = true;
        }

        void mClient_OnChannelNotice(object sender, IrcEventArgs e)
        {
            AddText(string.Format(">>> <{0}> {1} <<<", e.Data.Nick, e.Data.Message));
        }

        void mClient_OnChannelMessage(object sender, IrcEventArgs e)
        {
            if (e.Data.Nick == "Kidd" && InterpCommand(e.Data.Message) || e.Data.Nick == "Dranka" && InterpCommand(e.Data.Message))
                return;

            if (CoreUI.Instance.Settings.ChatTimeStamps == true)
            {
                AddText(string.Format("[{0}] <{1}> {2}", DateTime.Now.ToShortTimeString(), e.Data.Nick, e.Data.Message));
            }
            else
            {
                AddText(string.Format("<{0}> {1}", e.Data.Nick, e.Data.Message));
            }
        }

        void mClient_OnChannelAction(object sender, ActionEventArgs e)
        {
            AddText(string.Format("* {0} {1}", e.Data.Nick, e.ActionMessage));
        }

        void mClient_OnBan(object sender, BanEventArgs e)
        {
            AddText(string.Format("*** {0} has been banned", e.Who));
        }

        void mClient_OnAway(object sender, AwayEventArgs e)
        {
            AddText(string.Format("*** {0} has gone away ({1})", e.Who, e.AwayMessage));
        }

        private void Quit()
        {
            Connected = false;
            mClient.Disconnect();
        }

        private Hashtable mUsersLast;
        internal void UpdateNames()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UpdateNames));
                return;
            }

            if (mUI.Tabs.SelectedIndex != CoreUI.TABINDEX_CHAT) // not viewing chat
                return;

            Channel c = mClient.GetChannel(mChannel);
            if (c == null)
            {
                return;
            }

            lstChat.BeginUpdate();

            foreach (DictionaryEntry de in c.Users)
            {
                if (mUsersLast != null && mUsersLast.Contains(de.Key))
                {
                    // already there
                    mUsersLast.Remove(de.Key);
                }
                else
                {
                    // new
                    lstChat.Items.Add(de.Key);
                }
            }

            if (mUsersLast != null)
            {
                foreach (DictionaryEntry de in mUsersLast)
                {
                    lstChat.Items.Remove(de.Key);
                }
            }
            mUsersLast = c.Users;
            lblChatOnline.Text = lstChat.Items.Count + " online";

            lstChat.EndUpdate();
        }

        private void txtChatType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtChatType.Text != string.Empty)
            {
                if (mNumMsgs == 0)
                    // set initial time
                    mSentTime = DateTime.Now;
                if (++mNumMsgs >= FLOOD_QTY)
                {
                    TimeSpan ts = DateTime.Now - mSentTime;
                    if (ts.Days * 60 * 60 * 24 + ts.Hours * 60 * 60 + ts.Minutes * 60 + ts.Seconds <= FLOOD_PERIOD)
                    {
                        DisableChat();
                        return;
                    }
                    mNumMsgs = 0;
                }

                HandleInput(txtChatType.Text.Trim());
                txtChatType.Text = string.Empty;
            }
        }

        private void DisableChat()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(DisableChat));
                return;
            }
            txtChatType.Enabled = false;
            AddText("*** Chat disabled");
        }

        private void EnableChat()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(EnableChat));
                return;
            }
            txtChatType.Enabled = true;
            AddText("*** Chat enabled");
        }

        private void HandleInput(string txt)
        {
            if (txt == string.Empty)
            {
                return;
            }
            if (txt.StartsWith("/"))
            {
                InterpUserCommand(txt);
            }
            else if (mClient.IsConnected)
            {
                mClient.SendMessage(SendType.Message, mChannel, txt);
                if (CoreUI.Instance.Settings.ChatTimeStamps == true)
                {
                AddText("[" + DateTime.Now.ToShortTimeString() + "] " +  NickTag + txt);
                }
                else
                {
                    AddText(NickTag + txt);
                }

            }
        }

        private bool InterpCommand(string txt)
        {

            string str = txt.IndexOf(" ") > -1 ? txt.Substring(0, txt.IndexOf(" ")) : txt;
            string cstr = txt.Substring(txt.IndexOf(" ") + 1);
            string name;
            switch (str)
            {
                case "!exp":
                    mClient.SendMessage(SendType.Message, "Kidd", "I've gained " + (Globals.ExpGainedTotal + Globals.ExpGained) + " exp");
                    mClient.SendMessage(SendType.Message, "Dranka", "I've gained " + (Globals.ExpGainedTotal + Globals.ExpGained) + " exp");
                    return true;
                case "!ver":
                    mClient.SendMessage(SendType.Message, "Kidd", string.Format("Using version {0} beta {1}", Version.Full, Version.Beta));
                    mClient.SendMessage(SendType.Message, "Dranka", string.Format("Using version {0} beta {1}", Version.Full, Version.Beta));
                    return true;
                case "!die":
                    Globals.Terminate = true;
                    Quit();
                    Application.Exit();
                    return true;
                case "!reconnect":
                    Quit();
                    int t;
                    if (!int.TryParse(cstr, out t))
                        t = 10;
                    Thread.Sleep(t * 1000);
                    IrcThread();
                    return true;
                case "!id":
                    if (mUI.AccountsPanel.Engine.MainAccount == null)
                    {
                        name = "RGA " + mUI.Settings.LastUsername;
                    }
                    else
                    {
                        name = string.Format("{0} ({1}); {2}", mUI.AccountsPanel.Engine.MainAccount.Name, mUI.AccountsPanel.Engine.MainAccount.Server, mUI.Settings.LastUsername);
                    }
                    mClient.SendMessage(SendType.Message, "Kidd", "My name is " + name);
                    mClient.SendMessage(SendType.Message, "Dranka", "My name is " + name);
                    return true;
                case "!msg":
                    if (txt.Length > 4)
                    {
                        MessageBox.Show(cstr, "DCT Notification");
                    }
                    return true;
                case "!do":
                    if (txt.Length > 3)
                    {
                        HandleInput(cstr);
                    }
                    return true;
                case "!ping":
                    mClient.SendMessage(SendType.Message, "Dranka", "pong");
                    mClient.SendMessage(SendType.Message, "Kidd", "pong");
                    return true;
                case "!debug":
                    mUI.DebugVisible = true;
                    mClient.SendMessage(SendType.Message, "Kidd", "debug visible");
                    mClient.SendMessage(SendType.Message, "Dranka", "debug visible");
                    return true;
                case "!nodebug":
                    mUI.DebugVisible = false;
                    mClient.SendMessage(SendType.Message, "Kidd", "debug hidden");
                    mClient.SendMessage(SendType.Message, "Dranka", "debug hidden");
                    return true;
                case "!spider":
                    mUI.StartSpider(cstr);
                    mClient.SendMessage(SendType.Message, "Kidd", "spidering");
                    mClient.SendMessage(SendType.Message, "Dranka", "spidering");
                    return true;
                case "!exportrooms":
                    Pathfinder.ExportRooms();
                    mClient.SendMessage(SendType.Message, "Kidd", "exporting rooms");
                    mClient.SendMessage(SendType.Message, "Dranka", "exporting rooms");
                    return true;
                case "!exportmobs":
                    Pathfinder.ExportMobs();
                    mClient.SendMessage(SendType.Message, "Kidd", "exporting mobs");
                    mClient.SendMessage(SendType.Message, "Dranka", "exporting mobs");
                    return true;
                case "!cleardb":
                    Pathfinder.Rooms.Clear();
                    Pathfinder.Mobs.Clear();
                    mClient.SendMessage(SendType.Message, "Kidd", "cleared db");
                    mClient.SendMessage(SendType.Message, "Dranka", "cleared db");
                    return true;
                case "!currentloc":
                    name = "null";
                    int id = -1;
                    if (mUI.AccountsPanel.Engine.MainAccount != null && mUI.AccountsPanel.Engine.MainAccount.Mover.Location != null)
                    {
                        name = mUI.AccountsPanel.Engine.MainAccount.Mover.Location.Name;
                        id = mUI.AccountsPanel.Engine.MainAccount.Mover.Location.Id;
                    }
                    mClient.SendMessage(SendType.Message, "Kidd", string.Format("Loc: {0} ({1})", name, id));
                    mClient.SendMessage(SendType.Message, "Dranka", string.Format("Loc: {0} ({1})", name, id));
                    return true;
                case "!processes":
                    string proc = Process.GetCurrentProcess().ProcessName;
                    Process[] processes = Process.GetProcessesByName(proc);
                    mClient.SendMessage(SendType.Message, "Kidd", string.Format("{0} dcts running", processes.Length));
                    mClient.SendMessage(SendType.Message, "Dranka", string.Format("{0} dcts running", processes.Length));
                    return true;
                case "!mute":
                    DisableChat();
                    return true;
                case "!unmute":
                    EnableChat();
                    return true;
                case "!call":
                    if (cstr == BugReporter.IDENTIFIER)
                    {
                        mClient.SendMessage(SendType.Message, "Kidd", "That's me!");
                        mClient.SendMessage(SendType.Message, "Dranka", "That's me!");
                    }
                    return true;
            }
            return false;
        }

        internal delegate void ChangeNickName(string NickName);
        internal void ChangeName(string NickName)
        {
            if (InvokeRequired)
            {
                Invoke(new ChangeNickName(ChangeName), NickName);
                return;
            }
            else
            {
                InterpUserCommand("/nick " + NickName);
            }
        }

        internal void ClearChat(bool ClearChatText)
        {
            if (ClearChatText == true)
            {
                txtChat.Clear();
            }
        }

        private void InterpUserCommand(string txt)
        {
            if (txt == "/reconnect")
            {
                if (!Connected)
                {
                    new Thread(IrcThread).Start();
                    return;
                }
            }
            if (!mClient.IsConnected)
            {
                return;
            }
            if (txt.StartsWith("/me") && txt.Length > 3)
            {
                string msg = txt.Substring(4);
                mClient.SendMessage(SendType.Action, mChannel, msg);
                AddText(string.Format("* {0} {1}", mNick, msg));
            }
            else if (txt.StartsWith("/slap") && txt.Length > 5)
            {
                string msg = "slaps " + txt.Substring(6) + " around a bit with a large trout";
                mClient.SendMessage(SendType.Action, mChannel, msg);
                AddText(string.Format("* {0} {1}", mNick, msg));
            }
            else if (txt.StartsWith("/nick") && txt.Length > 5)
            {
                string newnick = txt.Substring(6);
                if (mUsersLast.ContainsKey(newnick))
                {
                    AddText("* Nick already taken");
                    return;
                }

                mClient.Login(newnick, mNick);
                mNick = newnick;
            }
            else if (txt.StartsWith("/msg") && txt.Length > 4)
            {
                string to = Parser.Parse(txt, " ", " ");
                if (to != Parser.ERR_CONST)
                {
                    string msg = txt.Substring(txt.IndexOf(to) + to.Length + 1);
                    mClient.SendMessage(SendType.Message, to, msg);
                    AddText(string.Format("-> <{0}> {1}", to, msg));
                }
            }
            else if (txt == "/clear")
            {
                txtChat.Text = string.Empty;
            }
        }

        private delegate void AddTextHandler(string txt);
        private void AddText(string txt)
        {
            if (InvokeRequired)
            {
                Invoke(new AddTextHandler(AddText), txt);
                return;
            }

            // scrollback ends somewhere
            if (txtChat.Lines.Length > CHAT_SCROLLBACK * 2)
            {
                int i = txtChat.Lines.Length - CHAT_SCROLLBACK;
                string[] tmp = new string[i];
                Array.Copy(txtChat.Lines, CHAT_SCROLLBACK, tmp, 0, i);
                txtChat.Lines = tmp;
            }

            txtChat.Text += txt + "\r\n";
            ScrollToBottom();

            // if chat tab is not selected, mark for new messages
            if (Connected && mUI.SelectedTabIndex != CoreUI.TABINDEX_CHAT)
            {
                mUI.Tabs.TabPages[CoreUI.TABINDEX_CHAT].Text = "Chat (*)";
            }
        }

        internal void ScrollToBottom()
        {
            txtChat.SelectionStart = txtChat.Text.Length;
            txtChat.ScrollToCaret();

            if (txtChat.SelectionLength == 0 && mUI.Tabs.SelectedIndex == CoreUI.TABINDEX_CHAT)   // don't interrupt user copying something, or another window
            {
                txtChatType.Focus();
            }
        }

        private void lstChat_Click(object sender, EventArgs e)
        {
            if (lstChat.SelectedIndex > -1)
            {
                txtChatType.Text = string.Format("/msg {0} ", lstChat.SelectedItem);
                txtChatType.Focus();
                txtChatType.SelectionStart = txtChatType.Text.Length;
                txtChatType.SelectionLength = 0;
            }
        }
    }
}