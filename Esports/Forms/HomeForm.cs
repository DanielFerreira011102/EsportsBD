using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esports.Forms
{
    public partial class HomeForm : Form
    {
        private string back;
        private string name;

        public HomeForm()
        {
            InitializeComponent();
        }

        public HomeForm(string text, string back) : this()
        {
            name = text;
            this.back = back;
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            if (back == "LOG")
                header.Text = "Welcome Back, " + name + "!";
            else if (back == "REG")
                header.Text = "Hello, " + name + "!";
            wave.Location = new Point(50 + header.Width - 15, 4);
        }
    }
}
