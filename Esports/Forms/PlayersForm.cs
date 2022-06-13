using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{
    public partial class PlayersForm : Form
    {

        private SqlConnection cn;
        private User currentUser;
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

        public PlayersForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();

            lvwColumnSorter = new ListViewColumnSorter();
            this.PlayerList.ListViewItemSorter = lvwColumnSorter;

            PlayerList.GridLines = true;
            GameSelect.SelectedItem = "CS:GO";
            LoadBDPlayers();        
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            // Perform the sort with these new sort options.
            this.PlayerList.Sort();
        }

        private void LoadBDPlayers()
        {
            if (!verifySGBDConnection())
                return;

            if (GameSelect.SelectedIndex == -1)
                GameSelect.SelectedItem = "CS:GO";

            Debug.WriteLine(GameSelect.SelectedItem);
            // DOING WITH USER RN BUT I WANT PLAYERS
            SqlCommand cmd = new SqlCommand("SELECT * FROM getGamePlayerData(@Game)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Game", GameSelect.SelectedItem);
            SqlDataReader reader = cmd.ExecuteReader();

            PlayerList.Items.Clear();

            while (reader.Read())
            {

                ListViewItem item = new(reader["ranking"].ToString());

                String? IGN = reader["IGN"].ToString();
                String? team = reader["name"].ToString();
                String? country = reader["country"].ToString();

                if (!string.IsNullOrEmpty(country))
                {
                    RegionInfo myRI1 = new RegionInfo(country);
                    country = myRI1.EnglishName;
                }

                item.SubItems.Add(IGN);
                item.SubItems.Add(team);
                item.SubItems.Add(country);

                /*
                if (string.IsNullOrEmpty(birthday))
                {
                    item.SubItems.Add(birthday);
                }
                else
                {
                    DateTime dt = DateTime.ParseExact(birthday.Split(" ")[0], "dd/MM/yyyy", null);
                    DateTime today = DateTime.Today;
                    int age = CalculateAge(dt, today);
                    item.SubItems.Add(age < 0? "0" : age.ToString());
                }

                String? gender = reader["gender"].ToString();
                if (string.IsNullOrEmpty(gender))
                {
                    item.SubItems.Add(gender);
                }
                else
                {
                    item.SubItems.Add(gender == "F"? "Female" : "Male");
                }
                */


                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    sub.ForeColor = System.Drawing.Color.Black;
                    sub.Font = new System.Drawing.Font("Quicksand", 8, System.Drawing.FontStyle.Regular);
                }

                PlayerList.Items.Add(item);
            }

            // Close reader 
            reader.Close();

            cn.Close();
        }

        private int CalculateAge(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            // For leap years we need this
            if (birthDate > now.AddYears(-age))
                age--;
            // Don't use:
            // if (birthDate.AddYears(age) > now) 
            //     age--;

            return age;
        }


        private void sortByColumn(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.PlayerList.Sort();
        }

        private void changeBackColor(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DodgerBlue, e.Bounds);
            e.Graphics.DrawString(e.Header.Text, new Font("Quicksand", 10, FontStyle.Regular),
                Brushes.White, e.Bounds);
            //e.DrawText();

        }

        private void justToCheck(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndices.Count > 0)
            {
                string rank = PlayerList.SelectedItems[0].SubItems[0].Text;
                string ign = PlayerList.SelectedItems[0].SubItems[1].Text;
                string team = PlayerList.SelectedItems[0].SubItems[2].Text;
                string country = PlayerList.SelectedItems[0].SubItems[3].Text;

                //textBox2.Text = currentUser.Username;
            }
        }

        private void GameSelect_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBDPlayers();
        }
    }
}
