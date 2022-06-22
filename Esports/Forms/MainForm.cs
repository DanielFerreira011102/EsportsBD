using System.Runtime.InteropServices;

namespace Esports
{
    public partial class MainForm : Form
    {
        private Button selectedScreen;
        private Form activeForm;
        private string back;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public MainForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panelNav.Height = homeBtn.Height;
            panelNav.Top = homeBtn.Top;
            panelNav.Left = homeBtn.Left;
            homeBtn.BackColor = Color.FromArgb(220, 239, 255);
            this.selectedScreen = homeBtn;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        public MainForm(String username, String region) : this()
        {
            usernameLbl.Text = username;
            regionLbl.Text = region;
        }

        public MainForm(string username, string region, string v) : this(username, region)
        {
            this.back = v;
            Form child = new Forms.MyHomeForm(username, v);
            activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(child);
            this.panelDesktop.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 25, 25));
        }

        private void EventsBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != EventsBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = EventsBtn.Height;
                panelNav.Top = EventsBtn.Top;
                panelNav.Left = EventsBtn.Left;
                EventsBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "Events";
                this.selectedScreen = EventsBtn;
                openChildForm(new Forms.EventsForm());
            }
        }

        private void teamBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != teamBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = teamBtn.Height;
                panelNav.Top = teamBtn.Top;
                panelNav.Left = teamBtn.Left;
                teamBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "Teams";
                this.selectedScreen = teamBtn;
                openChildForm(new Forms.TeamsForm());
            }
        }

        private void orgBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != orgBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = orgBtn.Height;
                panelNav.Top = orgBtn.Top;
                panelNav.Left = orgBtn.Left;
                orgBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "Organizations";
                this.selectedScreen = orgBtn;
                openChildForm(new Forms.OrgsForm());
            }
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != ProfileBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = ProfileBtn.Height;
                panelNav.Top = ProfileBtn.Top;
                panelNav.Left = ProfileBtn.Left;
                ProfileBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "Help";
                this.selectedScreen = ProfileBtn;
                openChildForm(activeForm);
            }
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != homeBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = homeBtn.Height;
                panelNav.Top = homeBtn.Top;
                panelNav.Left = homeBtn.Left;
                homeBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "Home";
                this.selectedScreen = homeBtn;
                openChildForm(new Forms.MyHomeForm(usernameLbl.Text, back));
            }
        }

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            var backForm = new Forms.LoginOrRegistForm();
            backForm.Show();
            this.Close(); // fecha este form
        }

        private void playersBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != playersBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = playersBtn.Height;
                panelNav.Top = playersBtn.Top;
                panelNav.Left = playersBtn.Left;
                playersBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "Players";
                this.selectedScreen = playersBtn;
                openChildForm(new Forms.PlayersForm());
            }
        }

        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maxBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) {
                this.Width = Screen.FromControl(this).Bounds.Width;
                this.Height = Screen.FromControl(this).Bounds.Height;
            }
            else this.WindowState = FormWindowState.Normal;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void openChildForm(Form child)
        {
            if (activeForm != child)
            {
                activeForm.Close();
                activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                this.panelDesktop.Controls.Add(child);
                this.panelDesktop.Tag = child;
                child.BringToFront();
                child.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MatchesBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != MatchesBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = MatchesBtn.Height;
                panelNav.Top = MatchesBtn.Top;
                panelNav.Left = MatchesBtn.Left;
                MatchesBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "Matches";
                this.selectedScreen = MatchesBtn;
                openChildForm(new Forms.MatchesForm());
            }
        }

        private bool isCollapsed = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                ProfileBtn.Image = Properties.Resources.Collapse_Arrow_20px;
                panel4.Height += 10;
                if (panel4.Height == panel4.MaximumSize.Height)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                ProfileBtn.Image = Properties.Resources.Expand_Arrow_20px;
                panel4.Height -= 10;
                if (panel4.Height == panel4.MinimumSize.Height)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private Button selectedSub;
        private void GoToMyAccount(object sender, EventArgs e)
        {
            if (this.selectedScreen != ProfileBtn || selectedSub != MyAccountBtn )
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = orgBtn.Height;
                panelNav.Top = orgBtn.Top + 67;
                panelNav.Left = MatchesBtn.Left;
                ProfileBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "My Account";
                this.selectedScreen = ProfileBtn;
                this.selectedSub = MyAccountBtn;
                openChildForm(new Forms.MyAccountForm(usernameLbl.Text));
            }
        }

        private void GoToMyOrg(object sender, EventArgs e)
        {
            if (this.selectedScreen != ProfileBtn || selectedSub != MyOrgBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = orgBtn.Height;
                panelNav.Top = orgBtn.Top + 67;
                panelNav.Left = MatchesBtn.Left;
                ProfileBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "My Organization";
                this.selectedScreen = ProfileBtn;
                this.selectedSub= MyOrgBtn;
                openChildForm(new Forms.MatchesForm());
            }
        }

        private void GoToMyTeam(object sender, EventArgs e)
        {
            if (this.selectedScreen != ProfileBtn || selectedSub != MyTeamBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = orgBtn.Height;
                panelNav.Top = orgBtn.Top + 67;
                panelNav.Left = MatchesBtn.Left;
                ProfileBtn.BackColor = Color.FromArgb(220, 239, 255);
                HeaderLbl.Text = "My Team";
                this.selectedScreen = ProfileBtn;
                this.selectedSub = MyTeamBtn;
                openChildForm(new Forms.MyTeamForm(usernameLbl.Text));
            }
        }

        private void GoToMSearch()
        {
           openChildForm(new Forms.SearchForm(textBox1.Text));
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GoToMSearch();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            GoToMSearch();
        }
    }
}