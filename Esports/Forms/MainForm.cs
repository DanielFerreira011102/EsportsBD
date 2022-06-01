using System.Runtime.InteropServices;

namespace Esports
{
    public partial class MainForm : Form
    {
        private Button selectedScreen;

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
            homeBtn.BackColor = Color.AliceBlue;
            this.selectedScreen = homeBtn;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
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
                EventsBtn.BackColor = Color.AliceBlue;
                HeaderLbl.Text = "Events";
                this.selectedScreen = EventsBtn;
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
                teamBtn.BackColor = Color.AliceBlue;
                HeaderLbl.Text = "Teams";
                this.selectedScreen = teamBtn;
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
                orgBtn.BackColor = Color.AliceBlue;
                HeaderLbl.Text = "Organizations";
                this.selectedScreen = orgBtn;
            }
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != helpBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = helpBtn.Height;
                panelNav.Top = helpBtn.Top;
                panelNav.Left = helpBtn.Left;
                helpBtn.BackColor = Color.AliceBlue;
                HeaderLbl.Text = "Help";
                this.selectedScreen = helpBtn;
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
                homeBtn.BackColor = Color.AliceBlue;
                HeaderLbl.Text = "Home";
                this.selectedScreen = homeBtn;
            }
        }

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            this.Close(); // fecha este form
            // Application.Exit(); // fecha toda a aplicação
        }

        private void playersBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedScreen != playersBtn)
            {
                this.selectedScreen.BackColor = Color.FromArgb(24, 30, 54);
                panelNav.Height = playersBtn.Height;
                panelNav.Top = playersBtn.Top;
                panelNav.Left = playersBtn.Left;
                playersBtn.BackColor = Color.AliceBlue;
                HeaderLbl.Text = "Players";
                this.selectedScreen = playersBtn;
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
    }
}