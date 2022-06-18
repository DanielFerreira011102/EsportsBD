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

        public PlayersForm()
        {
            InitializeComponent();
            cn = getSGBDConnection();

            lvwColumnSorter = new ListViewColumnSorter();
            this.PlayerList.ListViewItemSorter = lvwColumnSorter;

            PlayerList.GridLines = true;
            GameSelect.SelectedItem = "CS:GO";
            IGLStar.BackColor = Color.Transparent;
            LoadBDPlayers();        
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            // Perform the sort with these new sort options.
            this.PlayerList.Sort();

            PlayerList.Items[0].Selected = true;
            PlayerList.Select();
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

            if (!verifySGBDConnection())
                return;

            if (PlayerList.SelectedIndices.Count > 0)
            {
                RankLbl.Text = PlayerList.SelectedItems[0].SubItems[0].Text;
                IGNLbl.Text = PlayerList.SelectedItems[0].SubItems[1].Text;
                TeamLbl.Text = PlayerList.SelectedItems[0].SubItems[2].Text;
                CountryLbl.Text = PlayerList.SelectedItems[0].SubItems[3].Text;

                SqlCommand cmd = new SqlCommand("SELECT * FROM getPlayerInfo(@rank, @GAME)", cn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@rank", Int32.Parse(RankLbl.Text));
                cmd.Parameters.AddWithValue("@GAME", GameSelect.SelectedItem);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
      
                    UsernameLbl.Text = reader["username"].ToString();

                    GameLbl.Text = GameSelect.SelectedItem.ToString();
                    RealNameLbl.Text = reader["real_name"].ToString();

                    string? prof = reader["profile_url"].ToString();
                    try { PlayerProfile.Load(prof); }
                    catch { PlayerProfile.Image = Properties.Resources.notfound; }
                    
                    twitter = reader["twitter_url"].ToString();
                    twitch = reader["twitch_url"].ToString();

                    string? dt = reader["team_join_date"].ToString();

                    JoinDateLbl.Text = string.IsNullOrEmpty(dt) ? null : dt.Split(" ")[0];


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
            }

            cn.Close();

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

        private void GameSelect_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBDPlayers();
            PlayerList.Items[0].Selected = true;
            PlayerList.Select();
        }

        private void ShowTooltipIGL(object sender, EventArgs e)
        {
            if (IGLStar.Image != null)
            {
                ToolTip tt = new ToolTip();
                tt.SetToolTip(IGLStar, "IGL");
            }
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
    }
}
