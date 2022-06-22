using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{

    public partial class MyHomeForm : Form
    {

        private SqlConnection cn;
        private ListViewColumnSorter lvwColumnSorter;
        private readonly string back;
        private readonly string name;
        private SqlConnection getSGBDConnection()
        {
            //return new SqlConnection("data source= CCWIN8\\SQL2012EXPRESS;integrated security=true;initial catalog=Northwind");
            SqlConnection CN = new SqlConnection("data source=LAPTOP-C8296JRI\\SQLEXPRESS;Database=Esports;Trusted_Connection=True");

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Successful connection to database " + CN.Database + " on the " + CN.DataSource + " server", "Connection Test", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR \r\n" + ex.Message, "Connection Test", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();

            return CN;
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        public MyHomeForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();      
        }

        public MyHomeForm(string text, string back) : this()
        {
            name = text;
            this.back = back;
        }

        private void MyHomeForm_Load(object sender, EventArgs e)
        {
            if (back == "LOG")
                header.Text = "Welcome Back, " + name + "!";
            else if (back == "REG")
                header.Text = "Hello, " + name + "!";
            wave.Location = new Point(28 + header.Width - 15, 20);
        }

    }
}
