using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{

    public partial class TeamsForm : Form
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

        public TeamsForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();

            lvwColumnSorter = new ListViewColumnSorter();
            this.TeamsList.ListViewItemSorter = lvwColumnSorter;

            TeamsList.GridLines = true;
            GameSelect.SelectedItem = "CS:GO";
            LoadBDPlayers();        
        }

        private void TeamsForm_Load(object sender, EventArgs e)
        {
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            // Perform the sort with these new sort options.
            this.TeamsList.Sort();

            TeamsList.Items[0].Selected = true;
            TeamsList.Select();
        }

        private void LoadBDPlayers()
        {
            if (!verifySGBDConnection())
                return;

            if (GameSelect.SelectedIndex == -1)
                GameSelect.SelectedItem = "CS:GO";

            Debug.WriteLine(GameSelect.SelectedItem);
            // DOING WITH USER RN BUT I WANT PLAYERS
            SqlCommand cmd = new SqlCommand("SELECT * FROM getGameTeamData(@Game)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Game", GameSelect.SelectedItem);
            SqlDataReader reader = cmd.ExecuteReader();

            TeamsList.Items.Clear();

            while (reader.Read())
            {

                ListViewItem item = new(reader["ranking"].ToString());

                String? name = reader["name"].ToString();
                String? earns = reader["earnings"].ToString();

                item.SubItems.Add(name);
                item.SubItems.Add(earns);

                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    sub.ForeColor = System.Drawing.Color.Black;
                    sub.Font = new System.Drawing.Font("Quicksand", 8, System.Drawing.FontStyle.Regular);
                }

                TeamsList.Items.Add(item);

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
            this.TeamsList.Sort();
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

            if (!verifySGBDConnection())
                return;

            if (TeamsList.SelectedIndices.Count > 0)
            {
                RankLbl.Text = TeamsList.SelectedItems[0].SubItems[0].Text;
                NameLbl.Text = TeamsList.SelectedItems[0].SubItems[1].Text;
                EarningsLbl.Text = '$' + TeamsList.SelectedItems[0].SubItems[2].Text;

                SqlCommand cmd = new SqlCommand("SELECT * FROM getTeamInfo(@rank, @GAME)", cn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@rank", Int32.Parse(RankLbl.Text));
                cmd.Parameters.AddWithValue("@GAME", GameSelect.SelectedItem);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
      
                    TiesLbl.Text = reader["ties"].ToString();

                    LossesLbl.Text = reader["losses"].ToString();
                    WinsLbl.Text = reader["wins"].ToString();

                    string? prof = reader["logo_url"].ToString();
                    try { TeamProfile.Load(prof); }
                    catch { TeamProfile.Image = Properties.Resources.notfound; }
                    

                    GameLbl.Text = GameSelect.SelectedItem.ToString();


                }
            }

            cn.Close();

        }

        private void GameSelect_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBDPlayers();
            TeamsList.Items[0].Selected = true;
            TeamsList.Select();
        }
    }
}
