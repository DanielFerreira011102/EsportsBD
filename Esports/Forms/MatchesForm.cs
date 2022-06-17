using System.Data;
using System.Data.SqlClient;
using Esports.Classes;
using System.Diagnostics;
using System.Globalization;

namespace Esports.Forms
{

    public partial class MatchesForm : Form
    {

        private SqlConnection cn;
        private User currentUser;
        private ListViewColumnSorter lvwColumnSorter;
        private String? twitter, twitch;

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

        public MatchesForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();

            lvwColumnSorter = new ListViewColumnSorter();
            this.TeamsList.ListViewItemSorter = lvwColumnSorter;

            TeamsList.GridLines = true;
            GameSelect.SelectedItem = "CS:GO";
            LoadBDPlayers();        
        }

        private void MatchesForm_Load(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM  getMatchData(@Game)", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Game", GameSelect.SelectedItem);
            SqlDataReader reader = cmd.ExecuteReader();

            TeamsList.Items.Clear();

            while (reader.Read())
            {

                ListViewItem item = new(reader["date"].ToString());

                String? name = reader["name"].ToString();
                String? status = reader["status"].ToString();
                String? id = reader["id"].ToString();

                item.SubItems.Add(name);
                item.SubItems.Add(status);
                item.SubItems.Add(id);

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
                GameLbl.Text = GameSelect.SelectedItem.ToString();
                DateLbl.Text = TeamsList.SelectedItems[0].SubItems[0].Text;
                TourLbl.Text = TeamsList.SelectedItems[0].SubItems[1].Text;
                string? status = TeamsList.SelectedItems[0].SubItems[2].Text;

                if (status != "ONGOING")
                {
                    StatusImg.SendToBack();
                    StatusImg.Image = null;
                    StatusLbl.Text = TeamsList.SelectedItems[0].SubItems[2].Text;
                }
                else
                {
                    StatusImg.BringToFront();
                    StatusLbl.Text = null;
                    StatusImg.Image = Properties.Resources.live;
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM getMatchInfo(@id, @Tournament)", cn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Int32.Parse(TeamsList.SelectedItems[0].SubItems[3].Text));
                cmd.Parameters.AddWithValue("@Tournament", TourLbl.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                int count = 0;
                while (reader.Read())
                {
                    
                    if (count == 0)
                    {
                        OrgLbl.Text = reader["organization"].ToString();
                        BestOfLbl.Text = "BEST OF " + reader["best_of"].ToString();

                        team1Name.Text = reader["name"].ToString();
                        string? prof = reader["logo_url"].ToString();
                        try { team1Img.Load(prof); }
                        catch { team1Img.Image = Properties.Resources.notfound; }
                        count = 1;
                    }
                    else
                    {
                        team2Name.Text = reader["name"].ToString();
                        string? prof = reader["logo_url"].ToString();
                        try { team2Img.Load(prof); }
                        catch { team1Img.Image = Properties.Resources.notfound; }
                    }

                }

                reader.Close();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM getMatchWinner(@id)", cn);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@id", Int32.Parse(TeamsList.SelectedItems[0].SubItems[3].Text));
                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {

                    string? winner = reader2["winner"].ToString();
                    string? score1 = reader2["score_team1"].ToString();
                    string? score2 = reader2["score_team2"].ToString();

                    if (string.IsNullOrEmpty(winner))
                    {
                        team1Score.Text = score1;
                        team2Score.Text = score2;
                        leftWin.Image = null;
                        rightWin.Image = null;
                        leftWin.SendToBack();
                        rightWin.SendToBack();
                    }
                    else if (winner == team1Name.Text)
                    {
                        int winnerScore = Math.Max(Int32.Parse(score1), Int32.Parse(score2));
                        int loserScore = Math.Min(Int32.Parse(score1), Int32.Parse(score2));
                        team1Score.Text = winnerScore.ToString();
                        team2Score.Text = loserScore.ToString();
                        rightWin.Image = null;
                        rightWin.SendToBack();
                        leftWin.BringToFront();
                        leftWin.Image = Properties.Resources.winner;

                    }
                    else if (winner == team2Name.Text)
                    {
                        int winnerScore = Math.Max(Int32.Parse(score1), Int32.Parse(score2));
                        int loserScore = Math.Min(Int32.Parse(score1), Int32.Parse(score2));
                        team2Score.Text = winnerScore.ToString();
                        team1Score.Text = loserScore.ToString();
                        leftWin.Image = null;
                        leftWin.SendToBack();
                        rightWin.BringToFront();
                        rightWin.Image = Properties.Resources.winner;
                    }

                }

                reader2.Close();
            }

            cn.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GameSelect_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBDPlayers();
            TeamsList.Items[0].Selected = true;
            TeamsList.Select();
        }
    }
}
