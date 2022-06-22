using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{

    public partial class MyAccountForm : Form
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

        public MyAccountForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();      
        }

        public MyAccountForm(string username) : this()
        {
            Username.Text = username;
            LoadBDData();
        }

        private void MyAccountForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadBDData()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM getUserData(@User)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@User", Username.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Email.Text = reader["email"].ToString();
                Password.Text = reader["password"].ToString();
                string gender = reader["gender"].ToString();
                Gender.Text = gender == "F" ? "Female" : "Male";
                string birthday = reader["birthday"].ToString();
                Birthday.Text = string.IsNullOrEmpty(birthday) ? birthday : birthday.Split(" ")[0];
                Region.Text = reader["region"].ToString();
                string jd = reader["join_date"].ToString();
                JoinDate.Text = string.IsNullOrEmpty(jd) ? jd : jd.Split(" ")[0];
            }

            // Close reader 
            reader.Close();

            cn.Close();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Password.Text = string.Empty;
            DeleteBtn.Visible = false;
            Password.ReadOnly = false;
            CommitBtn.Visible = true;
            CancelBtn.Visible = true;
            Password.Focus();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Region.Text = string.Empty;
            Region.ReadOnly = false;
            DeleteBtn.Visible = false;
            CommitBtn.Visible = true;
            CancelBtn.Visible = true;
            Region.Focus();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Region.ReadOnly = true;
            Password.ReadOnly = true;
            CommitBtn.Visible = false;
            CancelBtn.Visible = false;
            DeleteBtn.Visible = true;
            JoinDate.Select(0, 0);
            LoadBDData();
        }

        private void CommitBtn_Click(object sender, EventArgs e)
        {
            string region = Region.Text;
            string password = Password.Text;
            string[] games = { "World", "Europe", "Turkey", "South America", "North America", "Sub-Saharan Africa", "Oceania",
               "North Africa", "Middle East", "Korea", "China", "Brazil", "Asia-Pacific South", "Asia-Pacific North" };

            if (!games.Contains(region))
            {
                MessageBox.Show("Selected region " + region + " is not valid!");
                return;
            }

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd1 = new SqlCommand("EXEC editUser @Username=@user, @Password=@password, @Region=@region", cn);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@user", Username.Text);
            cmd1.Parameters.AddWithValue("@region", region);
            cmd1.Parameters.AddWithValue("@password", password);
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                MessageBox.Show("User " + Username.Text + " was updated!");
                cn.Close();
                LoadBDData();
                Region.ReadOnly = true;
                Password.ReadOnly = true;
                CommitBtn.Visible = false;
                CancelBtn.Visible = false;
                DeleteBtn.Visible = true;
                JoinDate.Select(0, 0);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete User", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!verifySGBDConnection())
                    return;

                SqlCommand cmd1 = new SqlCommand("EXEC deleteUser @Username=@username", cn);
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@username", Username.Text);

                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to delete user. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    cn.Close();
                    Hide();
                    LoginOrRegistForm login = new();
                    login.Show();
                }
       
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
