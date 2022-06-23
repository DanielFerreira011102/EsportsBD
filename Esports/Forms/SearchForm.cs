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

        public SearchForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();

            lvwColumnSorter = new ListViewColumnSorter();
            this.SearchList.ListViewItemSorter = lvwColumnSorter;

            SearchList.GridLines = true;
        }

        public SearchForm(string text) : this()
        {
            LoadBDData(text);
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            // Perform the sort with these new sort options.
            this.SearchList.Sort();

            if (SearchList.Items.Count > 0) {
                SearchList.Items[0].Selected = true;
                SearchList.Select();
            }
        }

        public void LoadBDData(String Text)
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
                item.SubItems.Add(reader["pkey"].ToString());

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

        private void SearchList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SearchList.SelectedIndices.Count > 0)
            {
                string Role = SearchList.SelectedItems[0].SubItems[1].Text;

                if (Role == "Player")
                {
                    GetPlayer();
                }
                else if (Role == "Team")
                {
                    GetTeam();
                }
                else if (Role == "Organization")
                {

                }
                else if (Role == "Tournament")
                {
                    GetTour();
                }
                else if (Role == "Series")
                {
                    GetSeries();
                }
                else
                {
                    // podia ter feito este passo já na funçao -_-
                    TODO.Visible = true;
                    TodoPanel.Visible = true;

                    makeInvisible(TodoPanel, TODO);              
                }
            }
            // Game, Team Staff, Event Staff

        }

        private void GetPlayer()
        {

            if (!verifySGBDConnection())
                return;

            PlayerPanel.Visible = true;
            PlayersLbl.Visible = true;

            makeInvisible(PlayerPanel, PlayersLbl);

            UsernameLbl.Text = SearchList.SelectedItems[0].SubItems[2].Text;

            SqlCommand cmd = new SqlCommand("EXEC getSearchPlayer @ID", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", UsernameLbl.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                GameLbl.Text = reader["game"].ToString();
                IGNLbl.Text = reader["IGN"].ToString();
                RealNameLbl.Text = reader["real_name"].ToString();
                TeamLbl.Text = reader["team"].ToString();
                RankLbl.Text = reader["ranking"].ToString();

                string? prof = reader["profile_url"].ToString();
                try { PlayerProfile.Load(prof); }
                catch { PlayerProfile.Image = Properties.Resources.notfound; }

                twitter = reader["twitter_url"].ToString();
                twitch = reader["twitch_url"].ToString();

                string? dt = reader["team_join_date"].ToString();

                JoinDateLbl.Text = string.IsNullOrEmpty(dt) ? null : dt.Split(" ")[0];

                string? country = reader["country"].ToString();

                if (!string.IsNullOrEmpty(country))
                {
                    RegionInfo myRI1 = new RegionInfo(country);
                    country = myRI1.EnglishName;
                }

                CountryLbl.Text = country;


            }

            reader.Close();

            SqlCommand cmd2 = new SqlCommand("SELECT dbo.checkPlayerIGL(@Username)", cn);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@Username", UsernameLbl.Text);
            Boolean isIGL = (bool)cmd2.ExecuteScalar();

            if (isIGL)
            {
                IGLStar.Image = Properties.Resources.IGL;
                IGLStar.BringToFront();
            }
            else
            {
                IGLStar.Image = null;
                IGLStar.SendToBack();
            }

            cn.Close();

        }

        private void Twitch_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(twitch) { UseShellExecute = true });
            }
            catch
            {
                if (string.IsNullOrEmpty(twitch))
                    MessageBox.Show("Twitch url of selected user does not exist!");
                else
                    MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void Twitter_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(twitter) { UseShellExecute = true });

            }
            catch
            {
                if (string.IsNullOrEmpty(twitter))
                    MessageBox.Show("Twitter url of selected user does not exist!");
                else
                    MessageBox.Show("Unable to open link that was clicked!");
            }
        }

        private void ShowTooltipIGL(object sender, EventArgs e)
        {
            if (IGLStar.Image != null)
            {
                ToolTip tt = new ToolTip();
                tt.SetToolTip(IGLStar, "IGL");
            }
        }

        private void GetTeam()
        {

            if (!verifySGBDConnection())
                return;

            TeamsPanel.Visible = true;
            TeamHeaderLbl.Visible = true;

            makeInvisible(TeamsPanel, TeamHeaderLbl);


            SqlCommand cmd = new SqlCommand("EXEC getSearchTeam @ID", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", Int32.Parse(SearchList.SelectedItems[0].SubItems[2].Text));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TeamRank.Text = reader["ranking"].ToString();
                TeamTies.Text = reader["ties"].ToString();
                EarningsLbl.Text = '$' + reader["earnings"].ToString();
                team1Name.Text = reader["name"].ToString();
                LossesLbl.Text = reader["losses"].ToString();
                WinsLbl.Text = reader["wins"].ToString();

                string? prof = reader["logo_url"].ToString();
                try { TeamProfile.Load(prof); }
                catch { TeamProfile.Image = Properties.Resources.notfound; }


                TeamGame.Text = reader["game"].ToString();

            }

            cn.Close();

        }

        private void GetOrg()
        {

            if (!verifySGBDConnection())
                return;

            OrgPanel.Visible = true;
            OrgLbl.Visible = true;

            makeInvisible(OrgPanel, OrgLbl);

            NameLbl.Text = SearchList.SelectedItems[0].SubItems[2].Text;

            SqlCommand cmd = new SqlCommand("EXEC getSearchOrg @ID", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", NameLbl.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ContactLbl.Text = reader["contact"].ToString();

                string? prof = reader["logo_url"].ToString();
                try { OrgProfile.Load(prof); }
                catch { OrgProfile.Image = Properties.Resources.notfound; }
            }

            cn.Close();

        }

        private void GetSeries()
        {

            if (!verifySGBDConnection())
                return;

            SeriesPanel.Visible = true;
            SeriesPanel.Visible = true;

            makeInvisible(SeriesPanel, SeriesLbl);


            SqlCommand cmd = new SqlCommand("EXEC getSearchSeries @ID", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", Int32.Parse(SearchList.SelectedItems[0].SubItems[2].Text));
            SqlDataReader reader = cmd.ExecuteReader();

            int count = 0;
            int? winnerScore = null, loserScore = null;
            Boolean winner = false;
            string? score1 = null, score2 = null;
            while (reader.Read())
            {
                if (count == 0)
                {
                    OrgSName.Text = reader["organization"].ToString();
                    BestOfLbl.Text = "BEST OF " + reader["best_of"].ToString();
                    TourLbl.Text = reader["tournament"].ToString();
                    DateLbl.Text = reader["date"].ToString();

                    score1 = reader["score_team1"].ToString();
                    score2 = reader["score_team2"].ToString();

                    winnerScore = Math.Max(Int32.Parse(score1), Int32.Parse(score2));
                    loserScore = Math.Min(Int32.Parse(score1), Int32.Parse(score2));

                    leftWin.Visible = false;
                    rightWin.Visible = false;

                    Boolean isWinner = (bool)reader["isWinner"];
                    if (isWinner)
                    {
                        leftWin.Visible = true;
                        team1Score.Text = winnerScore.ToString();
                        team2Score.Text = loserScore.ToString();
                        winner = true;
                    }

                    team1Name.Text = reader["name"].ToString();
                    string? prof = reader["logo_url"].ToString();
                    try { team1Img.Load(prof); }
                    catch { team1Img.Image = Properties.Resources.notfound; }

                    string? status = reader["status"].ToString();

                    if (status != "ONGOING")
                    {
                        StatusImg.SendToBack();
                        StatusImg.Image = null;
                        StatusLbl.Text = status;
                    }
                    else
                    {
                        StatusImg.BringToFront();
                        StatusLbl.Text = null;
                        StatusImg.Image = Properties.Resources.live;
                    }

                    count = 1;
                }
                else
                {

                    Boolean isWinner = (bool)reader["isWinner"];
                    if (isWinner)
                    {
                        rightWin.Visible = true;
                        team2Score.Text = winnerScore.ToString();
                        team1Score.Text = loserScore.ToString();
                        winner = true;
                    }

                    team2Name.Text = reader["name"].ToString();
                    string? prof = reader["logo_url"].ToString();
                    try { team2Img.Load(prof); }
                    catch { team2Img.Image = Properties.Resources.notfound; }


                    if (!winner)
                    {
                        team1Score.Text = score1;
                        team2Score.Text = score2;
                    }
                }

            }

            reader.Close();

            cn.Close();


        }

        private void GetTour()
        {
            if (!verifySGBDConnection())
                return;

            EventsPanel.Visible = true;
            EventsLbl.Visible = true;

            makeInvisible(EventsPanel, EventsLbl);

            Tname.Text = SearchList.SelectedItems[0].SubItems[2].Text;

            SqlCommand cmd = new SqlCommand("EXEC getSearchTour @ID", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", SearchList.SelectedItems[0].SubItems[2].Text);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RegionLbl.Text = reader["region"].ToString();
                NumTeamsLbl.Text = reader["number_teams"].ToString();
                EndLbl.Text = reader["end_date"].ToString();
                StartLbl.Text = reader["start_date"].ToString();
                Tstatus.Text = reader["status"].ToString();
                PrizeLbl.Text = '$' + reader["prize"].ToString();
                Torg.Text = reader["organization"].ToString();
                FormatLbl.Text = reader["format"].ToString();
                Tgame.Text = reader["game"].ToString();
                WinnerLbl.Text = reader["team"].ToString();
            }

            cn.Close();
        }

        private void makeInvisible(Panel? p, Label? l)
        {
            Panel[] panels = new Panel[] {TeamsPanel, PlayerPanel, OrgPanel, EventsPanel, SeriesPanel, TodoPanel};
            Label[] labels = new Label[] {PlayersLbl, OrgLbl, EventsLbl, SeriesLbl, TeamHeaderLbl, TODO};

            foreach (Panel pp in panels)
            {
                if (p != pp)
                    pp.Visible = false;
            }

            foreach (Label ll in labels)
            {
                if (l != ll)
                    ll.Visible = false;
            }

        }
    }
}
