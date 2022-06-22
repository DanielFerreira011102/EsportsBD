using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{

    public partial class SearchForm : Form
    {

        private SqlConnection cn;
        private ListViewColumnSorter lvwColumnSorter;
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

        public SearchForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();      
        }

        public SearchForm(string text) : this()
        {
            LoadBDData(text);
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadBDData(String Text)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("EXEC search @Text", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Text", Text);
            SqlDataReader reader = cmd.ExecuteReader();

            SearchList.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new(reader["match"].ToString());
                item.SubItems.Add(reader["type"].ToString());

                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    sub.ForeColor = System.Drawing.Color.Black;
                    sub.Font = new System.Drawing.Font("Quicksand", 8, System.Drawing.FontStyle.Regular);
                }

                SearchList.Items.Add(item);
            }

            // Close reader 
            reader.Close();

            cn.Close();
     
        }
    }
}
