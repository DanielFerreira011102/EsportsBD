using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Esports.Forms
{
    public partial class LoginOrRegistForm : Form
    {

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

        public LoginOrRegistForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.ControlBox = false;
        }

        private void LoginOrRegistForm_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            MainForm MenuForm = new();
            MenuForm.Show();
            Hide();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            MainForm MenuForm = new();
            MenuForm.Show();
            Hide();
        }

        //declares
        [DllImport("user32.dll")]
        private static extern bool PostMessage(
        IntPtr hWnd, // handle to destination window
        Int32 msg, // message
        Int32 wParam, // first message parameter
        Int32 lParam // second message parameter
        );

        const Int32 WM_LBUTTONDOWN = 0x0201;

        private void customDatepicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //method to call dropdown
        private void show(object sender, EventArgs e)
        {
            Int32 x = BirthdayReg.Width - 10;
            Int32 y = BirthdayReg.Height / 2;
            Int32 lParam = x + y * 0x00010000;

            PostMessage(this.Handle, WM_LBUTTONDOWN, 1, lParam);
        }
    }
}
